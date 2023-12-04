using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly object lockObject = new object();

        private void btnNumbersGenerator_Click(object sender, RoutedEventArgs e)
        {
            var vrId = Thread.CurrentThread.ManagedThreadId;
            Debug.WriteLine($"Current thread id = {vrId} ");
            Task.Factory.StartNew(() => {
                //Everything that will be in this block will be executed on the thread pool
                //Using this will prevent main thread nor the UI thread from freezing
                vrId = Thread.CurrentThread.ManagedThreadId;
                Debug.WriteLine($"Current thread id task factory = {vrId} ");
                generateRandomNumbersMethod();
            });
        }

        private void generateRandomNumbersMethod()
        {
            Random randomGenerator = new();

            lock (lockObject)
            {
                generatedNumbers.Clear();

                for (int i = 0; i < 10000; i++)
                {
                    int randomNumber = randomGenerator.Next(1, 10000);

                    if (generatedNumbers.ContainsKey(randomNumber))
                    {
                        generatedNumbers[randomNumber] += 1;
                    }
                    else
                    {
                        generatedNumbers.Add(randomNumber, 1);
                    }
                }
            }

            UpdateStatistics();
        }

        void UpdateStatistics()
        {
            var statistics = CalculateStatistics();

            lock (lockObject)
            {
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    lstBoxStatictics.Items.Clear();

                    foreach (var statistic in statistics)
                    {
                        lstBoxStatictics.Items.Add(statistic);
                    }
                }));
            }
        }

        private List<string> CalculateStatistics()
        {
            var statistics = new List<string>();

            statistics.Add($"number of elements in dictionary:{generatedNumbers.Count}");
            statistics.Add($"First key in the dictionary:{generatedNumbers.Keys.FirstOrDefault()}");
            statistics.Add($"Last key in the dictionary:{generatedNumbers.Keys.LastOrDefault()}");
            statistics.Add($"Biggest key in the dictionary:{generatedNumbers.Keys.OrderByDescending(key => key).FirstOrDefault()}");
            statistics.Add($"Smallest key in the dictionary:{generatedNumbers.Keys.OrderBy(key => key).FirstOrDefault()}");
            statistics.Add($"Sum of keys in the dictionary:{generatedNumbers.Keys.Sum(key => key)}");

            return statistics;

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
            var vrId = Thread.CurrentThread.ManagedThreadId;

            switch (fileWritingMethod.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("No writing method selected");
                    break;
                case 1:
                    Task.Factory.StartNew(() => {
                        vrId = Thread.CurrentThread.ManagedThreadId;
                        Debug.WriteLine($"Current thread id task factory = {vrId} ");
                        WriteFileWithAllLines();
                    }).ContinueWith( completed => ExecuteFinalTask());
                    break;
                case 2:
                    Task.Factory.StartNew(() => {
                        vrId = Thread.CurrentThread.ManagedThreadId;
                        Debug.WriteLine($"Current thread id task factory = {vrId} ");
                        WriteFileWithStreamWriterNoAutoFlush();
                        WriteFileWithStreamWriterAutoFlush();
                    }).ContinueWith(completed => ExecuteFinalTask());
                    break;
                case 3:
                    Task.Factory.StartNew(() => {
                        vrId = Thread.CurrentThread.ManagedThreadId;
                        Debug.WriteLine($"Current thread id task factory = {vrId} ");
                        WriteStringBuilder();
                    }).ContinueWith(completed => ExecuteFinalTask());
                    break;
            }
        }

        private void WriteFileWithAllLines()
        {
            string fileName = "WriteAllLines.txt";
            File.Delete(fileName);

            Stopwatch timer = new();
            timer.Start();

            File.WriteAllLines(fileName, generatedNumbers.Select(pr => pr.Key + "\t" + pr.Value));

            timer.Stop();

            UpdateListBox("WriteFileWithAllLines took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms", 0);
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

            UpdateListBox("WriteFileWithStreamWriterNoAutoFlush took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms", 0);
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

            UpdateListBox("WriteFileWithStreamWriterAutoFlush took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms", 0);
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
            UpdateListBox("WriteStringBuilder took :" + timer.ElapsedMilliseconds.ToString("N0") + " ms", 0);
        }

        private void UpdateListBox(string message, int index)
        {
            Dispatcher.BeginInvoke(new Action(delegate ()
            {
                lstBoxStatictics.Items.Insert(index, message);
            }));
        }

        private void ExecuteFinalTask()
        {
            var exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Process.Start("explorer.exe", exePath);
            GC.Collect();
        }
    }
}
