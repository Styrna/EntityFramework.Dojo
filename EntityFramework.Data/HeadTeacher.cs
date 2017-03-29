using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class HeadTeacher
    {
        [Key, ForeignKey("Class")]
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual Class Class { get; set; }
    }
}
