using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Models
{
    public class Workout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Instructions { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
        public string Rest { get; set; }
    }
}
