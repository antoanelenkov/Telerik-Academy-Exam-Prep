namespace DataGenerator
{
    using Company.DataGenerator;
    using System.Collections.Generic;
    using Data;
    using System;

    public class CountriesDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var country = new Countre { Name = random.GetRandomString(random.GetRandomNumber(5, 50)) };
                data.Countres.Add(country);
            }
        }
    }
}
