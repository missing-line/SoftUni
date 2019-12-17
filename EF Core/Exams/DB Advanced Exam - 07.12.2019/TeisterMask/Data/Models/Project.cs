﻿namespace TeisterMask.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }


        public DateTime? DueDate { get; set; }


        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();


    }
}