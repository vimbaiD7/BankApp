
using System;

namespace BankAcc.States
{
    public class InactiveState : AccountState
    {
        public void Deposit(BankAccount account, decimal amount)
        {
            account.Balance += amount;
            account.SetState(new ActiveState());
           // account.ReactivateIfNeeded();
            account.UpdateLastOp();
        }

        public void Withdraw(BankAccount account, decimal amount, bool isVerified)
        {
            throw new InvalidOperationException("Account is deactivated.");
           // account.SetState(new ActiveState());
           // account.ReactivateIfNeeded();
           // account.Withdraw(amount, isVerified); 
        }
        public void Close(BankAccount account)
        {
            account.SetState(new ClosedState());
        }
        public void CheckForDeactivation(BankAccount account) { }
    }

}
