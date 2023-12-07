using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Doc_Interface.Models.ViewModels
{
    public class PatientVM
    {
        public int Id { get; set; }
        //-----------------------------------


        [DisplayName("Full Name")]
        public string FullName { get; set; }
        //-----------------------------------



        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }
        //-----------------------------------




        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        //-----------------------------------




        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }
        //-----------------------------------




        public string Street { get; set; }
        //-----------------------------------


        public string Town { get; set; }
        //--------------------------------



        //parish
        [Display(Name = "Parish")]
        public int ParishId { get; set; }
        [ForeignKey("ParishId")]
        public virtual Parish? Parish { get; set; }
        //-----------------------------------------


        public List<SelectListItem>? ParishList { get; set; }
        public int SelectedParishId { get; set; }
        

    }
}
