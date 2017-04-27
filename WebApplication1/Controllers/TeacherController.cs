using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Dal;
using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    [Route("Teacher")]
    public class TeacherController : ApiController
    {
        private readonly ITeacherDal _teacherDal;

        public TeacherController(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }


        [HttpPut]
        public long PutTeacher(TeacherDto teacherDto)
        {
           return _teacherDal.CreateTeacher(teacherDto);
        }

        [HttpDelete]
        public void DeleteTeacher(long id)
        {
            _teacherDal.DeleteTeacher(id);
        }

        //TODO UpdateTeacher

        [HttpPut]
        public void UpdateTeacher(long id, TeacherDto teacherDto)
        {
            _teacherDal.UpdateTeacher(id, teacherDto);
        }

        // GET teacher/topicName
        [HttpGet]
        public IEnumerable<TeacherClassDto> GetClassesWithTeacher(string topicName)
        {

            throw new Exception("TEST");
            return _teacherDal.GetTeacherClassDtos(topicName);
        }
    }
}