using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;

namespace BankingLibrary
{
    public class BankAccount
    {
        public string name { get; set; }
        public int accountNumber { get; set; }
        private static int accountNumSeed=0;
        public decimal Balance { get {
                decimal balence = 0;
                foreach (var item in AllTransaction)
                {
                    balence += item.Amount;
                }
                return balence;
            }
        }
        public string BalanceForHuman { 
            get {
                return ((int)Balance).ToWords();  
            }
        }
        public List<Transaction> AllTransaction = new List<Transaction>();
        
        public BankAccount(string name,decimal initialBalence)
        {
            this.name = name;
            diposit(initialBalence,DateTime.Now, "initial diposit");
            accountNumSeed++;
            this.accountNumber = accountNumSeed;
        }
        public void diposit(decimal amount,DateTime date,string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Diposite Amount");
            }
            var Transc = new Transaction(amount,date,note);
            AllTransaction.Add(Transc);
        }
        public void withdraw(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Invalid Withdrawal Amount");
            }
            else if (Balance - amount < 0)
            {
                throw new InvalidOperationException("no sufficent fund to withdraw");
            }
            var transc = new Transaction(-amount, date, note);
            AllTransaction.Add(transc);
        }
    }
}
