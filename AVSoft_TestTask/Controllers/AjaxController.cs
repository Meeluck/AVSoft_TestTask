using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVSoft_TestTask.Models;
using AVSoft_TestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace AVSoft_TestTask.Controllers
{

    [Route("test/[controller]")]
    public class AjaxController : Controller
    {
        private IDataProvider dataProvider;
        public AjaxController(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        public IEnumerable<SpecialRequestViewModel> Get()
        {
            return dataProvider.SpecialRequest();
        }
    }
}