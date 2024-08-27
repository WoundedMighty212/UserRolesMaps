using System.ComponentModel;

namespace UserRolesMaps.Models
{
    public class Catagory
    {
        public virtual int CatId { get; set; }
        public virtual string CatDescription { get; set; }
        public virtual List<Events> MyEvents { get; set; }
    }
}
