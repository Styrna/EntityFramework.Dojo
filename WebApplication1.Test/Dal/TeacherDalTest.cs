using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data;
using NSubstitute;
using NUnit.Framework;
using WebApplication1.Dal;
using WebApplication1.Dto;

namespace WebApplication1.Test.Dal
{
    [TestFixtureAttribute]
    class TeacherDalTest
    {
        [Test]
        public void CreateTeacher()
        {
            //Arrange
            var contexFactory = Substitute.For<IContextFactory>();
            var context = Substitute.For<SchoolContext>();
            var teacherDbSet = Substitute.For<DbSet<Teacher>>();

            var teacherDal = new TeacherDal(contexFactory);
            var teacherDto = new TeacherDto()
            {
                Name = "Jacek",
                Surname = "Maslak"
            };

            contexFactory.Create().Returns(context);
            context.Teachers = teacherDbSet;

            teacherDbSet.Add(Arg.Do<Teacher>(t => t.Id = 1));

            //Act
            var id = teacherDal.CreateTeacher(teacherDto);

            //Assert
            teacherDbSet.Received().Add(Arg.Is<Teacher>(
                t => t.Person.Name == teacherDto.Name
                     && t.Person.Surname == teacherDto.Surname));
            context.Received().SaveChanges();
            Assert.That(id, Is.EqualTo(1));
        }

        //TODO DeleteTeacherTest

    }
}