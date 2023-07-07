using System;
using System.Collections.Generic;
using System.Text;

namespace BankingLibrary
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public Transaction(decimal Amount,DateTime Date,string Note)
        {
            this.Amount = Amount;
            this.Date = Date;
            this.Note = Note;
        }
    }
}
