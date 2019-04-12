namespace WorkForce
{
    using System.Collections.Generic;
    public class JobsList : List<Job>
    {
        public void Done(object sender, JobArgumnets jobArgumnets)
        {
            jobArgumnets.Job.JobDone -= this.Done;
            this.Remove(jobArgumnets.Job);
        }
    }
}
