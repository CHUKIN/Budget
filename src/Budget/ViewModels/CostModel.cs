using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.ViewModels
{
    public class CostModel
    {
      
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Money { get; set; }
        public string Category { get; set; }
        public string User { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }
        public string Cash { get; set; }
    }
}
