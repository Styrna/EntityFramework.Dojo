using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class School
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
