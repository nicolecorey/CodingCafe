using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CodingCafe.Models
{
    public enum Gender
    {
        Male,
        Female,
        Nonbinary
    }
    public class Customers
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Please enter your first name (max 30 characters).")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Please enter your Last name (max 30 characters).")]
        public string? LastName { get; set; }

        [Display(Name = "Gender")]
        public Gender? GenderIdentity { get; set; }

        [StringLength(50, ErrorMessage = "Please enter your address (max 50 characters)")]
        public string? Address { get; set; }

        [StringLength(30, ErrorMessage = "Please enter your city (max 30 characters)")]
        public string? City { get; set; }

        [StringLength(2, ErrorMessage = "Please enter your state (2 characters, example: NY")]
        public string? State { get; set; }

        [StringLength(10, ErrorMessage = "Please enter your zipcode (max 10 numbers)")]
        public string? Zip { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Phone")]
        public string? Phone { get; set; }

    }
}
