using csgoitems.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace csgoitems.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        private async void Observe_Click(object sender, RoutedEventArgs e)
        {
            String name = textBoxSearch.Text;
            if (name != null)
            {
                Items myItem = await ItemsLogic.GetItems(name);
                if(myItem.message != null)
                {
                    itemTextBlock.Text = ((String)myItem.message).ToString();
                }
                else
                {
                    itemTextBlock.Text = ((String)myItem.lowest_price.ToString());
                }
                
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
