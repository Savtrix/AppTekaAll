using AppTeka.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientAppTeka
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var acc = new Account()
            {
                Id = Login.Text,
                Password = Password.Password
            };

            string json = JsonConvert.SerializeObject(acc);
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001");

                

                var result = await client.PostAsync("/api/Account", httpRequestMessage.Content);
                var resultContent = result.IsSuccessStatusCode;
                if (resultContent)
                    DialogResult = true;
                // this.Close();
            }
        }
    }
}