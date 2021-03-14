using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Models
{
    public class Skill
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Level { get; set; }
        public List<Rule> Rules { get; set; }
    }

    public class Rule
    {
        public List<string> Recipe { get; set; }
    }
}
