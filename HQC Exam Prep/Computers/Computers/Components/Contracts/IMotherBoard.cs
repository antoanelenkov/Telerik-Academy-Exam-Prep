namespace Computers.Components.Contracts
{
    public interface IMotherBoard
    {
        int LoadRamValue();
        void SaveRamValue(int value);
        void DrawOnVideoCard(string data);
    }
}
