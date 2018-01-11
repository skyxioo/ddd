using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Model
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Descn { get; set; }
        public short Status { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime? AltTime { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
