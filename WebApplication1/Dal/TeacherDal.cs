using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using EntityFramework.Data;
using WebApplication1.Dto;

namespace WebApplication1.Dal
{
    public interface ITeacherDal
    {
        IEnumerable<TeacherClassDto> GetTeacherClassDtos(string topicName);
        Task<long > CreateTeacher(TeacherDto teacherDto);
        void DeleteTeacher(long id);
        void UpdateTeacher(long id, TeacherDto teacherDto);
    }

    public class TeacherDal : ITeacherDal
    {
        private IContextFactory _contextFactory;
        public TeacherDal(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IEnumerable<TeacherClassDto> GetTeacherClassDtos(string topicName)
        {
            using (var context = new SchoolContext())
            {
                return context.Topics
                    .Where(t => t.Name == topicName)
                    .Select(t => new TeacherClassDto
                    {
                        TeacherName = t.Teacher.Person.Name,
                        ClassName = t.Subject.Class.Name
                    })
                    .ToList();
            }
        }

        //Content-Type: application/json
        //        {  
        //   "teacherDto":{  
        //      "Name":"Lukasz",
        //      "Surname":"Bergiel"
        //   }
        //}

        //async await 
        // https://robinsedlaczek.com/2014/05/20/improve-server-performance-with-asynchronous-webapi/


            //TODO czemu deserializacja nie dziala
        public async Task<long> CreateTeacher(TeacherDto teacherDto)
        {
            using (var context = _contextFactory.Create())
            {
                var teacher = new Teacher()
                {
                    Person = new Person()
                    {
                        Name = teacherDto.Name,
                        Surname = teacherDto.Surname
                    }
                };

                context.Teachers.Add(teacher);
                await context.SaveChangesAsync();

                
                return teacher.Id;
            }
        }

        public void DeleteTeacher(long id)
        {
            using (var context = _contextFactory.Create())
            {
                var teacher = new Teacher() {Id = id};
                context.Teachers.Attach(teacher);
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
        }
        //TODO update teacher tylko zmiana klasy itp. zaciagnac i zmodyfikowac
        public void UpdateTeacher(long id, TeacherDto teacherDto)
        {
            using (var context = _contextFactory.Create())
            {
                var teacher = new Teacher() { Id = id };
                context.Teachers.Attach(teacher);
               

                var entry = context.Entry(teacher);
                if (teacher.Person.Name != teacherDto.Name && teacherDto.Name != null)
                {
                    teacher.Person.Name = teacherDto.Name;
                    // czegu tutaj uzyc co to jest referacne, collection, property, complex property 
                    entry.Property(e => e.Classes).IsModified = true;
                }
                if (teacher.Person.Surname != teacherDto.Surname && teacherDto.Surname != null)
                {
                    teacher.Person.Surname = teacherDto.Surname;
                    entry.Property(p => p.Person).IsModified = true;
                }
                context.SaveChanges();
            }
        }
    }
}