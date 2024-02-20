using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=SignupDb; Integrated Security=true;";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckboxDemo(string name, bool isAmazing)
        {
            return View(new CheckboxDemoViewModel
            {
                Name = name,
                IsAmazing = isAmazing
            });
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Signup signup)
        {
            var mgr = new SignupDb(_connectionString);
            mgr.Add(signup);
            return Redirect("/home/signup");
        }
    }
}

/* Create an application to manage a list of cars. Each car has the following properties:
 * 
 * Make
 * Model
 * Year
 * Price
 * CarType (this should be an enum of type CarType with the values SUV/Sedan/Supercar)
 * HasLeatherSeats (bool)
 * 
 * On the home page, there should be a table of all the cars in the database. In the 
 * column where you show whether or not the car has leather seats, use an icon
 * either a check or x to make it more exciting :) Icons can be found here:
 * 
 *  https://icons.getbootstrap.com/
 * you'll need to add this link tag to your layout file:
 * <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
 *
 * On top of the table, have a link that takes you to a page to add a new car.
 * On that form, have textboxes for make/model/year/price. Then, have a select for
 * car type (hardcode the values). Beneath that, have a checkbox for "Has leather seats".
 * 
 * When the form page loads, the submit button should be disabled. Then, using javascript,
 * have some code that only re-enables the button if the form is valid. A valid form
 * means that all textboxes have a value, and that the car type dropdown has an option
 * chosen.
 * 
 * Next, again via JS, when the user selects Supercar from the CarType dropdown,
 * the has leather seats checkbox should automatically become checked, as well as 
 * disabled, (since all supercars have leather seats).
 *
 * Also, the submit button should be disabled when the page loads, and should only
 * become enabled when each one of the fields get populated. To find if the select
 * dropdown has a value, you can use the .val() function in jQuery on the select. 
 * Also, to figure out if a select changed, you can do something like 
 * $("#my-select").on('change', function() { ....
 *
 * Finally, on the home page, in the header of the table - in the Year column, there should
 * be a link (styled like a button if you want) that when clicked, refreshes the page and
 * displays the cars sorted by year. This time, the button should have an arrow pointing
 * in the opposite direction. When clicked again, it should refresh the page again,
 * and resort it descending (Hint: Pay attention to the query string on the live site).
 * 
 * Good luck! */