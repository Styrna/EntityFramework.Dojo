using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data.Validation.Validators;

namespace EntityFramework.Data.Validation
{
    public interface IEntityValidator
    {
        bool Validate<T>(T target) where T : IEntity;
    }

    public class EntityValidator : IEntityValidator
    {
        private readonly IEnumerable<IValidator> _validators;

        public EntityValidator(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }

        public bool Validate<T>(T target) where T : IEntity
        {
            
        }
    }
}
