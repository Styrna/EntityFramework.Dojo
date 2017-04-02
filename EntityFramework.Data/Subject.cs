using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class Subject
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public long ClassId { get; set; }
        public virtual Class Class { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
