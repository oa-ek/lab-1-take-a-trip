using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.WebApp.Models;

namespace TakeTripAsp.WebApp.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            LocationLists model = new LocationLists();
            var locations = new List<Locations>()
            {
                new Locations(1, "Bhubaneswar","Bhubaneswar, Odisha", 20.296059, 85.824539),
                new Locations(2, "Hyderabad","Hyderabad, Telengana", 17.387140, 78.491684),
                new Locations(3, "Bengaluru","Bengaluru, Karnataka", 12.972442, 77.580643)
            };
            model.LocationList = locations;
            return View(model);
        }
    }
}
