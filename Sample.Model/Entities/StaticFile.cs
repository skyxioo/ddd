using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class StaticFile : IEntity
    {
        public int Id { get; set; }
        public string FileRawName { get; set; }
        public string FileNowName { get; set; }
        public string FileLocalPath { get; set; }
        public string FileOnLineURL { get; set; }
        public int? FromArticleId { get; set; }
        public short FileType { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
