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
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void chkOption_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chkOption_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void rbCouleurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rbCouleurs.SelectedItem == null)
            {
                tblHelloWorld.Text = "Veuillez sélectionner une couleur.";
            }
            else
            {
                tblHelloWorld.Text = "Hello, World!";
                switch (rbCouleurs.SelectedItem as string)
                {
                    case "Jaune":
                        tblHelloWorld.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 255, 255));
                        break;
                    case "Vert":
                        tblHelloWorld.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 128, 0));
                        break;
                    case "Blanc":
                        tblHelloWorld.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255));
                        break;
                    default:
                        tblHelloWorld.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));
                        break;
                }
            }
        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new("ms-appx:///Assets/Wide310x150Logo.scale-200.png");
            imgLogo.Source = new BitmapImage(uri);
        }
    }
}
