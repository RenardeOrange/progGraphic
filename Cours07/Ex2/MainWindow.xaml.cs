using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Ex2
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

        private void btnCalcul_Click(object sender, RoutedEventArgs e)
        {
            if (tbxNom.Text != "" && tbxTelephone.Text != "" && tbxAdresse.Text != "" && tbxEmail.Text != "" && tbxDescription.Text != "")
            {
                tblResultatNom.Text = tbxNom.Text;
                tblResultatEmail.Text = tbxEmail.Text;
                tblResultatAdresse.Text = tbxAdresse.Text;
                tblResultatTelephone.Text = tbxTelephone.Text;
                tblResultatDescription.Text = tbxDescription.Text;
                imgPhoto.Source = new BitmapImage(new Uri(tbxImage.Text));
            }
            else
            {
                btnCalcul.Content = "Veuillez remplir tous les champs";
            }
        }
    }
}
