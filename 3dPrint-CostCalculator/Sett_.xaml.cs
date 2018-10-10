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
using System.Windows.Shapes;

namespace _3dPrint_CostCalculator
{
    /// <summary>
    /// Interaction logic for Sett_.xaml
    /// </summary>
    public partial class Sett_ : Window
    {
        public Sett_()
        {
            InitializeComponent();
            s1.Text = Properties.Settings.Default.electro_tarrif.ToString();
            s2.Text = Properties.Settings.Default.power.ToString();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.electro_tarrif = Convert.ToDouble(s1.Text);
            Properties.Settings.Default.power = Convert.ToInt32(s2.Text);

            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
