using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xm
{
    public partial class MainPage : ContentPage
    {
        const string url = "https://musealbumsapi.herokuapp.com/albums";
        static HttpClient client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            GetAlbumsAsync();
        }
       
        async void GetAlbumsAsync()
        {

            string content = await client.GetStringAsync(url);
            var listalbums = JsonConvert.DeserializeObject<List<Album>>(content);
            Alb.ItemsSource = listalbums;
        }

        public class Album
        {
            public string idal { get; set; }
            public string nameal { get; set; }
            public string im { get; set; }
        }
    //    <CollectionView x:Name="Albums"
    //            ItemsLayout="VerticalGrid, 2">
    //    <CollectionView.ItemTemplate>
    //        <DataTemplate>
    //            <Grid Padding = "10" >
    //                < Grid.RowDefinitions >
    //                    < RowDefinition Height="35" />
    //                    <RowDefinition Height = "35" />
    //                </ Grid.RowDefinitions >
    //                < Grid.ColumnDefinitions >
    //                    < ColumnDefinition Width="70" />
    //                    <ColumnDefinition Width = "80" />
    //                </ Grid.ColumnDefinitions >
    //                < Image Grid.RowSpan="2"
    //                   Source="{Binding im}"
    //                   Aspect="AspectFill"
    //                   HeightRequest="60"
    //                   WidthRequest="60" />
    //                <Label Grid.Column="1"
    //                   Text= "{Binding nameal}"
    //                   FontAttributes= "Bold"
    //                   LineBreakMode= "TailTruncation" />
    //            </ Grid >
    //        </ DataTemplate >
    //    </ CollectionView.ItemTemplate >
    //</ CollectionView >
    }
}
