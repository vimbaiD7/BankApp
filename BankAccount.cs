using BankAcc.States;
using System;
namespace BankAcc
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
       // public bool IsActive { get; private set; } = true;
      //  public bool IsClosed { get; private set; } = false;
        public DateTime? lastOperationDate { get; private set; }
        //private readonly TimeSpan deactivationThreshold = TimeSpan.FromDays(30);
        private AccountState _state;

        public BankAccount()
        {
            _state = new ActiveState(); // start in active state
        }

        public void Deposit(decimal amount)
        {
            /* if (IsClosed)
                 throw new InvalidOperationException("Account is closed.");

             Balance += amount;
             ReactivateIfNeeded();*/
            CheckForDeactivation();
           _state.Deposit(this, amount);
        }

        public void Withdraw(decimal amount, bool isVerified)
        {
            /* if (IsClosed)
                 throw new InvalidOperationException("Account is closed.");
             if (!IsActive)
                 throw new InvalidOperationException("Account is deactivated.");
             if (!isVerified)
                 throw new InvalidOperationException("Client identity verification failed.");
             if (Balance < amount)
                 throw new InvalidOperationException("Insufficient funds.");

             Balance -= amount;
             ReactivateIfNeeded();*/
            CheckForDeactivation();
           _state.Withdraw(this, amount, isVerified);
        }

        public void CloseAccount()
        {
            //IsClosed = true;
            //IsActive = false;
            _state.Close(this);
        }
        public void SetState(AccountState newState)
        {
            _state = newState;
        }

        public void CheckForDeactivation()
        {
            /* if (!IsClosed && lastOperationDate.HasValue &&
                 (DateTime.Now - lastOperationDate.Value) > deactivationThreshold)
             {
                 IsActive = false;
             }*/
            _state.CheckForDeactivation(this);
        }

        public void ReactivateIfNeeded()
        {
            /*if (!IsActive)
            {
                IsActive = true;

            }
            lastOperationDate = DateTime.Now;*/
            Console.WriteLine("Account has been reactivated.");
        }

        public void UpdateLastOp()
        {
            lastOperationDate = DateTime.Now;
        }

        public void SetLastOpDate(DateTime date)
        {
            lastOperationDate = date;
        }


    }
}