using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public interface IContextFactory
    {
        SchoolContext Create();
    }

    public class ContextFactory:IContextFactory
    {
        public SchoolContext Create()
        {
            return new SchoolContext();
        }
    }
}
