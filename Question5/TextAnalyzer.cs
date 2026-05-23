namespace Assignment_2.Question5
{
    internal class TextAnalyzer
    {
        private string _text;

        // property
        public string Text
        {
            get { return _text; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _text = value;
                else
                    Console.WriteLine("Text cannot be empty.");
            }
        }

        // 1. Word Count
        public void WordCount()
        {
            string[] words = _text.Trim().Split(' ',
                StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"\nTotal Words   : {words.Length}");
            Console.WriteLine($"Total Chars   : {_text.Length}");
            Console.WriteLine($"Without Spaces: {_text.Replace(" ", "").Length}");
        }

        // 2. Search Word
        public void SearchWord(string keyword)
        {
            if (_text.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                int index = _text.IndexOf(keyword,
                    StringComparison.OrdinalIgnoreCase);

                // count occurrences
                int count = 0;
                int i = 0;
                while ((i = _text.IndexOf(keyword, i,
                    StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    count++;
                    i += keyword.Length;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n'{keyword}' found!");
                Console.WriteLine($"First occurrence at index : {index}");
                Console.WriteLine($"Total occurrences         : {count}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n'{keyword}' not found in text.");
                Console.ResetColor();
            }
        }

        // 3. Replace Word
        public void ReplaceWord(string oldWord, string newWord)
        {
            if (!_text.Contains(oldWord, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\n'{oldWord}' not found.");
                return;
            }

            string result = _text.Replace(oldWord, newWord,
                StringComparison.OrdinalIgnoreCase);
            _text = result;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nReplaced '{oldWord}' with '{newWord}'.");
            Console.WriteLine($"Updated Text: {_text}");
            Console.ResetColor();
        }

        // 4. Reverse Text
        public void ReverseText()
        {
            char[] chars = _text.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);

            Console.WriteLine($"\nOriginal : {_text}");
            Console.WriteLine($"Reversed : {reversed}");
        }

        // 5. Palindrome Check
        public void PalindromeCheck()
        {
            // remove spaces and lowercase
            string cleaned = _text.Replace(" ", "").ToLower();

            char[] chars = cleaned.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);

            Console.WriteLine($"\nOriginal : {_text}");

            if (cleaned == reversed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Result   : ✔ Is a Palindrome!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Result   : ✘ Not a Palindrome.");
            }
            Console.ResetColor();
        }

        // 6. Text Info
        public void TextInfo()
        {
            Console.WriteLine($"\n--- Text Info ---");
            Console.WriteLine($"Original    : {_text}");
            Console.WriteLine($"Uppercase   : {_text.ToUpper()}");
            Console.WriteLine($"Lowercase   : {_text.ToLower()}");
            Console.WriteLine($"Trimmed     : {_text.Trim()}");
            Console.WriteLine($"Starts With : {_text[0]}");
            Console.WriteLine($"Ends With   : {_text[_text.Length - 1]}");
        }
    }
}