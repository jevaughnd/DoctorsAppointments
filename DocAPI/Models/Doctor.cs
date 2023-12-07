using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DoctorsAppointments.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
		//-----------------------------------



		[Column(TypeName = "varchar(50)")]
		[DisplayName("Doctor's Name")]
		public string DoctorName { get; set; }
		//-----------------------------------




        [Column(TypeName = "varchar(100)")]
        [DisplayName("Doctor Description")]
        public string DoctorDescription { get; set; }
        //-----------------------------------




        




    }
}
