using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework.Data;
using WebApplication1.Dto;

namespace WebApplication1.Dal
{
    public interface ITeacherDal
    {
        IEnumerable<TeacherClassDto> GetTeacherClassDtos(string topicName);
    }
    public class TeacherDal : ITeacherDal
    {
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
    }
}