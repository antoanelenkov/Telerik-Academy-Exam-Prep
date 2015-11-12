namespace PetStore.ConsoleClient
{
    using Company.DataGenerator;
    using Data;
    using DataGenerator;
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main()
        {
            var dataGeneratorExecutors = new List<DataGeneratorExecutor>
                                             {
                                                 new DataGeneratorExecutor(new CountriesDataGenerator(), 20),
                                                 new DataGeneratorExecutor(new SpeciesDataGenerator(), 100)
                                             };

            foreach (var dataGeneratorExecutor in dataGeneratorExecutors)
            {
                using (var data = new PetStoreEntities())
                {
                    data.Configuration.AutoDetectChangesEnabled = false;
                    //// data.Configuration.ProxyCreationEnabled = false;

                    Console.WriteLine("Staring {0}...", dataGeneratorExecutor.DataGenerator.GetType().Name);
                    dataGeneratorExecutor.Execute(data, RandomGenerator.Instance);
                    Console.WriteLine("Saving {0}...", dataGeneratorExecutor.DataGenerator.GetType().Name);
                    data.SaveChanges();
                    Console.WriteLine("Finished {0}.", dataGeneratorExecutor.DataGenerator.GetType().Name);
                }
            }
        }
    }
}
