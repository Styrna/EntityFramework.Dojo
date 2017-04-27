using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data.Validation.Validators
{
    public interface IValidator
    {
        Type GetValidatedType();
    }

    public interface IValidator<T> : IValidator where T : IEntity
    {
        Type GetValidatedType();

        bool Validate(T target);
    }

    public abstract class Validator<T> : IValidator<T> where T : IEntity
    {
        public Type GetValidatedType()
        {
            return typeof(T);
        }

        public abstract bool Validate(T target) where T : IEntity;
    }
}
