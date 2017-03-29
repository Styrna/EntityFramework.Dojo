using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class Topic
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
