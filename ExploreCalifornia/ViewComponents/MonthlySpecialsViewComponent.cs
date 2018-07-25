using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.ViewComponents
{
    [ViewComponent]    
    public class MonthlySpecialsViewComponent : ViewComponent
    {
        private readonly SpecialsDataContext _specials;

        public MonthlySpecialsViewComponent(SpecialsDataContext specials)
        {
            this._specials = specials;
        }


        public IViewComponentResult Invoke()
        {
            var specials = this._specials.GetMonthlySpecials();
            return View(specials);
        }
    }
}
