using NSubstitute;
using NUnit.Framework;
using WebApplication1.Controllers;
using WebApplication1.Dal;
using WebApplication1.Dto;

namespace WebApplication1.Test.Controllers
{
    [TestFixture]
    class TeacherControllerTest
    {
        [Test]
        public void PutTeacher_ReturnTeacherId()
        {
            //Arrange
            var teacherDal = Substitute.For<ITeacherDal>();
            var teacherController = new TeacherController(teacherDal);
            var teacherDto = new TeacherDto();

            teacherDal.CreateTeacher(teacherDto).Returns(1);

            //Act
            var id = teacherController.PutTeacher(teacherDto);

            //Assert
            Assert.That(id, Is.EqualTo(1));
        }
        
        //TODO tests for delete and update
    }
}
