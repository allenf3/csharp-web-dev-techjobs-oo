using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job fullJob1;
        Job fullJob2;

        [TestInitialize]
        public void MakeJobs()
        {
            fullJob1 = new Job("Product tester",
                       new Employer("ACME"),
                       new Location("Desert"),
                       new PositionType("Quality Control"),
                       new CoreCompetency("Persistence"));

            fullJob2 = new Job("Product tester",
                       new Employer("ACME"),
                       new Location("Desert"),
                       new PositionType("Quality Control"),
                       new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            Job job1 = new Job();
            Job job2 = new Job();
            Assert.IsFalse(job1.Id == job2.Id);
            Assert.IsTrue(Math.Abs(job1.Id - job2.Id) == 1);
        }
        
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester", fullJob1.Name);
            Assert.AreEqual("ACME", fullJob1.EmployerName.Value);
            Assert.AreEqual("Desert", fullJob1.EmployerLocation.Value);
            Assert.AreEqual("Quality Control", fullJob1.JobType.Value);
            Assert.AreEqual("Persistence", fullJob1.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(fullJob1.Equals(fullJob2));
        }
    }
}
