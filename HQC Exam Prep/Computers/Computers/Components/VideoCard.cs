namespace Computers
{
    using Drawers;
    using System;

    internal class VideoCard
    {
        public VideoCard(IDrawer drawer)
        {
            this.Drawer = drawer;
        }

        public IDrawer Drawer { get; set; }

        public void Draw(string msg)
        {
            this.Drawer.Draw(msg);
        }
    }
}
