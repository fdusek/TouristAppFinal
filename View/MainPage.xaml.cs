using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TouristApp_V3.Model;
using TouristApp_V3.View;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TouristApp_V3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int SelectedCategoryID;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void b1_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void b2_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backButton_Click_1(object sender, RoutedEventArgs e)
        {
            //jump to page with tablesettings
            this.Frame.Navigate(typeof(TableSettings));
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            //jump to page with order overview
            this.Frame.Navigate(typeof(OrderPage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddCategoryPage));

            if (Listview1.SelectedItems.Count > 0)
            {
                SelectedCategoryID = Listview1.SelectedItems.Cast<Category>().First<Category>().ID;
            }
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItemPage));
        }
    }
}

