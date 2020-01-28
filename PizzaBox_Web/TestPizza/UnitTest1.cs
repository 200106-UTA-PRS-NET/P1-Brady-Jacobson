using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPizza
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Index()
        {
            //EmployeeController controler = new EmployeeController(new MockRepository());
            //var result = controler.index() as viewResult;
            Assert.Equals(1, 1);
        }
    }
}
