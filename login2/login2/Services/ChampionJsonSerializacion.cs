using login2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace login2.Services
{
    public class ChampionJsonSerializacion //clase para encapsular el método
    {
        public List<Champion> LoadChampionsFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var champions = JsonConvert.DeserializeObject<List<Champion>>(json);
            return champions;
        }
    }
}
