using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerlofsRegistratieSysteem.Models
{
    public class Absence
    {
        public Absence() { }
        public Absence(AbsenceViewModel vm)
        {
            AbsenceId = vm.AbsenceId;
            StartDate = vm.StartDate;
            EndDate = vm.EndDate;
            AbsenceHours = vm.AbsenceHours;
            Employee = vm.Employee;
        }

        [Key]
        public int AbsenceId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int AbsenceHours { get; set; } // Calculated upon creation of Absence, in case of schedules changing
        public virtual Employee Employee { get; set; }
    }
    [NotMapped]
    public class AbsenceViewModel : Absence
    {
        public int AbsenceFutureHours
        {
            get
            {
                //TODO Calculate future hours depending on selected date + hours formula
                return 0;
            }
        }
        public int AbsencePendingHours
        {
            get
            {
                //TODO Calculate pending hours by subtracting pending absences
                return 0;
            }
        }
    }
}