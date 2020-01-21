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

namespace OS3981
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
        List<string> Process = new List<string>();
        private void LoadLru(object sender, RoutedEventArgs e)
        {
            Process = DataBase.LoadLRU(Process);
            Slru.IsEnabled = true;
        }

        private void StartLru(object sender, RoutedEventArgs e)
        {
            Log0Text.Text += "\n";
            foreach (string item in Process)
            {
                LRU rU = new LRU(item);
                Log0Text.Text += LRU.GetPages();
            }
            GetLRU.IsEnabled = true;
        }

        private void GetPages(object sender, RoutedEventArgs e)
        {
            Log0Text.Text += "\n Get Pages :\n" + LRU.GetPages();
        }

        private void Generatelru(object sender, RoutedEventArgs e)
        {
            bool r = Generate.SaveLRU();
            Log0Text.Text += r ? "\n Saved \n" : "";
        }
        List<Process> Procs = new List<Process>();
        private void LoadMem(object sender, RoutedEventArgs e)
        {
            Procs = DataBase.LoadMem(Procs);
            StartSQ.IsEnabled=StartMQ.IsEnabled = true;
        }
        private void StartSingleQ(object sender, RoutedEventArgs e)
        {
            MySingleQ singleQ = new MySingleQ(Procs);
            foreach (var item in Procs)
            {
                Log1Text.Text += "\n" + singleQ.AddTomem();
            }
            Log1Text.Text += ("\n------------------\n");
            Log1Text.Text += (singleQ.Fragments() + "\n");
            Log1Text.Text += ("\n------------------\n");
        }

        private void StartMultiQ(object sender, RoutedEventArgs e)
        {

            MyMultyQ multyQ = new MyMultyQ(Procs);
            foreach (var item in Procs)
            {
                Log1Text.Text += "\n" + multyQ.AddTomem();
            }
            Log1Text.Text += ("------------------\n");
            Log1Text.Text += (multyQ.Fragments() + "\n");
            Log1Text.Text += ("------------------\n");
        }
        private void GeneratePart(object sender, RoutedEventArgs e)
        {
            bool r = Generate.SaveMem();
            Log1Text.Text += r ? "\n Saved \n" : "";
        }

        private void LoadBank(object sender, RoutedEventArgs e)
        {

        }

        private void StartBank(object sender, RoutedEventArgs e)
        {
            Log2Text.Text += "\n" + Bankers.start();
        }

        private void GetBank(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateBank(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
