﻿using System.ComponentModel.DataAnnotations;

namespace School.BlazorApp.Data
{
    public class Employee
    {
        [MaxLength(50)]
        public string Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Department { get; set; }
        [MaxLength(100)]
        public string Designation { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
    }
}
