namespace Assignment_2.Question4
{
    internal class question4
    {
        public static void Run()
        {
            List<BankAccount> accounts = new List<BankAccount>();
            int nextId = 1001;

            while (true)
            {
                Console.WriteLine("\n--- Banking System ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Transaction History");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                string inp = Console.ReadLine();

                switch (inp)
                {
                    case "1":
                        try
                        {
                            Console.Write("Enter Account Holder Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Initial Deposit: ");
                            string depInput = Console.ReadLine();

                            // validate input is a number
                            if (!double.TryParse(depInput, out double initialDep))
                                throw new FormatException("Please enter a valid number.");

                            BankAccount account = new BankAccount(nextId++, name, initialDep);
                            accounts.Add(account);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nAccount created! ID: {account.AccountId}");
                            Console.ResetColor();
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nError: {ex.Message}");
                            Console.ResetColor();
                        }
                        catch (InvalidAmountException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nError: {ex.Message}");
                            Console.ResetColor();
                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nError: {ex.Message}");
                            Console.ResetColor();
                        }
                        finally
                        {
                            Console.WriteLine("Account creation process completed.");
                        }
                        break;

                    case "2":
                        BankAccount depAcc = SelectAccount(accounts);
                        if (depAcc == null) break;

                        try
                        {
                            Console.Write("Enter deposit amount: ");
                            if (!double.TryParse(Console.ReadLine(), out double depAmt))
                                throw new FormatException("Please enter a valid number.");

                            depAcc.Deposit(depAmt);
                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nError: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case "3":
                        BankAccount witAcc = SelectAccount(accounts);
                        if (witAcc == null) break;

                        try
                        {
                            Console.Write("Enter withdrawal amount: ");
                            if (!double.TryParse(Console.ReadLine(), out double witAmt))
                                throw new FormatException("Please enter a valid number.");

                            witAcc.Withdraw(witAmt);
                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nError: {ex.Message}");
                            Console.ResetColor();
                        }
                        break;

                    case "4":
                        BankAccount balAcc = SelectAccount(accounts);
                        if (balAcc == null) break;
                        balAcc.CheckBalance();
                        break;

                    case "5":
                        BankAccount histAcc = SelectAccount(accounts);
                        if (histAcc == null) break;
                        histAcc.ShowHistory();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // helper — select account from list
        static BankAccount SelectAccount(List<BankAccount> accounts)
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found. Please create one first.");
                return null;
            }

            Console.WriteLine("\nSelect Account:");
            var numbered = accounts
                .Select((a, i) => $"{i + 1}. [{a.AccountId}] {a.OwnerName} - {a.Balance:C}")
                .ToList();
            numbered.ForEach(Console.WriteLine);

            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) ||
                choice < 1 || choice > accounts.Count)
            {
                Console.WriteLine("Invalid selection.");
                return null;
            }

            return accounts[choice - 1];
        }
    }
}