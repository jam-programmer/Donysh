using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PictureEntity:BaseEntity
    {
        public string? Path { set; get; }
        public string? Title { set; get; }
        public string? Alt { set; get; }
        public string? ProjectForeignKey { set; get; }
        public ProjectEntity? Project { set; get; }
    }
}
