using System.ComponentModel.DataAnnotations;

namespace VerlofsRegistratieSysteem.Models
{
    public class Schedule
    {
        public Schedule() { }
        public Schedule(ScheduleViewModel vm)
        {
            ScheduleId = vm.ScheduleId;
        }
        [Key]
        public int ScheduleId { get; set; }
    }
    public class ScheduleViewModel : Schedule
    {

    }
}