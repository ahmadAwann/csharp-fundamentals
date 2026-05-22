namespace Assignment_2.Question2
{
    internal class question2
    {
        public static void Run()
        {
            // create objects
            ResultChecker checker = new ResultChecker();
            NotificationService notify = new NotificationService();

            // Step 4 — subscribe methods to events
            checker.OnPass += notify.PassNotification;
            checker.OnFail += notify.FailNotification;

            List<Student> students = new List<Student>();
            int id = 1;

            while (true)
            {
                Console.WriteLine("\n--- Student Result System ---");
                Console.WriteLine("1. Add Student & Check Result");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                string inp = Console.ReadLine();

                switch (inp)
                {
                    case "1":
                        Student s = new Student();
                        s.SId = id++;

                        Console.Write("Enter Name: ");
                        s.SName = Console.ReadLine();

                        Console.Write("Enter Marks: ");
                        s.Marks = double.Parse(Console.ReadLine());

                        students.Add(s);

                        // Step 5 — fire the event
                        checker.CheckResult(s);
                        break;

                    case "2":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No students yet.");
                            break;
                        }
                        Console.WriteLine("\n--- All Students ---");
                        foreach (var st in students)
                        {
                            string status = st.Marks >= 50 ? "PASS" : "FAIL";
                            Console.WriteLine($"ID: {st.SId} | Name: {st.SName} | Marks: {st.Marks} | {status}");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}