using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarouselViewTest
{
    public partial class MainPage : ContentPage
    {
        CarouselView carouseView;

        public MainPage()
        {
            InitializeComponent();

            Data = new ObservableCollection<int>();
            for (int i = 0; i < 5; i++)
            {
                Data.Add(i);
            }
            carouseView = new CarouselView
            {
                Position = Data.Count - 1,
                VerticalOptions = LayoutOptions.Start,
                Loop = false,

                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label()
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                    };
                    label.SetBinding(Label.TextProperty, ".");

                    return label;
                })
            };
            carouseView.ItemsSource = Data;
            carouseView.CurrentItemChanged += CarouseViewt_CurrentItemChanged;
            Content = carouseView;
        }

        public ObservableCollection<int> Data { get; set; }

        private void CarouseViewt_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            if (e.PreviousItem == null)
                return;

            for (int i = 0; i < 5; i++)
            {
                Data.Insert(0, Data[0] - 1);
            }
        }
    }
}
