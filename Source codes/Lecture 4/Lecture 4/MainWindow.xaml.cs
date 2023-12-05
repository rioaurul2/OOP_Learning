using System;
using System.Runtime;
using System.Windows;

namespace Lecture_4
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

        //Random is a class thath means that is a reference type
        static Random randomNumber = new ();

        //It's a method that will be executed in the stack
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10000000; i++)
            {
                //double is a struct that means that is a value type
                double val = randomNumber.NextDouble();
            }
        }

        public class ReferenceDoubleClassTest
        {
            public double val;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GC.TryStartNoGCRegion(9999999, true))
            {
                try
                {
                    for (int i = 0; i < 10000000; i++)
                    {
                        TestReferenceTypeCall();
                    }
                }
                finally
                {

                }
            }
        }

        private void TestReferenceTypeCall()
        {
            ReferenceDoubleClassTest testVal = new() { val = randomNumber.NextDouble() };
        }
    }
}
