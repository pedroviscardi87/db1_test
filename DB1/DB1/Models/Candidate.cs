using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB1.Models
{
    public class Candidate
    {
        public int id { get; set; }
        public string name { get; set; }
        public Vacancy vacancy { get; set; }
        public List<Technology> technologies { get; set; }
    }
}