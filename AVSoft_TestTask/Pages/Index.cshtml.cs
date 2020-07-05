using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVSoft_TestTask.Models;
using AVSoft_TestTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AVSoft_TestTask.Pages
{
    public class IndexModel : PageModel
    {
        private IDataProvider dataProvider;

        public List<Counter> Counters { get; set; }

        public IndexModel(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public void OnGet()
        {
            Counters = dataProvider.GetCounters();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("AddCounter");
        }
        public IActionResult OnPostRazorView()
        {
            return RedirectToAction("SpecialRequest", "Query");
        }


    }
}