using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class Table : Element, ITable
    {
        private string textContent;
        IElement[,] arr;



        public Table(int row, int col)
            : base("table")
        {
            arr = new IElement[row, col];
            this.Rows = row;
            this.Cols = col;
        }


        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public IElement this[int row, int col]
        {
            get
            {
                return arr[row, col];
            }
            set
            {
                arr[row, col] = value;
            }
        }

        public void Render(StringBuilder output)
        {
            output.Append("<table>");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                output.Append("<tr>");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    output.Append("<td>");
                    output.Append(arr[i,j].ToString());                    
                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

    }
}
