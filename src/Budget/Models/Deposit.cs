using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class Deposit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public string Cash { get; set; }
        public DateTime Date { get; set; }
    }
}
