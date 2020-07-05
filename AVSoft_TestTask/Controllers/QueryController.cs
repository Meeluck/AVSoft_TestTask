using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVSoft_TestTask.Models;
using AVSoft_TestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace AVSoft_TestTask.Controllers
{
    public class QueryController : Controller
    {
        private IDataProvider data;
        public QueryController(IDataProvider data)
        {
            this.data = data;
        }
        public IActionResult SpecialRequest()
        {
            List<SpecialRequestViewModel> specialRequests = data.SpecialRequest();
            return View(specialRequests);
        }
        public IActionResult SpecialRequestAjax()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GoBack()
        {
            return Redirect("~/Index");
        }

    }
}