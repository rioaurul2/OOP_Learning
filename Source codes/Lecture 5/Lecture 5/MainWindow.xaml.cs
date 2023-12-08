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
using static System.Net.Mime.MediaTypeNames;

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

        [Serializable]
        public class TestClass
        {
            public string Name = "default";
            public string Location = "my city";
            public List<int> Collection = new() { 3, 2, 100 };

            public TestClass DeepCopy()
            {
                TestClass tempObject = new();

                tempObject.Name = Name;//immutable
                tempObject.Location = Location;
                tempObject.Collection = Collection.ToList();//Create a deep copy instance with ToList method

                return tempObject;
            }
        }

        private void shallowClonning_Click(object sender, RoutedEventArgs e)
        {
            if(mainList.Count() == 0)
            {
                InitList();
            }

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
            mainList.Clear();
        }

        private void deepCopy_Click(object sender, RoutedEventArgs e)
        {
            if (mainList.Count() == 0)
            {
                InitList();
            }

            List<int> thirdList = mainList.ToList();

            thirdList[2] = 400;

            foreach(int number in thirdList)
            {
                mainList.Add(number);
            }

            TestClass shallowCloneTestClass = new();
            TestClass deepCloneTestClass = new();

            TestClass exampleTestClass = new() 
            { 
                Name = "Marin",
                Location = "Tarian",
                Collection = { 10, 9, 8 }
            };

            //How to make a deep copy of TestClass into defaultTestClass
            shallowCloneTestClass = exampleTestClass;//this is a shallow cloning example

            shallowCloneTestClass.Location = "shallow clone";


            deepCloneTestClass = exampleTestClass.DeepCopy();//this is a deep cloning example

            deepCloneTestClass.Location = "deep clone";
            deepCloneTestClass.Collection[0] = 100000;

            //CloneClassPrint(exampleTestClass);
            //CloneClassPrint(deepCloneTestClass);

            TestClass test3 = exampleTestClass.DeepClone();

            shallowCloneTestClass.Location = "serializable example";
            test3.Collection[0] = 99;
            CloneClassPrint(exampleTestClass);
            CloneClassPrint(test3);
        }

        private void CloneClassPrint(TestClass testClass) 
        {
            listResults.Items.Add(testClass.Name);
            listResults.Items.Add(testClass.Location);
            listResults.Items.Add($"Colection items");
            foreach(int number in testClass.Collection)
            {
                listResults.Items.Add($" * {number}");
            }
        }

        private void refParamDifference_Click(object sender, RoutedEventArgs e)
        {
            int myVal = 100;
            int myValRef = 100;
            string streingExample = "";
            string streingRefExample = "";

            List<int> listTest = new();
            List<int> listTest2 = new();
            List<int> listTestRef = new();
            List<int> listTestNonRef = new();

            for (int i = 0; i < 100; i++)
            {
                Increment(myVal, streingExample, listTest, listTestRef);

                IncrementByRef(ref myValRef, ref streingRefExample, listTest2, ref listTestNonRef);
            }

            listResults.Items.Add((int)myVal);
            listResults.Items.Add(streingExample);
            listResults.Items.Add((int)myValRef);
            listResults.Items.Add(streingRefExample);
        }

        private void Increment( int number, string text, List<int> list, List<int> listNoRef)
        {
            number++;
            text += number + "\t";
            list.Add(number);
            listNoRef = new List<int> { };
            listNoRef.AddRange(list);
            listNoRef.Add(number * number);
        }

        private void IncrementByRef( ref int number, ref string text, List<int> list, ref List<int> listRef)
        {
            number++;
            text += number + "\t";
            list.Add(number);
            listRef = new List<int> { };
            listRef.AddRange(list);
            listRef.Add(number * number);
        }
    }
}
