using System;
using System.ComponentModel.DataAnnotations;

namespace VerlofsRegistratieSysteem.Models
{
    public class Holiday
    {
        public Holiday() { }
        public Holiday(HolidayViewModel vm)
        {
            HolidayId = vm.HolidayId;
            Name = vm.Name;
            StartDate = vm.StartDate;
            EndDate = vm.EndDate;
        }
        [Key]
        public int HolidayId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
    public class HolidayViewModel : Holiday
    {

    }
}