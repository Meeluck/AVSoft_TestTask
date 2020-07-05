using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVSoft_TestTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AVSoft_TestTask.Pages
{
    public class AddCounterModel : PageModel
    {
        private IDataProvider dataProvider;
        public AddCounterModel(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public void OnGet()
        {
            ViewData["Message"] = "Заполнеите поля";
        }
        public IActionResult OnPost(int key, int value)
        {
            if(key<1)
            {
                ViewData["Message"] = "Ключ не может быть меньше 1";
                return Page();
            }
            dataProvider.AddData(key, value);
            return RedirectToPage("Index");
        }
    }
}