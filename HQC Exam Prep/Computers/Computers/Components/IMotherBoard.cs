namespace Computers.UI.Console.Components
{
    public interface IMotherboard
    {
        int LoadRamValue();
        void SaveRamValue(int value);
        void DrawOnVideoCard(string data);
    }
}
