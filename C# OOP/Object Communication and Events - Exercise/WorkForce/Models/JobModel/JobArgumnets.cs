namespace WorkForce
{
    using System;
    public class JobArgumnets : EventArgs
    {
        public JobArgumnets(Job job)
        {
            this.Job = job;
        }

        public Job Job { get; }
    }
}
