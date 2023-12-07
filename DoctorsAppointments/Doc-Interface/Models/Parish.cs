using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Doc_Interface.Models
{
    public class Parish
    {
       
        public int Id { get; set; }


        [DisplayName("Parish")]
        public string ParishName { get; set; }
    }
}
