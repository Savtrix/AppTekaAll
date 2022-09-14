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
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using ClientMVC.Models;
using System.Globalization;
using ClientMVC.Data;

namespace ClientMVC.Controllers
{
    [Authorize]
    public class ShopAssistantsController : Controller
    {
        // GET: ShopAssistantss
        public async Task<IActionResult> Index()
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<List<ShopAssistant>>($"{ControllerConstants.DefaultURI}/api/shopassistant", new CancellationToken());

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");

            return View(myObject);
        }

        // GET: ShopAssistants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return NotFound();
        }

        // GET: ShopAssistants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopAssistants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price")] ShopAssistant ShopAssistant)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(ShopAssistant);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var client = new HttpClient();
                using (client)
                {
                    await client.PostAsync($"{ControllerConstants.DefaultURI}/api/shopassistant", httpRequestMessage.Content);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ShopAssistant);
        }

        // GET: ShopAssistants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<ShopAssistant>($"{ControllerConstants.DefaultURI}/api/shopassistant/{id}", new CancellationToken());

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");

            return View(myObject);
        }

        // POST: ShopAssistants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ShopAssistant ShopAssistant)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(ShopAssistant);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var client = new HttpClient();
                using (client)
                {
                    await client.PutAsync($"{ControllerConstants.DefaultURI}/api/shopassistant", httpRequestMessage.Content);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ShopAssistant);
        }

        // GET: ShopAssistants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var client = new HttpClient();
            using (client)
            {
                await client.DeleteAsync($"{ControllerConstants.DefaultURI}/api/shopassistant/{id}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}