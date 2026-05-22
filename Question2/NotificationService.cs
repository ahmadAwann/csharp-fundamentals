namespace Assignment_2.Question2
{
    internal class NotificationService
    {
        // these methods run when events fire
        public void PassNotification(Student student)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n*** Congratulations {student.SName}! ***");
            Console.WriteLine($"You PASSED with {student.Marks} marks.");
            Console.WriteLine($"Email notification sent to {student.SName}.");
            Console.ResetColor();
        }

        public void FailNotification(Student student)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n*** Sorry {student.SName}! ***");
            Console.WriteLine($"You FAILED with {student.Marks} marks.");
            Console.WriteLine($"Fail notification sent to {student.SName}.");
            Console.ResetColor();
        }
    }
}