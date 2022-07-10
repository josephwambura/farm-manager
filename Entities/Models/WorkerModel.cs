﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class WorkerModel
    {
        [Required]
        [MaxLength(20)]
        public string WorkerName { get; set; }

        [Required]
        [Phone]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
    }
}
