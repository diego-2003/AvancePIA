using login2.Models;
using login2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//El proposito es mostrar el resultado de la seleccion

namespace login2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuResultado : ContentPage
    {
        private ChampionService championService;

        public MenuResultado()
        {
            InitializeComponent();
            championService = new ChampionService();
        }

        private void OnSelectRandomChampion(object sender, EventArgs e)
        {
            var champion = championService.GetRandomChampion();
            if (champion != null)
            {
                championLabel.Text = $"{champion.name} - {champion.title}\n\n{champion.lore}";
            }
            else
            {
                championLabel.Text = "No se encontró ningún personaje.";
            }
        }

        public Champion GetRandomChampion()
        {
            var champions = JsonConvert.DeserializeObject<List<Champion>>(File.ReadAllText("championFull.json"));
            if (champions != null && champions.Count > 0)
            {
                var random = new Random();
                int index = random.Next(champions.Count);
                return champions[index];
            }
            return null;
        }



    }
}