using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.Data;
using NLog;

namespace EntityFramework.Dojo
{
    class Program
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            _log.Debug("Start");
            using (var context = new SchoolContext())
            {
                context.Database.Log = (message) => _log.Debug(message);

                //var school = new School
                //{
                //    Name = "90",
                //    Adress = "Piastow"
                //};

                //var clas1a = new Class
                //{
                //    Name = "1a",
                //    SchoolId = 2
                //};
                //var clas1b = new Class
                //{
                //    Name = "1b",
                //    SchoolId = 2
                //};


                //context.Schools.Add(school);
                //context.Classes.AddRange(new[] { clas1a, clas1b });

                var school = new School()
                {
                    Id = 2
                };

                context.Schools.Attach(school);
                context.Schools.Remove(school);

                context.SaveChanges();

                var result = context.Schools.Select(s => new
                {
                    SchoolName = s.Name,
                    ClassesNames = s.Classes.Select(c => c.Name)
                });
                

                foreach (var s in result)
                {
                    _log.Info(s.SchoolName);
                    foreach (var c in s.ClassesNames)
                    {
                        _log.Info($"   {c}");
                    }
                }
            }
            _log.Debug("End");
            Console.ReadKey();
        }
    }
}
