using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.Data;
using Microsoft.Build.Utilities;
using NLog;
using Logger = NLog.Logger;

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

                //---------------------------------Add to table
                //var school = new School
                //{
                //    Name = "89",
                //    Adress = "Szkolne"
                //};
                //context.Schools.Add(school);
                //var class1a = new Class
                //{
                //    Name = "1a",
                //    School = school
                //};
                //context.Classes.Add(class1a);
                //var class1b = new Class
                //{
                //    Name = "1b",
                //    School = school
                //};
                //context.Classes.Add(class1b);

                //var piotr = new Person()
                //{
                //    Name = "Piotr",
                //};
                //context.Persons.Add(piotr);
                //var teacher = new Teacher()
                //{
                //    Person = piotr,
                //};
                //context.Teachers.Add(teacher);

                //var pawel = new Person()
                //{
                //    Name = "Pawel"
                //};
                //context.Persons.Add(pawel);
                //var student = new Student()
                //{
                //    Person = pawel,
                //    Class = class1a,
                //};
                //context.Students.Add(student);
                
                var school = new School() { Id = 1 };
                context.Schools.Attach(school);
                context.Schools.Remove(school);

                context.SaveChanges();

               
                //context.Schools.Attach(school);
                //context.Schools.Remove(school);
                //context.SaveChanges();

                //----------------------------------------------------Select
                //var result = context.Schools.Select(s => new
                //{
                //    SchoolName = s.Name,
                //    ClassesNames = s.Classes.Select(c => c.Name)
                //});


                //foreach (var s in result)
                //{
                //    _log.Info(s.SchoolName);
                //    foreach (var c in s.ClassesNames)
                //    {
                //        _log.Info($"   {c}");
                //    }
                //}
            }
            _log.Debug("End");
            Console.ReadKey();
        }
    }
}
