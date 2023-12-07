using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Doc_Interface.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        //-----------------------------------


        [DisplayName("Doctor's Name")]
        public string DoctorName { get; set; }
        //-----------------------------------


        [DisplayName("Doctor Description")]
        public string DoctorDescription { get; set; }
        //-----------------------------------



    }
}
