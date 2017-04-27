using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class Topic : IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public long SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
