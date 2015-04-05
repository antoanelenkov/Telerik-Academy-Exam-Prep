using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class EelementFactory:IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new Element(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new Element(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            throw new NotImplementedException();
        }
    }
}
