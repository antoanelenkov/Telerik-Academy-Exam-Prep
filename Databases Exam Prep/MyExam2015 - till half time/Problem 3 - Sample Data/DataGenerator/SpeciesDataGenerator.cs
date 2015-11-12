namespace DataGenerator
{
    using Company.DataGenerator;
    using Data;
    using System.Collections.Generic;
    using System.Linq;


    public class SpeciesDataGenerator : IDataGenerator
    {
        public void GenerateData(PetStoreEntities data, IRandomGenerator random, int count)
        {
            var uniqueNames = new HashSet<string>();

            while (uniqueNames.Count < count)
            {
                uniqueNames.Add(random.GetRandomString(random.GetRandomNumber(10, 50)));
            }

            var countryIds = data.Countres.Select(c => c.Id).ToList();

            foreach (var uniqueName in uniqueNames)
            {
                var countriesInSpecies = random.GetRandomNumber(1, 11);
                var currentCountries = new HashSet<int>();

                while (currentCountries.Count < countriesInSpecies)
                {
                    var randomCountryId = countryIds[random.GetRandomNumber(0, countryIds.Count - 1)];
                    currentCountries.Add(randomCountryId);
                }

                foreach (var currentId in currentCountries)
                {
                    var species = new Species { Name = uniqueName, CountryId=currentId };
                    data.Species.Add(species);
                }               
            }
        }
    }
}
