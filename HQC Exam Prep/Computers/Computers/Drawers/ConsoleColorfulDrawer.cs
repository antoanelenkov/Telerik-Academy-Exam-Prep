using System;

namespace Computers.Drawers
{
    class ConsoleColorfulDrawer : IDrawer
    {
        public void Draw(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
