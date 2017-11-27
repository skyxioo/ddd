using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class PalLink : IEntity
    {
        public int Id { get; set; }
        public string LinkName { get; set; }
        public string LinkURL { get; set; }
        public short Status { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime? AltTime { get; set; }
    }
}
