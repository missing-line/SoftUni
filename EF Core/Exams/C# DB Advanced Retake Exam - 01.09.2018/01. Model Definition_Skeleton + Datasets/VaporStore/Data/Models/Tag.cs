﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace VaporStore.Data
{
    using VaporStore.Data.Models;
    public class Tag
    {
        public Tag()
        {
            this.GameTags = new List<GameTag>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }


        public ICollection<GameTag> GameTags { get; set; }
    }
}
