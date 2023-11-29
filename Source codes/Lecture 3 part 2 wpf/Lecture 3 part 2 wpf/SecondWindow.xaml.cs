using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;


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
            sortOrder.Items.Add("Orber by");
            sortOrder.Items.Add("Orber by keys ascending");
            sortOrder.Items.Add("Orber by keys descending");
            sortOrder.Items.Add("Orber by values ascending");
            sortOrder.Items.Add("Orber by values descending");
            sortOrder.SelectedIndex = 0;

            fileWritingMethod.Items.Add("Orber by writing method");
            fileWritingMethod.Items.Add("use Write all lines");
            fileWritingMethod.Items.Add("use streamWriter method");
            fileWritingMethod.Items.Add("use stringBuilder method");
            fileWritingMethod.SelectedIndex = 0;
        }

        Dictionary<int, int> generatedNumbers = new();

        private void btnNumbersGenerator_Click(object sender, RoutedEventArgs e)
        {
            Random randomGenerator = new();

            generatedNumbers.Clear();

            for (int i = 0; i < 10000; i++)
            {
                int randomNumber = randomGenerator.Next(1, 10000);

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

        private void orderBy_Click(object sender, RoutedEventArgs e)
        {
            switch (sortOrder.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("No sorting option selected");
                    break;
                case 1:
                    generatedNumbers = generatedNumbers.OrderBy(val => val.Key).ToDictionary(val=> val.Key, val=> val.Value);
                    break;
                case 2:
                    generatedNumbers = generatedNumbers.OrderByDescending(val => val.Key).ToDictionary(val => val.Key, val => val.Value);
                    break;
                case 3:
                    generatedNumbers = generatedNumbers.OrderBy(val => val.Value).ToDictionary(val => val.Key, val => val.Value);
                    break;
                case 4:
                    generatedNumbers = generatedNumbers.OrderByDescending(val => val.Value).ToDictionary(val => val.Key, val => val.Value);
                    break;
            }
        }

        private void writeToFile_Click(object sender, RoutedEventArgs e)
        {
            switch (fileWritingMethod.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("No writing method selected");
                    break;
                case 1:
                    WriteFileWithAllLines();
                    break;
                case 2:
                    WriteFileWithStreamWriterNoAutoFlush();
                    WriteFileWithStreamWriterAutoFlush();
                    break;
                case 3:
                    WriteStringBuilder();
                    break;
            }

            var exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Process.Start("explorer.exe",exePath);
            GC.Collect();
        }

        private void WriteFileWithAllLines()
        {
            string fileName = "WriteAllLines.txt";
            File.Delete(fileName);

            Stopwatch timer = new();
            timer.Start();

            File.WriteAllLines(fileName, generatedNumbers.Select(pr => pr.Key + "\t" + pr.Value));

            timer.Stop();

            lstBoxStatictics.Items.Insert(0, "WriteFileWithAllLines took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms");
        }

        private void WriteFileWithStreamWriterNoAutoFlush()
        {
            string fileName = "StreamWriterNoAutoFlush.txt";
            File.Delete(fileName);

            StreamWriter swWrite = new(fileName);

            Stopwatch timer = new();
            timer.Start();

            foreach(var pair in generatedNumbers)
            {
                swWrite.WriteLine($"{pair.Key}\t{pair.Value}");
            }

            swWrite.Flush();
            swWrite.Close();

            timer.Stop();

            lstBoxStatictics.Items.Insert(0, "WriteFileWithStreamWriterNoAutoFlush took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms");
        }

        private void WriteFileWithStreamWriterAutoFlush()
        {
            string fileName = "StreamWriterAutoFlush.txt";
            File.Delete(fileName);

            StreamWriter swWrite = new(fileName);
            swWrite.AutoFlush = true;

            Stopwatch timer = new();
            timer.Start();

            foreach (var pair in generatedNumbers)
            {
                swWrite.WriteLine($"{pair.Key}\t{pair.Value}");
            }

            swWrite.Flush();
            swWrite.Close();

            timer.Stop();

            lstBoxStatictics.Items.Insert(0, "WriteFileWithStreamWriterAutoFlush took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms");
        }

        private void WriteStringBuilder()
        {
            string fileName = "StringBuilder.txt";
            File.Delete(fileName);

            StringBuilder strBuilder = new();

            Stopwatch timer = new();
            timer.Start();

            foreach (var pair in generatedNumbers)
            {
                strBuilder.AppendLine($"{pair.Key}\t{pair.Value}");
            }

            File.WriteAllText(fileName, strBuilder.ToString());

            timer.Stop();

            lstBoxStatictics.Items.Insert(0, "WriteStringBuilder took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms");
        }
    }
}
