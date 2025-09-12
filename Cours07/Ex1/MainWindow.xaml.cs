using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
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

namespace Ex1
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text == "" || nbAge.Value == 0 || pbPassword.Password == "" || cmbSub.SelectedIndex == -1)
            {
                btnSubmit.Content = "Champs incomplets";
            }
            else
            {
                Membre membre = new Membre(tbxName.Text, (int) nbAge.Value, pbPassword.Password, cmbSub.SelectedItem.ToString(), (bool) swActif.IsOn);
                tblResult.Text = membre.ToString();
            }
        }
    }
}
