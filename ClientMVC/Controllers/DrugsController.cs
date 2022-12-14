#nullable disable

using AppTeka.Models;
using ClientMVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ClientMVC.Controllers
{
    [Authorize]
    public class DrugsController : Controller
    {
        // GET: Drugss
        public async Task<IActionResult> Index()
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<List<Drug>>($"{ControllerConstants.DefaultURI}/api/drug", new CancellationToken());

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");

            return View(myObject);
        }

        // GET: Drugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return NotFound();
        }

        // GET: Drugs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,NeedPrescribtion")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(drug);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var client = new HttpClient();
                using (client)
                {
                    await client.PostAsync($"{ControllerConstants.DefaultURI}/api/Drug", httpRequestMessage.Content);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(drug);
        }

        // GET: Drugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<Drug>($"{ControllerConstants.DefaultURI}/api/drug/{id}", new CancellationToken());

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");

            return View(myObject);
        }

        // POST: Drugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,NeedPrescribtion")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(drug);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var client = new HttpClient();
                using (client)
                {
                    await client.PutAsync($"{ControllerConstants.DefaultURI}/api/Drug", httpRequestMessage.Content);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(drug);
        }

        // GET: Drugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var client = new HttpClient();
            using (client)
            {
                await client.DeleteAsync($"{ControllerConstants.DefaultURI}/api/Drug/{id}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}