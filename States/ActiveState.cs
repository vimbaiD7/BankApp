
using System;

namespace BankAcc.States
{
    public class ActiveState : AccountState
    {
        public void Deposit(BankAccount account, decimal amount)
        {
            account.Balance += amount;
            account.UpdateLastOp();
        }

        public  void Withdraw(BankAccount account, decimal amount, bool isVerified)
        {
            if (!isVerified)
                throw new InvalidOperationException("Client identity verification failed.");
            if (account.Balance < amount)
                throw new InvalidOperationException("Insufficient funds.");

            account.Balance -= amount;
            account.UpdateLastOp();
        }
        public void Close(BankAccount account)
        {
            account.SetState(new ClosedState());
        }

        public void CheckForDeactivation(BankAccount account)
        {
            /*if ((DateTime.Now - account.lastOperationDate) > TimeSpan.FromDays(30))
            {
                account.SetState(new InactiveState());
            }*/
            if (account.lastOperationDate.HasValue &&
        DateTime.Now - account.lastOperationDate.Value > TimeSpan.FromDays(30))
            {
                account.SetState(new InactiveState());
            }
        }
    }

}
