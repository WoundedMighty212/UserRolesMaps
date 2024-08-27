using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserRolesMaps.Models
{
    public class Catagory
    {
        [Key]
        public virtual int CatId { get; set; }
        public virtual string CatDescription { get; set; }
        public virtual List<Events> MyEvents { get; set; }
    }
}
