namespace TeisterMask.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"[A-Za-z0-9]+")]
        [StringLength(40, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        public ICollection<EmployeeTask> EmployeesTasks { get; set; } = new HashSet<EmployeeTask>();
        //•	Username - text with length[3, 40]. Should contain only lower or upper case letters and/or digits. (required)



    }
}
