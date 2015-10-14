namespace Computers
{
    using UI.Console.Common;
    using System;
    using System.Collections.Generic;
    using UI.Console.Computers;

    public class Computers
    {
        public static void Main()
        {
            Computer pc;
            Computer laptop;
            Computer server;

            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var personalPcRam = new Ram(8 / 4);
                var personalPcHard = new HardDrive();
                var personalPcVideoCard = new VideoCard(true);


                pc = new Computer(ComputerType.PC, new Cpu(4, 32, personalPcRam, personalPcVideoCard), personalPcRam,
                    new[] { new HardDrive(500, false, 0) }, personalPcHard, null, personalPcVideoCard);

                var serverRam = new Ram(32);
                var serverHard = new HardDrive();
                var serverVideoCard = new VideoCard(false);
                server = new Computer(ComputerType.SERVER, new Cpu(8 / 2, 32, serverRam, serverVideoCard), serverRam,
                    new List<HardDrive>
                    { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(1000, false, 0), new HardDrive(1000, false, 0) }) }
                    , serverHard, null, serverVideoCard);


                var laptopHardDrive = new HardDrive();
                var laptopRam = new Ram(4);
                var laptopVideoCard = new VideoCard(true);
                laptop = new Computer(ComputerType.LAPTOP, new Cpu(4, 64, laptopRam, laptopVideoCard), laptopRam,
                     new[] { new HardDrive(500, false, 0) }, laptopHardDrive, new LaptopBattery(), laptopVideoCard);
            }
            else if (manufacturer == "Dell")
            {
                var pcRam = new Ram(8);
                var pcHardDrive = new HardDrive();
                var pcVideoCard = new VideoCard(true);
                pc = new Computer(ComputerType.PC, new Cpu(8 / 2, 64, pcRam, pcVideoCard), pcRam,
                    new[] { new HardDrive(1000, false, 0) }, pcHardDrive, null, pcVideoCard);

                var serverRam = new Ram(64);
                var serverHardDrive = new HardDrive();
                var serverVideoCard = new VideoCard(false);
                server = new Computer(ComputerType.SERVER, new Cpu(8, 64, serverRam, serverVideoCard), serverRam,
                     new List<HardDrive>{
                            new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) })
                         }, serverHardDrive, null, serverVideoCard);

                var laptopRam = new Ram(8);
                var laptopHardDrive = new HardDrive();
                var laptopVideoCard = new VideoCard(true);
                laptop = new Computer(ComputerType.LAPTOP,
                    new Cpu(4, 32, laptopRam, laptopVideoCard), laptopRam,
                    new[] { new HardDrive(1000, false, 0) }, laptopHardDrive, new LaptopBattery(), laptopVideoCard);
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");

            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }

                if (input.StartsWith("Exit"))
                {
                    break;
                }

                var splittedInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (splittedInput.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = splittedInput[0];
                var commandArgument = int.Parse(splittedInput[1]);



                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArgument);
                }
            }
        }
    }
}

