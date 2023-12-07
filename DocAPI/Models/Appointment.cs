using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsAppointments.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        //-----------------------------------



      
        [Display(Name ="Patients Name")]
        public int PatientId {get; set;}
        [ForeignKey("PatientId")]
        public virtual Patient? Patient {get; set;}
        //------------------------------------




        [Display(Name = "Select Time Schedule")]
        public int TimeScheduleId { get; set; }
        [ForeignKey("TimeScheduleId")]
        public virtual TimeSchedule? TimeSchedule { get; set; }
        //---------------------------------------------------




        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        [DisplayName("Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        //--------------------------------------------------





    }
}
