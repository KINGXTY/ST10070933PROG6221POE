using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10070933PROG6221POE
{
    public partial class ScaleRecipeDialog : Window  //scale recipe by 0.5 , 2 , 3
    {
        public double ScaleFactor { get; private set; }

        public ScaleRecipeDialog()
        {
            InitializeComponent();
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ScaleFactorTextBox.Text, out double scaleFactor) && (scaleFactor == 0.5 || scaleFactor == 2 || scaleFactor == 3))
            {
                ScaleFactor = scaleFactor;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid scale factor. Please enter 0.5, 2, or 3.");
            }
        }
    }
}
