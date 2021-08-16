using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Models
{
    public class BlockSummary
    {
        public int Index { get; set; }
        public DateTime Stamp { get; set; }
        public string PreviousBlock { get; set; }
        public string Hash { get; set; }
        public int Nounce { get; set; }
    }
}
