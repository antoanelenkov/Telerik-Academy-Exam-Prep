using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class Element : IElement
    {
        private ICollection<IElement> childElements;

        public Element(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public Element(string name, string textContent)
            : this(name)
        {
            this.TextContent = textContent;
        }

        public string Name
        {
            private set;
            get;
        }

        public string TextContent
        {
            get;
            set;
        }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return new List<IElement>(this.childElements);
            }
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append("<" + this.Name + ">");
            }
            if (this.TextContent != null)
            {
                this.TextContent = this.TextContent.Replace("&", "&amp;");
                this.TextContent=this.TextContent.Replace("<", "&lt;");
                this.TextContent=this.TextContent.Replace(">", "&gt;");
                output.Append(this.TextContent);
            }
            foreach (var item in this.ChildElements)
            {
                if (item.Name != null)
                {
                    output.Append("<" + item.Name + ">");
                    if (item.TextContent != null)
                    {
                        item.TextContent = item.TextContent.Replace("&", "&amp;");
                        item.TextContent=item.TextContent.Replace("<", "&lt;");
                        item.TextContent=item.TextContent.Replace(">", "&gt;");
                        output.Append(item.TextContent);
                    }
                    output.Append("</" + item.Name + ">");
                }
            }
            if (this.Name != null)
            {
                output.Append("</" + this.Name + ">");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Render(sb);
            return sb.ToString();
        }
    }
}
