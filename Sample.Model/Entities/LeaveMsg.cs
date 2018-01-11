using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Model
{
    public class LeaveMsg : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int VisitorId { get; set; }
        public string LMessage { get; set; }
        public short Status { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime AltTime { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
