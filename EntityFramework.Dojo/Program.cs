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
                var school = new School
                {
                    Name = "89",
                    Adress = "Szkolne"
                };

                var class1a = new Class
                {
                    Name = "1a",
                    SchoolId = 1
                };
                var class1b = new Class
                {
                    Name = "1b",
                    SchoolId = 1
                };
                var student1 = new Student
                {
                    Name = "Pawel"
                };
                var student2 = new Student
                {
                    Name = "Piotr"
                };
                var subject1 = new Subject
                {
                    Name = "Matematyka"
                };
                var subject2 = new Subject
                {
                    Name = "Biologia"
                };

                context.Schools.Add(school);
                _log.Info(school.Name);
                _log.Info(school.Adress);
                context.Classes.AddRange(new[] { class1a, class1b });
                _log.Info(class1a.Name);
                _log.Info(class1a.SchoolId);
                _log.Info(class1b.Name);
                _log.Info(class1b.SchoolId);
                context.SaveChanges();

                //-----------------------------Attach to value in table
                //var school = new School()
                //{
                //    Id = 1
                //};

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
