using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Model
{
    public class HeadIcon : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string IconName { get; set; }
        public string IconRawName { get; set; }
        public string IconURL { get; set; }
        public short Status { get; set; }
        public DateTime UploadTime { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
