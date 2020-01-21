using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OS3981
{
    class DataBase
    {
        public static bool SaveLRU(List<string> ProcessNames)
        {
            List<string> res = ProcessNames;
            
            
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Process files (*.lru)|*.lru",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Title = "Save Processes"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    string TreeListsJson = JsonConvert.SerializeObject(res, Formatting.Indented);
                    System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveFileDialog.FileName);
                    streamWriter.Write(TreeListsJson);
                streamWriter.Close();
                }

                return true;
            
            

        }
        public static List<string> LoadLRU(List<string> ProcessNames)
        {
            try 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = false,
                    Filter = "Process files (*.lru)|*.lru|All files (*.*)|*.*",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    string Json;
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        Json = sr.ReadToEnd();
                        MessageBox.Show(Json);
                        sr.Close();
                    }
                    ProcessNames = JsonConvert.DeserializeObject<List<string>>(Json);
                }
                return ProcessNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }


        }
        public static bool SaveMem(List<Process> Process)
        {
            List<Process> res = Process;


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Process files (*.mem)|*.mem",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "Save Processes"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string TreeListsJson = JsonConvert.SerializeObject(res, Formatting.Indented);
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(TreeListsJson);
                streamWriter.Close();
            }

            return true;
        }
        public static List<Process> LoadMem(List<Process> ProcessNames)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = false,
                    Filter = "Process files (*.mem)|*.mem|All files (*.*)|*.*",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    string Json;
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        Json = sr.ReadToEnd();
                       // MessageBox.Show(Json);
                        sr.Close();
                    }
                    ProcessNames = JsonConvert.DeserializeObject<List<Process>>(Json);
                }
                return ProcessNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        public static bool SaveBank(List<string> ProcessNames)
        {
            List<string> res = ProcessNames;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Process files (*.lru)|*.lru",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "Save Processes"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string TreeListsJson = JsonConvert.SerializeObject(res, Formatting.Indented);
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(TreeListsJson);
                streamWriter.Close();
            }

            return true;



        }
        public static List<string> LoadBank(List<string> ProcessNames)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Process files (*.lru)|*.lru|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    string Json;
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        Json = sr.ReadToEnd();
                       // MessageBox.Show(Json);
                        sr.Close();
                    }
                    ProcessNames = JsonConvert.DeserializeObject<List<string>>(Json);
                }
                return ProcessNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }


        }

    }

}
