namespace Assignment_2.Question5
{
    internal class question5
    {
        public static void Run()
        {
            TextAnalyzer analyzer = new TextAnalyzer();

            while (true)
            {
                Console.WriteLine("\n--- Text Analysis System ---");
                Console.WriteLine("1. Enter / Change Text");
                Console.WriteLine("2. Word Count");
                Console.WriteLine("3. Search Word");
                Console.WriteLine("4. Replace Word");
                Console.WriteLine("5. Reverse Text");
                Console.WriteLine("6. Palindrome Check");
                Console.WriteLine("7. Text Info");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                string inp = Console.ReadLine();

                // check if text is set before any operation
                if (inp != "1" && inp != "0" &&
                    string.IsNullOrWhiteSpace(analyzer.Text))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nPlease enter text first (Option 1).");
                    Console.ResetColor();
                    continue;
                }

                switch (inp)
                {
                    case "1":
                        Console.Write("Enter text: ");
                        analyzer.Text = Console.ReadLine();
                        Console.WriteLine("Text saved!");
                        break;

                    case "2":
                        analyzer.WordCount();
                        break;

                    case "3":
                        Console.Write("Enter word to search: ");
                        string keyword = Console.ReadLine();
                        analyzer.SearchWord(keyword);
                        break;

                    case "4":
                        Console.Write("Enter word to replace: ");
                        string oldWord = Console.ReadLine();
                        Console.Write("Enter new word: ");
                        string newWord = Console.ReadLine();
                        analyzer.ReplaceWord(oldWord, newWord);
                        break;

                    case "5":
                        analyzer.ReverseText();
                        break;

                    case "6":
                        analyzer.PalindromeCheck();
                        break;

                    case "7":
                        analyzer.TextInfo();
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