namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    public class Diagnose
    {
        public Diagnose()
        {
            
        }

        public int DiagnoseId { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }

        public Patient Patient { get; set; }

    }
}
