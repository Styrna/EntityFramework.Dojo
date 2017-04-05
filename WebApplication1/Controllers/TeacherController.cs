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

        public TeacherController()
        {
            _teacherDal = new TeacherDal();
        }

        // GET teacher/topicName
        [HttpGet]
        public IEnumerable<TeacherClassDto> GetClassesWithTeacher(string topicName)
        {
            return _teacherDal.GetTeacherClassDtos(topicName);
        }
    }
}