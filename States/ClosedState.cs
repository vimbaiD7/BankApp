
using static BankAcc.States.AccountState;
using System;

namespace BankAcc.States
{
        public class ClosedState : AccountState
        {
            public void Deposit(BankAccount account, decimal amount)
            {
                throw new InvalidOperationException("Account is closed.");
            }

            public void Withdraw(BankAccount account, decimal amount, bool isVerified)
            {
                throw new InvalidOperationException("Account is closed.");
            }

            public  void CheckForDeactivation(BankAccount account) { }
            public void Close(BankAccount account) { }
        }

    }

