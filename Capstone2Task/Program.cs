using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Capstone2Task
{

    class Task
    {

        public List<string> members;
        public string date;
        public bool status;
        public string description;
        public Task()
        {
            members = new List<string>();
            status = false;
            
            
        }
        
        


    }

    class Program
    {
        static void Main(string[] args)
        {
            
            string run = "y";

            Console.WriteLine("\n" +
                "\t\t\tWelcome to the Task Manager!");
            Console.WriteLine("\t\t-----------------------------------------------\n" +
                "\n" +
                "");

            List<Task> tasks = new List<Task>();
            while (run == "y")
            {
                Console.WriteLine("\t\t\t\t1: List Task ");
                Console.WriteLine("\t\t\t\t2: Add Task");
                Console.WriteLine("\t\t\t\t3: Delete Task");
                Console.WriteLine("\t\t\t\t4: Mark Task Complete");
                Console.WriteLine("\t\t\t\t5: Quit ");
                //tasks = DummyData();


                Console.WriteLine("\n" +
                    "\t\t\tSelect an option from the menu\n" +
                    "");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        foreach (Task task in tasks)
                        {
                            foreach (string member in task.members)
                            {
                                
                                Console.WriteLine(member);
                            }
                            Console.WriteLine("" +
                                "TASK IS COMPLETE" +  "\tDUE DATE" + "\tDESCRIPTION\n" +
                               task.status + "\t\t\t" + task.date  + "\t\t" + task.description);
                            //Console.WriteLine("\t",task.date,"\t",task.members,"\t",task.description);
                            //Console.WriteLine("Task description : " + task.description);
                            //Console.WriteLine("Date task is due : " + task.date);
                            //Console.WriteLine("Has been completed : " + task.status);


                        }
                        break;
                    case "2":
                        
                        string newMember = ".";
                        bool check;
                        Task newTask = new Task();
                        do
                        {
                            Console.WriteLine("Add a (team member) first and last name or press(enter) to exit");
                            newMember = Console.ReadLine();
                            check = Program.ValidateName(newMember);
                            if(check == false)
                            {
                                Console.WriteLine("Please enter a valid name.");
                            }
                        }while (check == false);
                        newTask.members.Add(newMember);





                        Console.WriteLine("Please enter a date:");
                        newTask.date = Console.ReadLine();
                        
                        Console.WriteLine("Please enter task description:");
                        newTask.description = Console.ReadLine();
                        tasks.Add(newTask);

                        break;
                    case "3":
                        {
                            
                            if(tasks.Remove(GetTask(tasks, "What task do you want to delete?")))
                            {
                                Console.WriteLine("Task has been deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }

                        }
                        break;
                    case "4":
                       
                            Console.WriteLine("Which task would you like to mark as complete?");
                            int index = int.Parse(Console.ReadLine());
                            index--;
                        
                     
                        
                            tasks[index].status = true;
                        break;
                    case "5":
                        run = "n";
                        break;

                }

                if (run.ToLower() != "n")
                {
                    Console.WriteLine("Would you like to continue? (y/n)");
                    run = Console.ReadLine();
                }
                
            }

        }
        public static Task GetTask(List<Task> list, string message)
        {
            Console.WriteLine(message);
            int delete = int.Parse(Console.ReadLine());
            delete--;
            return list[delete];
        }

        public static List<Task> DummyData()
        {
            List<Task> list = new List<Task>();

            for(int i = 0; i < 5; i++)
            {
                Task task = new Task();
                for(int j = 0; j < 3; j++)
                {
                    task.members.Add($"Adam{i+1}{j+1}");
                }
                task.date = "08/08/2019";
                task.description = $"Project{i + 1}";
                list.Add(task);
            }
            return list;
        }
        public static bool ValidateName(string name)
        {
            bool answer;

            bool validFullName = Regex.IsMatch(name, @"^([A-Z{1}a-z]{1,30})\s([A-Z,a-z]{1,30})$");

            if (validFullName)
            {
                answer =  true;
            }
            else
            {
                answer = false;
            }

            return answer;








        }


    }

}
