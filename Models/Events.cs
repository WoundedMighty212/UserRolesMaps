using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserRolesMaps.Models
{
    public class Events
    {
        [Key]
        public virtual int EventId { get; set; }
        public virtual string UserId { get; set; }
        public virtual string EventLat { get; set; }
        public virtual string EventLong { get; set; }
        public virtual string EventURL { get; set; }
        public virtual DateTime EventDate { get; set; }
        public virtual int CatId { get; set; }
        public virtual Catagory EventCategory { get; set; }
    }
}
