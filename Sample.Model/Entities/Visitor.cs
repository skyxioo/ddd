﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Visitor : IEntity
    {
        public int Id { get; set; }
        public string VisitorName { get; set; }
        public int? VisitorIconId { get; set; }
        public string VisitorEmail { get; set; }
        public string VisitorQQ { get; set; }
        public short Status { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime? AltTime { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual HeadIcon HeadIcon { get; set; }
        public virtual ICollection<LeaveMsg> LeaveMsgs { get; set; }
    }
}
