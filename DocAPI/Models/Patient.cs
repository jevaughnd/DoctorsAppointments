using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsAppointments.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        //-----------------------------------

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        //-----------------------------------


        
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }
        //-----------------------------------



        [Column(TypeName = "varchar(50)")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        //-----------------------------------



        [Column(TypeName = "varchar(15)")]
        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }
        //-----------------------------------



        [Column(TypeName = "varchar(50)")]
        public string Street { get; set; }
        //-----------------------------------



        [Column(TypeName = "varchar(50)")]
        public string Town { get; set; }
        //--------------------------------



        //parish
        [Display(Name = "Parish")]
        public int ParishId { get; set; }
        [ForeignKey("ParishId")]
        public virtual Parish? Parish { get; set; }
        //-----------------------------------------



    }
}
