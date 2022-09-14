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
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetailss
        public async Task<IActionResult> Index()
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<List<OrderDetails>>($"{ControllerConstants.DefaultURI}/api/orderdetails", new CancellationToken());

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");

            return View(myObject);
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return NotFound();
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,DrugId,Quantity")] OrderDetails OrderDetail)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(OrderDetail);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var client = new HttpClient();
                using (client)
                {
                    await client.PostAsync($"{ControllerConstants.DefaultURI}/api/orderdetail", httpRequestMessage.Content);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(OrderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<OrderDetails>($"{ControllerConstants.DefaultURI}/api/orderdetails/{id}", new CancellationToken());

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");

            return View(myObject);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,DrugId,Quantity")] OrderDetails OrderDetail)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(OrderDetail);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var client = new HttpClient();
                using (client)
                {
                    await client.PutAsync($"{ControllerConstants.DefaultURI}/api/orderdetails", httpRequestMessage.Content);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(OrderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var client = new HttpClient();
            using (client)
            {
                await client.DeleteAsync($"{ControllerConstants.DefaultURI}/api/OrderDetail/{id}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}