using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job job1;
        Job job2;
        Job fullJob1;
        Job fullJob2;

        [TestInitialize]
        public void MakeJobs()
        {
            Employer emp = new Employer("ACME");
            Location loc = new Location("Desert");
            PositionType pt = new PositionType("Quality Control");
            CoreCompetency cc = new CoreCompetency("Persistence");

            fullJob1 = new Job("Product tester", emp, loc, pt, cc);
            fullJob2 = new Job("Product tester", emp, loc, pt, cc);

            job1 = new Job();
            job2 = new Job();
        }

        [TestMethod]
        public void TestSettingJobId()
        {
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

        [TestMethod]
        public void TestJobToStringFirstLineEmpty()
        {
            string firstLine;
            using (var reader = new StringReader(fullJob1.ToString()))
            {
                firstLine = reader.ReadLine();
            }
            Assert.AreEqual("", firstLine);
        }

        [TestMethod]
        public void TestJobToStringLastLineEmpty()
        {
            string[] lines = fullJob1.ToString().Split("\r\n");
            Assert.AreEqual("", lines[^1]);
        }

        [TestMethod]
        public void TestJobToStringMethod()
        {
            string expectedString =
                $"\r\n" +
                $"ID: { fullJob1.Id }\r\n" +
                $"Name: Product tester\r\n" +
                $"Employer: ACME\r\n" +
                $"Location: Desert\r\n" +
                $"Position Type: Quality Control\r\n" +
                $"Core Competency: Persistence\r\n";
            Assert.AreEqual(expectedString, fullJob1.ToString());

        }

        [TestMethod]
        public void TestDataNotAvailableForEmptyProperties()
        {
            Job job3 = new Job();
            job3.Name = "BigJob"; // One field must be set to avoid triggering "job does not exist"

            string expectedEmpty =
                $"\r\n" +
                $"ID: { job3.Id }\r\n" +
                $"Name: BigJob\r\n" +
                $"Employer: Data not available\r\n" +
                $"Location: Data not available\r\n" +
                $"Position Type: Data not available\r\n" +
                $"Core Competency: Data not available\r\n";
            Assert.AreEqual(expectedEmpty, job3.ToString());
        }

        [TestMethod]
        public void JobDoesNotExistIfNoPropertiesExceptID()
        {
            Assert.AreEqual("OOPS! This job does not seem to exist.", job1.ToString());
        }
    }
}
