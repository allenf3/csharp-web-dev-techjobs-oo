using System;
using System.Reflection;
using System.Text;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            bool noneSet = true;

            foreach (PropertyInfo property in typeof(Job).GetProperties())
            {
                if (property.Name == "Id" )
                {
                    continue;
                }
                if (property.GetValue(this) != null)
                {
                    noneSet = false;
                }
            }

            if (noneSet)
            {
                return "OOPS! This job does not seem to exist.";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");
            sb.Append($"ID: { Id }\r\n");
            sb.Append($"Name: { Name?? "Data not available" }\r\n");
            sb.Append($"Employer: { (EmployerName != null ? EmployerName.Value :  "Data not available") }\r\n");
            sb.Append($"Location: { (EmployerLocation != null ? EmployerLocation.Value : "Data not available") }\r\n");
            sb.Append($"Position Type: { (JobType != null ? JobType.Value : "Data not available") }\r\n");
            sb.Append($"Core Competency: { (JobCoreCompetency != null ? JobCoreCompetency.Value : "Data not available") }\r\n");
            return sb.ToString();
        }
    }
}
