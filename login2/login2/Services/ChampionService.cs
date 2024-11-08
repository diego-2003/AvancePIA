using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using login2.Models;

//Logica detras de la seleccion de campeon
namespace login2.Services
{
    public class ChampionService
    {
        private List<Champion> champions;

        public ChampionService()
        {
            LoadChampionsData();
        }

        private void LoadChampionsData()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ChampionService)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("login2.Data.championFull.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Dictionary<string, Champion>>(json);
                champions = data.Values.ToList();
            }
        }

        public Champion GetRandomChampion()
        {
            if (champions == null || champions.Count == 0)
                return null;

            var random = new Random();
            return champions[random.Next(champions.Count)];
        }
    }
}
