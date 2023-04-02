using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Player
    {
        public string UserId { get; set; }
        public int Level { get; set; }
        public int BambooCount { get; set; }
        public int GoldCount { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Panda> Pandas { get; set; }
    }
}
