namespace Assignment_2.Question4
{
    internal class BankAccount
    {
        // properties
        public int AccountId { get; set; }
        public string OwnerName { get; set; }
        public double Balance { get; private set; }
        public List<string> TransactionHistory { get; set; } = new List<string>();

        public BankAccount(int id, string name, double initialDeposit)
        {
            // validate name
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Account holder name cannot be empty.");

            // validate initial deposit
            if (initialDeposit < 0)
                throw new InvalidAmountException("Initial deposit cannot be negative.");

            AccountId = id;
            OwnerName = name;
            Balance = initialDeposit;
            TransactionHistory.Add($"Account created with balance: {initialDeposit:C}");
        }

        // Deposit
        public void Deposit(double amount)
        {
            try
            {
                if (amount <= 0)
                    throw new InvalidAmountException("Deposit amount must be greater than zero.");

                Balance += amount;
                TransactionHistory.Add($"Deposited: {amount:C} | Balance: {Balance:C}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nDeposit successful! New balance: {Balance:C}");
                Console.ResetColor();
            }
            catch (InvalidAmountException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("Deposit operation completed.");
            }
        }

        // Withdraw
        public void Withdraw(double amount)
        {
            try
            {
                if (amount <= 0)
                    throw new InvalidAmountException("Withdrawal amount must be greater than zero.");

                if (amount > Balance)
                    throw new InsufficientFundsException($"Insufficient funds! Available balance: {Balance:C}");

                Balance -= amount;
                TransactionHistory.Add($"Withdrawn: {amount:C} | Balance: {Balance:C}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nWithdrawal successful! New balance: {Balance:C}");
                Console.ResetColor();
            }
            catch (InvalidAmountException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }
            catch (InsufficientFundsException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("Withdrawal operation completed.");
            }
        }

        // Check Balance
        public void CheckBalance()
        {
            Console.WriteLine($"\nAccount Owner : {OwnerName}");
            Console.WriteLine($"Account ID    : {AccountId}");
            Console.WriteLine($"Balance       : {Balance:C}");
        }

        // Transaction History
        public void ShowHistory()
        {
            if (TransactionHistory.Count == 0)
            {
                Console.WriteLine("No transactions yet.");
                return;
            }

            Console.WriteLine($"\n--- Transaction History ({OwnerName}) ---");
            TransactionHistory.ForEach(t => Console.WriteLine("• " + t));
        }
    }
}