using System;

namespace Computers.Drawers
{
    class ConsoleMonochromeDrawer : IDrawer
    {
        public void Draw(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
