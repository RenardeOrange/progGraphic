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

        private void btnCalcul_Click(object sender, RoutedEventArgs e)
        {
            double noteLab = Convert.ToDouble(tbxLab.Text)* 0.20;
            double noteExamMiSession = Convert.ToDouble(tbxExamMiSession.Text) * 0.30;
            double noteExamFinal = Convert.ToDouble(tbxExamenFinal.Text) * 0.50;
            tblNoteFinal.Text = $"Laboratoires : {noteLab} \nExamen Mi-Session : {noteExamMiSession} \nExamen Final : {noteExamFinal} \nNote Finale : {noteLab+noteExamMiSession+noteExamFinal} \n";
        }
    }
}
