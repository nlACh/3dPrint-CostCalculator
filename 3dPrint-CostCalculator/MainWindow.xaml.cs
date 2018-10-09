using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
        Double size, cost, density, dia, cpl, cpg;

        //The following is used to limit only numeric values in the textboxes
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool isAllowed(String text)
        {
            //This function checks if the text inside the textbox is fully numeric or not
            //If there is a match with the regex then it returns true, but the entire expression
            //makes it false. This is returned and the value is taken in by Check_Inout()
            return !_regex.IsMatch(text);
        }
        //This is linked to @PreviewTextInput property of textboxes in corresponding xml
        private void Check_Input(object sender, TextCompositionEventArgs e)
        {
            //If isAllowed() returns false, then there are only numeric values
            //So the expression inverts the return value
            e.Handled = !isAllowed(e.Text);
        }

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

        private void Cal_Click(object sender, RoutedEventArgs e)
        {
            //The following 4 lines get values from textboxes
            try
            {
                size = Convert.ToDouble(Size.Text);
                cost = Convert.ToDouble(Cost.Text);
                density = Convert.ToDouble(Den.Text);
                dia = Convert.ToDouble(Dia.Text);
            }
            catch(Exception ex)
            {
                Size.Text = ex.ToString();
            }

            //Now use these values to find cost per length and cost per gram
            cpl = CPL(size, cost, density, dia);
            cpg = cost / (size*1000); //in terms of currency per gram

            /* Reflect those values temporarily to the UI
             * Later we will just use these values!
             */
            Cpg.Text = cpg.ToString()+"per gram";
            Cpl.Text = cpl.ToString()+"per meter";
        }

        private Double CPL(Double si, Double c, Double den, Double di)
        {
            Double area = Math.PI * (di / 10)*(di / 10)/4; //converted to cm2
            Double massPerLength = area * den; //grams per cm
            Double length = (si * 1000) / massPerLength; //converted Kg to grams and then get total length in cm
            Double cp_l = c / (length / 1000); //length to meter then cost per meter
            return cp_l;
        }
    }
}
