using System;
using System.Collections.Generic;
using System.Text;

namespace login2.Models
{
    public class Champion
    {
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string lore { get; set; }
        public string blurb { get; set; }
        public Image image { get; set; }
        public List<Skin> skins { get; set; }
        public List<string> tags { get; set; }
        public string partype { get; set; }
        public Info info { get; set; }
        public Stats stats { get; set; }
        // Agregar las propiedades adicionales necesarias
    }

    public class Image
    {
        public string full { get; set; }
        public string sprite { get; set; }
        public string group { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Skin
    {
        public int id { get; set; }
        public string name { get; set; }
        public int num { get; set; }
    }

    public class Info
    {
        public int attack { get; set; }
        public int defense { get; set; }
        public int magic { get; set; }
        public int difficulty { get; set; }
    }

    public class Stats
    {
        public double hp { get; set; }
        public double hpperlevel { get; set; }
        public double mp { get; set; }
        // Añadir las propiedades adicionales que encuentres en el JSON
    }
}
