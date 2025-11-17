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

namespace Cours19___Dates
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

        private void BtnAfficherDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateHeure = new DateTime(2024, 6, 15, 14, 30, 0);
            TblDate.Text = dateHeure.ToString("F");
        }

        private void DatePicker1_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {

        }

        private void TimePickerDemo_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {

        }
    }
}
