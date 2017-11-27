using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Article : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Keywords { get; set; }
        public string Contents { get; set; }
        public string ContentsRaw { get; set; }
        public int Digg { get; set; }
        public int ViewCount { get; set; }
        public short Status { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime? AltTime { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
