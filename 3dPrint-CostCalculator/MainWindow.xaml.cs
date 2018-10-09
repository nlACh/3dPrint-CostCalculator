using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3dPrint_CostCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Event handler for the settings button
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Den.Text = "0";
            Cost.Text = "0";
            Size.Text = "0";
            Dia.Text = "0";
            Sett_ sett_ = new Sett_();
            sett_.Show();
            //this.Hide();
        }
    }
}
