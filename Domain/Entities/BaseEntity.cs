using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public string Id { set; get; } = Guid.NewGuid().ToString();
        public DateTimeOffset CreateTime { set; get; }=DateTimeOffset.Now;
        public DateTimeOffset UpdateTime { set; get; }
        public bool IsDeleted { set; get; } = false;
    }
}
