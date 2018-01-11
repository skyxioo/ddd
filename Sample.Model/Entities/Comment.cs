using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Model
{
    public class Comment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CmtArtId { get; set; }
        public int ParentId { get; set; }
        public int VisitorId { get; set; }
        public string CmtText { get; set; }
        public short Status { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime? AltTime { get; set; }

        [ForeignKey("CmtArtId")]
        public virtual Article Article { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
