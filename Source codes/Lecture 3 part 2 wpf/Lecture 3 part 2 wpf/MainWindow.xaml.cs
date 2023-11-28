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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lecture_3_part_2_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            newValueOfListBox.Visibility = Visibility.Hidden;
            btnSaveNewValueOfListBox.Visibility = Visibility.Hidden;
        }

        private void BtnJoinStrings_Click(object sender, RoutedEventArgs e)
        {
            List<string> inputs = new() { txt1.Text, txt2.Text};

            var mergedInput = string.Join(" ", inputs);

            MessageBox.Show(mergedInput);
        }

        private void splitText_Click(object sender, RoutedEventArgs e)
        {
            int index = -1;

            if (Int32.TryParse(insertPosition.Text, out index) == false)  {
                index = -1;
            }

            string myMainInput = txtSplitBox.Text;
            List<string> splittedText = myMainInput.Split(txtSplitParameter.Text).ToList();

            foreach (string word in splittedText) 
            {
                if (index > -1)
                {

                    lstSplitResults.Items.Insert(index, word);
                }
                else
                {
                    lstSplitResults.Items.Add(word);
                }
            }
        }

        private void splitBoxClear_Click(object sender, RoutedEventArgs e)
        {
            lstSplitResults.Items.Clear();
        }

        private void lstSplitResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newValueOfListBox.Visibility = Visibility.Visible;
            btnSaveNewValueOfListBox.Visibility = Visibility.Visible;
        }

        private void btnSaveNewValueOfListBox_Click(object sender, RoutedEventArgs e)
        {
            if(lstSplitResults.SelectedIndex > -1)
            {
                lstSplitResults.Items[lstSplitResults.SelectedIndex] = newValueOfListBox.Text;
            }
            lstSplitResults.SelectedIndex = -1;
            newValueOfListBox.Visibility = Visibility.Hidden;
            btnSaveNewValueOfListBox.Visibility = Visibility.Hidden;
        }

        private void nextWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new();
            window.Hide();
            SecondWindow mySecondWindow = new();
            mySecondWindow.Show();
        }
    }
}
