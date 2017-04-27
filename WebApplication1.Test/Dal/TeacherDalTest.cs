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
        [Test]
        public void DeleteTeacher()
        {
            //Arrange
            var contexFactory = Substitute.For<IContextFactory>();
            var teacherDal = new TeacherDal(contexFactory);
            var context = Substitute.For<SchoolContext>();
            var teacherDbSet = Substitute.For<DbSet<Teacher>>();

            contexFactory.Create().Returns(context);
            context.Teachers = teacherDbSet;

            teacherDbSet.Attach(Arg.Do<Teacher>(t =>
            t.Person = new Person()
                {
                    Name = "Pawel",
                    Surname = "Styrna"
                }
            ));

            //Act
            teacherDal.DeleteTeacher(1);

            //Assert
            teacherDbSet.Received().Attach(Arg.Is<Teacher>(t => t.Id == 1));
            teacherDbSet.Received().Remove(Arg.Is<Teacher>(t => t.Id == 1 && t.Person.Name == "Pawel" && t.Person.Surname == "Styrna"));
            context.Received().SaveChanges();
        }

        [Test]
        public void UpdateTeacher()
        {
            //Arrange
            var contexFactory = Substitute.For<IContextFactory>();
            var teacherDal = new TeacherDal(contexFactory);
            var context = Substitute.For<SchoolContext>();
            var teacherDbSet = Substitute.For<DbSet<Teacher>>();

            contexFactory.Create().Returns(context);
            context.Teachers = teacherDbSet;

            var teacherDto = new TeacherDto()
            {
                Name = "Jacek",
                Surname = "Maslak"
            };

            teacherDbSet.Attach(Arg.Do<Teacher>(t =>
            t.Person = new Person()
            {
                Name = "Pawel",
                Surname = "Styrna"
            }
            ));

            //Act
            teacherDal.UpdateTeacher(1, teacherDto);

            //Assert
            teacherDbSet.Received().Attach(Arg.Is<Teacher>(t => t.Id == 1));
            context.ChangeTracker.Entries().Equals(teacherDto);
            context.Received().SaveChanges();
            
        }
    }
}