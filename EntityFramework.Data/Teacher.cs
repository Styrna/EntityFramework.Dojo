using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class Teacher : IEntity
    {
        [Key]
        public long Id { get; set; }

        public long PersonId { get; set; }
        public Person Person { get; set; }

        public ICollection<Class> Classes { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Topic> Topics { get; set; }
        
    }
}
