using ST10070933PROG6221POE.Models;
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
    public partial class AddStepDialog : Window  
    {
        public Step NewStep { get; private set; }

        public AddStepDialog()
        {
            InitializeComponent();
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e) //adding the different steps to make ingredients 
        {
            NewStep = new Step
            {
                Description = StepDescriptionTextBox.Text
            };

            DialogResult = true;
        }
    }
}