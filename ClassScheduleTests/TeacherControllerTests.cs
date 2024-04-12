using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace ClassScheduleTests
{
    public class TeacherControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {

            var teacherRep = new Mock<IRepository<Teacher>>();
            teacherRep.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()));
            var controller = new TeacherController(teacherRep.Object);
            var result =controller.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}