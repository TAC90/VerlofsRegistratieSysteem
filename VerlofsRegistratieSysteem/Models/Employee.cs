using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerlofsRegistratieSysteem.Models
{
    public enum ContractType
    {
        [Display(Name = "40 uren per week")] Hours40,
        [Display(Name = "32 uren per week")] Hours32,
        [Display(Name = "24 uren per week")] Hours24
    }

    public class Employee
    {
        public Employee(EmployeeViewModel vm)
        {
            EmployeeID = vm.EmployeeID;
            Role = vm.Role;
            EMail = vm.EMail;
            FirstName = vm.FirstName;
            LastName = vm.LastName;
            DateOfBirth = vm.DateOfBirth;
            ContractType = vm.ContractType;
            HoursUsed = vm.HoursUsed;
            Absences = vm.Absences;
            Schedule = vm.Schedule;
        }
        public Employee()
        {
            Absences = new HashSet<Absence>();
        }
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        //public ApplicationRole role { get; set; }
        public string Role { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail Address")]
        public string EMail { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public ContractType ContractType { get; set; }
        [Required]
        public int HoursUsed { get; set; }

        public virtual ICollection<Absence> Absences { get; set; }
        public Schedule Schedule { get; set; }
    }
    [NotMapped]
    public class EmployeeViewModel : Employee
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Opnieuw Wachtwoord")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public string SelectedRoleId { get; set; }
    }
}
