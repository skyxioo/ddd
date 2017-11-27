﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class SearchRank : IEntity
    {
        public Guid Id { get; set; }
        public string KeyWord { get; set; }
        public int? SearchTimes { get; set; }
    }
}
