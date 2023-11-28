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

namespace Lecture_3_part_2_wpf
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        Dictionary<int, int> generatedNumbers = new();

        private void btnNumbersGenerator_Click(object sender, RoutedEventArgs e)
        {
            Random randomGenerator = new();

            for (int i = 0; i < 100; i++)
            {
                int randomNumber = randomGenerator.Next(1, 100);

                if (generatedNumbers.ContainsKey(randomNumber)) {
                    generatedNumbers[randomNumber] += 1;
                }
                else
                {
                    generatedNumbers.Add(randomNumber, 1);
                }

                UpdateStatistics();

            }

        }

        void UpdateStatistics()
        {
            lstBoxStatictics.Items.Clear();
            lstBoxStatictics.Items.Add($"number of elements in dictionary:{generatedNumbers.Count}");
            lstBoxStatictics.Items.Add($"First key in the dictionary:{generatedNumbers.Keys.FirstOrDefault()}");
            lstBoxStatictics.Items.Add($"Last key in the dictionary:{generatedNumbers.Keys.LastOrDefault()}");
            lstBoxStatictics.Items.Add($"Biggest key in the dictionary:{generatedNumbers.Keys.OrderByDescending(key=> key).FirstOrDefault()}");
            lstBoxStatictics.Items.Add($"Smallest key in the dictionary:{generatedNumbers.Keys.OrderBy(key => key).FirstOrDefault()}");
            lstBoxStatictics.Items.Add($"Sum of keys in the dictionary:{generatedNumbers.Keys.Sum(key => key)}");
        }

        private void previousWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new ();
            window.Show();
        }
    }
}
