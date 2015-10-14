namespace Computers
{
    using UI.Console.Common;
    using System;
    using System.Collections.Generic;
    using UI.Console.Computers;
    using Components.CPUs;
    using Drawers;
    using RandomGenerators;

    public class Computers
    {
        public static void Main()
        {
            Computer pc;
            Computer laptop;
            Computer server;
            IDrawer monochromeDrawer = new ConsoleMonochromeDrawer();
            IDrawer colorfulDrawer = new ConsoleColorfulDrawer();
            IRandomGenerator randomgenerator = new SystemRandomGenerator();

            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var personalPcRam = new Ram(4);
                var personalPcHard = new HardDrive();
                var personalPcVideoCard = new VideoCard(colorfulDrawer);
                var personalPcCpu = new Cpu32(4, personalPcRam, personalPcVideoCard, randomgenerator);


                pc = new Computer(ComputerType.PC, personalPcCpu, personalPcRam,
                    new[] { new HardDrive(500, false, 0) }, personalPcHard, null, personalPcVideoCard);

                var serverRam = new Ram(32);
                var serverHard = new HardDrive();
                var serverVideoCard = new VideoCard(monochromeDrawer);
                var serverCpu = new Cpu32(4, serverRam, serverVideoCard, randomgenerator);
                server = new Computer(ComputerType.SERVER, serverCpu, serverRam,
                    new List<HardDrive>
                    { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(1000, false, 0), new HardDrive(1000, false, 0) }) }
                    , serverHard, null, serverVideoCard);


                var laptopHardDrive = new HardDrive();
                var laptopRam = new Ram(4);
                var laptopVideoCard = new VideoCard(colorfulDrawer);
                var laptopCpu = new Cpu64(4, laptopRam, laptopVideoCard, randomgenerator);
                laptop = new Computer(ComputerType.LAPTOP, laptopCpu, laptopRam,
                     new[] { new HardDrive(500, false, 0) }, laptopHardDrive, new LaptopBattery(), laptopVideoCard);
            }
            else if (manufacturer == "Dell")
            {
                var pcRam = new Ram(8);
                var pcHardDrive = new HardDrive();
                var pcVideoCard = new VideoCard(colorfulDrawer);
                var pcCpu = new Cpu64(4, pcRam, pcVideoCard, randomgenerator);

                pc = new Computer(ComputerType.PC, pcCpu, pcRam,
                    new[] { new HardDrive(1000, false, 0) }, pcHardDrive, null, pcVideoCard);

                var serverRam = new Ram(64);
                var serverHardDrive = new HardDrive();
                var serverVideoCard = new VideoCard(monochromeDrawer);
                var serverCpu = new Cpu64(8, serverRam, serverVideoCard, randomgenerator);
                server = new Computer(ComputerType.SERVER, serverCpu, serverRam,
                     new List<HardDrive>{
                            new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) })
                         }, serverHardDrive, null, serverVideoCard);

                var laptopRam = new Ram(8);
                var laptopHardDrive = new HardDrive();
                var laptopVideoCard = new VideoCard(colorfulDrawer);
                var laptopCpu = new Cpu32(4, laptopRam, laptopVideoCard, randomgenerator);
                laptop = new Computer(ComputerType.LAPTOP, laptopCpu , laptopRam,
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

