using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;
using Microsoft.AspNetCore.Http;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            var unit = new Mock<IClassScheduleUnitOfWork>();
            var http = new Mock<IHttpContextAccessor>();
            var controller=new HomeController(unit.Object,http.Object);

            var classRep = new Mock<IRepository<Class>>();
            var teacherRep = new Mock<IRepository<Teacher>>();
            var dayRep = new Mock<IRepository<Day>>();

            classRep.Setup(m => m.List(It.IsAny<QueryOptions<Class>>()));
            teacherRep.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()));
            dayRep.Setup(m => m.List(It.IsAny<QueryOptions<Day>>()));

            unit.Setup(m => m.Classes).Returns(classRep.Object);
            unit.Setup(m => m.Teachers).Returns(teacherRep.Object);
            unit.Setup(m => m.Days).Returns(dayRep.Object);


            var result = controller.Index(0);
            Assert.IsType<ViewResult>(result);


        }
    }
}
