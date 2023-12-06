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

namespace Lecture_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> mainList = new(); 
        Random randomNumbers = new();

        public MainWindow()
        {
            InitializeComponent();
            InitList();
        }

        private void shallowClonning_Click(object sender, RoutedEventArgs e)
        {
            List<int> secondList = mainList;

            secondList[2] = 2000;

            //Error due shallow clonning (The lists have the same reference so when one is changed bhoth are changed)
            //foreach (int number in secondList) {

            //    mainList.Add(number);
            //}

            RefreshListBox();
        }

        private void InitList()
        {
            for(int i = 1; i < 10; i++) 
            {
                mainList.Add(i*10);
            }
        }

        private void RefreshListBox()
        {
            listResults.Items.Clear();
            foreach (int number in mainList) {

                listResults.Items.Add(number);
            }

        }

        private void refreshListBox_Click(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        private void clearBoxList_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
        }
    }
}
