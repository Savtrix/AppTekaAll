using AppTeka.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientAppTeka.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        private List<Drug> drugList;
        private ObservableCollection<KeyValuePair<string, int>> orderList = new ObservableCollection<KeyValuePair<string, int>>();

        public Order()
        {
            LoadData();
            InitializeComponent();
            list.ItemsSource = orderList;
        }

        private async void LoadData()
        {
            var Odrugs = new Operations<Drug>();
            drugList = await Odrugs.GetMyObjectAsync();

            drugs.ItemsSource = drugList.Select(x => x.Name);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (drugs.SelectedItem == null) return;
            if (orderList.Where(x => x.Key == drugs.SelectedItem as string).Select(x => x).Count() > 0)
            {
                var tmp = orderList.First(x => x.Key == drugs.SelectedItem as string).Value;
                tmp += Convert.ToInt32(count.Text);
                orderList.Remove(orderList.First(x => x.Key == drugs.SelectedItem as string));
                orderList.Add(new KeyValuePair<string, int>(drugs.SelectedItem as string, tmp));
            }
            else
                orderList.Add(new KeyValuePair<string, int>(drugs.SelectedItem as string, Convert.ToInt32(count.Text)));
        }
    }
}