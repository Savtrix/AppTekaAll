#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AppTeka.Models;

namespace ClientMVC.Controllers
{
    [Authorize]
    public class DrugsController : Controller
    {
        private HttpClient client = new HttpClient();

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<List<Drug>>($"https://localhost:5001/api/drug", new CancellationToken());

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");

            return View(myObject);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return NotFound();
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Employee_Name,Employee_Surename,Employee_Position")] Drug employee)
        {
            return NotFound();
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return NotFound();
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Employee_Name,Employee_Surename,Employee_Position")] Drug employee)
        {
            return NotFound();
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return NotFound();
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return NotFound();
        }

        private bool EmployeeExists(int id)
        {
            return false;
        }
    }
}