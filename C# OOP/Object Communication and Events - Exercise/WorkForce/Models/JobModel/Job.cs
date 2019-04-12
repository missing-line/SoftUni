namespace WorkForce
{
    using System;
    public delegate void JobStatus(JobsList argm);

    public class Job
    {
        private string name;
        private int hoursOfWorkRequired;
        private Employee employee;

        public event EventHandler<JobArgumnets> JobDone;

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.employee = employee;
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int HoursOfWorkRequired
        {
            get => this.hoursOfWorkRequired;
            private set => this.hoursOfWorkRequired = value;
        }

        public void Update()
        {
            this.hoursOfWorkRequired -= this.employee.WorkHoursPereek;
            if (this.HoursOfWorkRequired <= 0)
            {
                OnComplate();
            }
        }

        public virtual void OnComplate()
        {
            Console.WriteLine($"Job {this.Name} done!");

            this.JobDone?.Invoke(this, new JobArgumnets(this));
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.hoursOfWorkRequired}";
        }
    }
}

