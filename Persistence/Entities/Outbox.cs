using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Outbox
    {
        public Guid Id { get; set; }
        public string Type { get; set; }=String.Empty;
        public string Content { get; set; }=String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime ChangeAt { get; set; }
        public string? Error { get; set; }
    }
}
