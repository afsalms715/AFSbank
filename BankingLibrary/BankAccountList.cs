using System;
using System.Collections.Generic;
using System.Text;

namespace BankingLibrary
{
    public class BankAccountList
    {
        public int AccountNumber { get; set; }
        public BankAccount AccountOBJ { get; set; }
        public BankAccountList(int AccountNumber,BankAccount AccountOBJ)
        {
            this.AccountNumber = AccountNumber;
            this.AccountOBJ = AccountOBJ;
        }
    }
}
