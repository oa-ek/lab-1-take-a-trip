using System.ComponentModel.DataAnnotations;

namespace TakeTripAsp.Core.Entity
{
    public class SelectedTour: BaseEntity
    {
        public int TourId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual AppUser User { get; set; }
    }
}
