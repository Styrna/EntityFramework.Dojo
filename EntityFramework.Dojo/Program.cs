using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntityFramework.Data;
using EntityFramework.Data.Validation;
using Microsoft.Build.Utilities;
using Newtonsoft.Json;
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


               


                var a = new A();
                var b = new B();

                a.B = b;
                b.A = a;


                var techers = new Teacher[] {};

                var teacher = new Teacher();
                ;

                var validator = new EntityValidator();
                validator.Validate(teacher);
                //---------------------------------Selects

                //find all classes that already had Entity Framework topic in subject Programowainie
                //var stoper = new Stopwatch();
                //stoper.Start();
                //var topics = context.Topics
                //    .Where(t => t.Name == "Entity Framework")
                //    .Select(t => new
                //    {
                //      TeacherName = t.Teacher.Person.Name,
                //      ClassName = t.Subject.Class.Name
                //    })
                //    .ToList();

                //var resuList = topics.Select(t => $"{t.TeacherName}:{t.ClassName}");
                //_log.Info($"Query1:{stoper.ElapsedMilliseconds} ms- {string.Join(",", resuList)}");
                //stoper.Restart();

                //var classNames =
                //    context.Classes.Where(c => c.Subjects.Any(s => s.Topics.Any(t => t.Name == "Entity Framework"))).ToList();


                //-------------------------serialization
                //var person = new Person() { Surname = "Styrna", Name = "Piotr"};

                //var serializer = new XmlSerializer(typeof(Person));
                //using (StringWriter textWriter = new StringWriter())
                //{
                //    serializer.Serialize(textWriter, person);
                //    _log.Debug(textWriter.ToString());
                //}

                //var personString = "{\"Id\":0,\"Name\":\"Piotr\",\"Surname\":\"Styrna\"}";
                //_log.Debug(JsonConvert.SerializeObject(person));


                //var newPerson = JsonConvert.DeserializeObject(personString,typeof(Person));
                //var deserializedType = newPerson.GetType();


                //_log.Info($"Query2:{stoper.ElapsedMilliseconds} ms - count {classNames.Count}");

                //---------------------------------Add to table
                //var schoolId = context.Schools
                //    .Where(s => s.Name == "89")
                //    .Select(s => s.Id)
                //    .First();


                //var teacherId = context.Teachers
                //    .Where(t => t.Person.Name == "Piotr")
                //    .Select(t => t.Id)
                //    .First();

                //var class1a = new Class
                //{
                //    Name = "1d",
                //    SchoolId = schoolId,
                //    HeadTeacherId = teacherId
                //};

                //context.Classes.Add(class1a);

                //var subject = new Subject()
                //{
                //    Name = "Programowanie",
                //    Class = class1a,
                //    TeacherId = teacherId
                //};

                //var topic = new Topic()
                //{
                //    Name = "Entity Framework",
                //    TeacherId = teacherId,
                //    SubjectId = subject.Id
                //};

                //context.Subjects.Add(subject);
                //context.Topics.Add(topic);

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

                //var school = new School() { Id = 1 };
                //context.Schools.Attach(school);
                //context.Schools.Remove(school);

                //context.SaveChanges();


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
