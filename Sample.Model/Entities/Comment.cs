using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int CmtArtId { get; set; }
        public int ParentId { get; set; }
        public int VisitorId { get; set; }
        public string CmtText { get; set; }
        public short Status { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime? AltTime { get; set; }

        public virtual Article Article { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
