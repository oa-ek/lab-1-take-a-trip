using System.ComponentModel.DataAnnotations;
using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class SelectedTour : BaseEntity<int>
    {
        public int TourId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual AppUser User { get; set; }
    }
}
