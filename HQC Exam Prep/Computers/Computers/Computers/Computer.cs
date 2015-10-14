using Computers.UI.Console.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.UI.Console.Computers
{
    class Computer
    {
        internal Computer(ComputerType type, Cpu cpu, Ram ram, IEnumerable<HardDrive> hardDrives, HardDrive hardDrive, LaptopBattery battery,VideoCard videocard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.HardDrive = hardDrive;
            this.Videocard = videocard;
            this.Battery = battery;
        }

        IEnumerable<HardDrive> HardDrives { get; set; }
        HardDrive HardDrive { get; set; }

        Cpu Cpu { get; set; }

        LaptopBattery Battery { get; set; }

        Ram Ram { get; set; }

        VideoCard Videocard { get; set; }

        public void Play(int guessNumber)
        {
            Cpu.rand(1, 10);
            var number = Ram.LoadValue();
            if (number + 1 != guessNumber + 1) Videocard.Draw(string.Format("You didn't guess the number {0}.", number));
            else Videocard.Draw("You win!");
        }

        internal void ChargeBattery(int percentage)
        {
            Battery.Charge(percentage);

            Videocard.Draw(string.Format("Battery status: {0}", Battery.Percentage));
        }

        internal void Process(int data)
        {
            Ram.SaveValue(data);
            Cpu.SquareNumber();
        }
    }
}
