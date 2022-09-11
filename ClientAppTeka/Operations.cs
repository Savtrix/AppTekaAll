using AppTeka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientAppTeka
{
    internal class Operations<T>
    {
        
        private string name = typeof(T).Name.ToLower();


        public async Task<List<T>> GetMyObjectAsync(CancellationToken cts = default)
        {
            var _httpClient = new HttpClient();
            // http get request to a rest api address
            var myObject = await _httpClient.GetFromJsonAsync<List<T>>($"https://localhost:5001/api/{name}", cts);

            // raise error if deserialization was not possible
            if (myObject == null)
                throw new Exception("Oops... Something went wrong");
            return myObject;
        }
    }
}