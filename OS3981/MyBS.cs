using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS3981
{
    class MySingleQ
    {
        public static Queue<Process> Processes = new Queue<Process>();
        public List<MemoryParts> memoryParts = new List<MemoryParts> {
            new MemoryParts (0,"Small",2),new MemoryParts (1,"Normal",4),new MemoryParts (2,"Big",8),
        new MemoryParts (3,"VeryBig",16),new MemoryParts (4,"Huge",32),new MemoryParts (5,"Massive",64)};
    
       

        public MySingleQ(List<Process> procs)
        {
            foreach (var item in procs)
            {
                Processes.Enqueue(item);
            }
            for (int i = 0; i < memoryParts.Count; i++)
            {
                memoryParts[i].Process = new Process("Empty", 0, -1);
            }
        }

        public string AddTomem()
        {
            Process process = Processes.Dequeue();
            int index = 0;
           

            for (int i = 0 ; i < memoryParts.Count; i++)
            {
                if (process.Size < memoryParts[i].SizeMB )
                {
                    index = i;
                    if ((!AllFull()) && memoryParts[i].HasProcess)
                    {
                        continue;
                    }
                    break;
                }
                if (AllFull())//remove process
                {
                    memoryParts[index].Process = new Process("Empty", 0, -1);
                    memoryParts[index].InternalFrag = 0;
                    memoryParts[index].HasProcess = false;
                }
                //break;//FirstFeet
            }
           
            memoryParts[index].AddProc(process);
            return process.Name+" ("+process.Size+")" + " ---> " + memoryParts[index].Name + " (" + memoryParts[index].SizeMB + ")";
        }
        public bool AllFull()
        {
            foreach (var item in memoryParts)
            {
                if ( ! item.HasProcess)
                {
                    return false;
                }
            }
            return true;
        }
        public string Fragments()
        {
            string res = "\n";
            foreach (var item in memoryParts)
            {
                res += item.Id +" Pname="+item.Process.Name+ " Frag=" + item.InternalFrag+"\n";
            }
            return res;
        }
        
    }
    class MyMultyQ
    {
        public static List<Queue<Process>> Processes = new List<Queue<Process>>
        {
            new Queue<Process> (),new Queue<Process> (),new Queue<Process> (),new Queue<Process> (),new Queue<Process> (),new Queue<Process> ()
        };
        public List<MemoryParts> memoryParts = new List<MemoryParts> {
            new MemoryParts (0,"Small",2),new MemoryParts (1,"Normal",4),new MemoryParts (2,"Big",8),
        new MemoryParts (3,"VeryBig",16),new MemoryParts (4,"Huge",32),new MemoryParts (5,"Massive",64)};

        public MyMultyQ(List<Process> procs)
        {
            foreach (var item in procs)
            {
                AddProc(item);
            }
            for (int i = 0; i < memoryParts.Count; i++)
            {
                memoryParts[i].Process = new Process("Empty", 0, -1);
            }
        }

        public MyMultyQ(List<Queue<Process>> processes, List<MemoryParts> memoryParts)
        {
            Processes = processes;
            this.memoryParts = memoryParts;
        }
        public static void FillQ()
        {
            Processes[0].Enqueue(new Process("a", 1, 0));
            Processes[1].Enqueue(new Process("b", 3, 1));
            Processes[2].Enqueue(new Process("c", 6, 2));
            Processes[3].Enqueue(new Process("d", 17, 3));
            Processes[4].Enqueue(new Process("e", 35, 4));
        }
        public void AddProc(Process process)
        {
            int index = 0;
            int t = 1;
            int i = 0;
            for (; i < memoryParts.Count; i++,t*=2)
            {
                if (process.Size < t)
                {
                    index = i;
                    if ((!AllFull()) && memoryParts[i].HasProcess)
                    {
                        continue;
                    }
                    break;
                }
                if (AllFull())//remove process
                {
                    memoryParts[index].Process = new Process("Empty", 0, -1);
                    memoryParts[index].InternalFrag = 0;
                    memoryParts[index].HasProcess = false;
                }
                //break;//FirstFeet
            }

          
            Processes[index-1].Enqueue(process);
            
        }
        public Process AddToMem(Queue<Process> processes,MemoryParts part)
        {
            Process process = processes.Dequeue();
            if (part.HasProcess)
            {
                part.Process = new Process("Empty", 0, -1);
                part.InternalFrag = 0;
                part.HasProcess = false;
            }
            part.AddProc(process);
            return process;
        }

        public bool AllFull()
        {
            foreach (var item in memoryParts)
            {
                if (!item.HasProcess)
                {
                    return false;
                }
            }
            return true;
        }
        public string Fragments()
        {
            string res = "\n";
            foreach (var item in memoryParts)
            {
                res += item.Id + " Pname=" + item.Process.Name + " Frag=" + item.InternalFrag + "\n";

            }
            return res;
        }

        public string AddTomem()
        {
            string res = "";
            for (int j = 0; j < 6; j++)
            {
                if (Processes[j].Count==0)
                {
                    j++;
                    continue;
                }
                Process process=
                AddToMem(Processes[j], memoryParts[j]);
                res+= 
                 process.Name + " (" + process.Size + ")" + " ---> " + memoryParts[j].Name + " (" + memoryParts[j].SizeMB + ")\n";

            }
            return res;
        }
    }
    class MemoryParts
    {
        public MemoryParts(int id, string name, int sizeMB)
        {
            Id = id;
            Name = name;
            SizeMB = sizeMB;
            InternalFrag = 0;

            HasProcess = false;
        }
        public void AddProc(Process process)
        {
            Process = process;
            InternalFrag = SizeMB - process.Size;
            HasProcess = true;
        }
        public MemoryParts(int id,string name, int sizeMB, Process process)
        {
            Id = id;
            Name = name;
            SizeMB = sizeMB;
            Process = process;
            HasProcess = true;
            InternalFrag = SizeMB - Process.Size;
        }
        public bool HasProcess { get; set; }
        public string Name { get; set; }
        public int SizeMB { get; set; }
        public Process Process { get; set; }
        public int InternalFrag { get; set; }
        public int Id { get; set; }

    }

    public class Process
    {
        public Process(string name, int size, int id)
        {
            Name = name;
            Size = size;
            Id = id;
        }

        public string Name { get; set; }
        public int Size { get; set; }
        public int Id { get; set; }
    }
}
