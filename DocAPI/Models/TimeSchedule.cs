using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DoctorsAppointments.Models
{
	public class TimeSchedule
	{
		[Key]
		public int Id { get; set; }



        [Display(Name = "Doctors Name")]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor? Doctor { get; set; }
        //------------------------------------



        [Column(TypeName = "varchar(100)")]
        [DisplayName("Schedule Description")]
        public string ScheduleDescription { get; set; }
        //--------------------------------------


        
		[DisplayName("Start Time")]
		public DateTime StartTime { get; set; }
		//-----------------------------------



		[DisplayName("End Time")]
		public DateTime EndTime { get; set; }
		//----------------------------------
		

	}
}
