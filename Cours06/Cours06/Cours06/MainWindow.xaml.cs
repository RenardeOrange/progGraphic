using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cours06
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] colors = { "rouge", "vert", "bleu" };
            cmbDemo.ItemsSource = colors;
            cmbDemo.SelectedIndex = 0;
        }

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {
            tblDemo.Text = pbDemo.Password;
        }

        private void swDemo_Toggled(object sender, RoutedEventArgs e)
        {
            tblDemo.Text = (swDemo.IsOn) ? "On" : "Off";
        }

        private void sldDemo_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            tblDemo.FontSize = sldDemo.Value;
        }

        private void cmbDemo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void nbxDemo_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            nbxDemo.Margin = new Thickness(nbxDemo.Value);
        }
    }
}
