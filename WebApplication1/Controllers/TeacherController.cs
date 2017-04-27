using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;
using WebApplication1.Dal;
using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    [Route("Teacher")]
    public class TeacherController : ApiController
    {

        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        private readonly ITeacherDal _teacherDal;

        public TeacherController(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        [HttpGet]
        public async Task<TeacherDto> GetTeacher(long id)
        {
            _log.Info("Working ...");
            await Task.Delay(60000);
            return new TeacherDto();
        }

        [HttpPut]
        public Task<long> PutTeacher([FromBody]TeacherDto teacherDto)
        {
           return _teacherDal.CreateTeacher(teacherDto);
        }

        [HttpDelete]
        public void DeleteTeacher(long id)
        {
            _teacherDal.DeleteTeacher(id);
        }

        //TODO Async everything

        [HttpPut]
        public void UpdateTeacher(long id, TeacherDto teacherDto)
        {
            _teacherDal.UpdateTeacher(id, teacherDto);
        }
    }
}