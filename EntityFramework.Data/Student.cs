using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class Student
    {
        [Key]
        public long Id { get; set; }

        public long PersonId { get; set; }
        public Person Person { get; set; }

        public long ClassId { get; set; }
        public virtual Class Class { get; set; }


        public ICollection<Topic> Topics { get; set; }
    }
}
