using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class Person : IEntity, IValidatableObject
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Name != null)
                if(Name.IndexOfAny(new char[] { '*', '&', '#' }) != -1)
                    yield return new ValidationResult
                  ("Person Name cannont include characters like *,&,#");
        }
    }
}
