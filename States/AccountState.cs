
       namespace BankAcc.States
    {
        public interface AccountState
        {
            void Deposit(BankAccount account, decimal amount);
            void Withdraw(BankAccount account, decimal amount, bool isVerified);
            void Close(BankAccount account);
            void CheckForDeactivation(BankAccount account);
        }
    }


