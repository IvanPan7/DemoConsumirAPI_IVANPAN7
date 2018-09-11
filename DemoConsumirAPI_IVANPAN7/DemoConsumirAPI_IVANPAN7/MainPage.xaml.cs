using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoConsumirAPI_IVANPAN7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                //App.Current.MainPage.Navigation.PushAsync(new DetailPage { BindingContext = e.SelectedItem as Model.Conferencia });

            };
        }



        public class ItemClass
        {
            public string name { get; set; }
            public string shortDescription{ get; set; }
            public string imageUrl { get; set; }
        }
        private async void OnAdd(object sender, EventArgs e)
        {
            var content = "";
            HttpClient client = new HttpClient();
            var RestURL = "http://192.168.60.140:5000/api/catalog/pies";  
        client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<ItemClass>>(content);
            MyListView.ItemsSource = Items;
        }
        
        private void OnUpdate(object sender, EventArgs e)
        {

        }
        private void OnDelete(object sender, EventArgs e)
        {

        }
    }
}
