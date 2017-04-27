using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data.Validation.Validators
{
    public class Teacher2Validator : IValidator<Teacher>
    {
        public bool Validate(Teacher target)
        {
            if (target.Classes.Any())
                return true;
            return false;
        }
    }
}
