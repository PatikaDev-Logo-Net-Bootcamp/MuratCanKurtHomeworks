﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Homework4.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

//        [Required(ErrorMessage = "CreatedBy alanı zorunludur")]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
