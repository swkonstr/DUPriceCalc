using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public int Tier { get; set; }
        public string Type { get; set; }
        public double Mass { get; set; }
        public double Volume { get; set; }
        public double Output { get; set; }
        public int Time { get; set; }
        public string[] Industries { get; set; }
        public Dictionary<string, double> Input { get; set; }
    }
}
