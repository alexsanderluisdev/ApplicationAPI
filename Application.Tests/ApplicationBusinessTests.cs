using Application.Business;
using Application.Repository;
using NUnit.Framework;
using System.Collections;

namespace Application.Tests
{
    public class ApplicationBusinessTests
    {
        private readonly ApplicationBusiness applicationBusiness;
        private readonly ApplicationRepository applicationRepository;

        public static IEnumerable applications
        {
            get
            {
                yield return new TestCaseData(new Models.Application.Application(1, "a", "aa", true));
                yield return new TestCaseData(new Models.Application.Application(2, "b", "bb", true));
                yield return new TestCaseData(new Models.Application.Application(3, "c", "cc", true));
            }
        }

        public ApplicationBusinessTests()
        {
            applicationRepository = new ApplicationRepository("Server=localhost\\SQLEXPRESS;Database=MyDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            applicationBusiness = new ApplicationBusiness(applicationRepository);
        }

        [Test]
        [TestCaseSource("applications")]
        public void Add(Models.Application.Application application)
        {
            Models.Application.Application applicationAdded = applicationBusiness.Add(application);
            
            Assert.AreEqual(applicationAdded.Url, application.Url);
            Assert.AreEqual(applicationAdded.PathLocal, application.PathLocal);
            Assert.AreEqual(applicationAdded.DebuggingMode, application.DebuggingMode);
        }

        [Test]
        [TestCaseSource("applications")]
        public void Update(Models.Application.Application application)
        {
            application.Url += " updated";
            application.PathLocal += " updated";
            application.DebuggingMode = !application.DebuggingMode;

            Models.Application.Application applicationUpdated = applicationBusiness.Update(application);

            Assert.AreEqual(applicationUpdated.Url, application.Url);
            Assert.AreEqual(applicationUpdated.PathLocal, application.PathLocal);
            Assert.AreEqual(applicationUpdated.DebuggingMode, application.DebuggingMode);
        }

        [Test]
        [TestCaseSource("applications")]
        public void Delete(Models.Application.Application application)
        {
            bool success = applicationBusiness.Delete(application.Id);

            Assert.IsTrue(success);
        }
    }
}