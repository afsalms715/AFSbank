using System;
using System.Collections.Generic;
using BankingLibrary;

namespace AFSbank
{
    class Program
    {
        static List<BankAccountList> AllAccounts = new List<BankAccountList>();
        static void Main(string[] args)
        {
            bool Retry = true;
            do
            {
                try
                {
                    Console.WriteLine("Choose an Option\n1-Create Account\n2-Make Deposit\n3-Make Withdrawal\n4-Get Transaction History\n5-list all Accounts" +
                        "\n6-Account Balence");
                    int userOption = int.Parse(Console.ReadLine());
                    
                    BankAccount a1;
                    if (userOption == 1)//creating Bank account
                    {
                        Console.WriteLine("Enter Your Name");
                        string CoustName = Console.ReadLine();
                        Console.WriteLine("Enter Your Initial Deposit Amount");
                        decimal initialAmount = decimal.Parse(Console.ReadLine());
                        Console.WriteLine(initialAmount);
                        a1 = new BankAccount(CoustName, initialAmount);
                        Console.WriteLine($"New Account Created\nName: {a1.name}\nAccount Number: {a1.accountNumber}\nBalance: {a1.Balance}");
                        BankAccountList Ac = new BankAccountList(a1.accountNumber,a1);
                        AllAccounts.Add(Ac);
                    }
                    else if (userOption == 2)//amount diposite
                    {
                        Console.WriteLine("Enter Account Number:");
                        int ACnumber = int.Parse(Console.ReadLine());
                        foreach(var item in AllAccounts)
                        {
                            if (item.AccountNumber == ACnumber)
                            {
                                Console.WriteLine($"Account Name:{item.AccountOBJ.name}");
                                Console.WriteLine("Enter Diposite Amount");
                                Decimal Diposite = Decimal.Parse(Console.ReadLine());
                                item.AccountOBJ.diposit(Diposite, DateTime.Now, "Diposite");
                                Console.WriteLine("Amount SuccessFully Diposited");
                            }
                            else
                            {
                                Console.WriteLine("The Account is Not Found!");
                            }
                        }
                    }
                    else if (userOption == 3)//amount withdrawal
                    {
                        Console.WriteLine("Enter Account Number:");
                        int ACnumber = int.Parse(Console.ReadLine());
                        foreach (var item in AllAccounts)
                        {
                            if (item.AccountNumber == ACnumber)
                            {
                                Console.WriteLine($"Account Name:{item.AccountOBJ.name}");
                                Console.WriteLine("Enter Withdrawal Amount");
                                Decimal Diposite = Decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Please Provide Reason for Withdrawal");
                                string Reason = Console.ReadLine();
                                item.AccountOBJ.withdraw(Diposite, DateTime.Now,Reason);
                                Console.WriteLine("Amount SuccessFully Withdrawal");
                            }
                            else
                            {
                                Console.WriteLine("The Account is Not Found!");
                            }
                        }
                    }
                    else if (userOption == 6)
                    {
                        Console.WriteLine("Enter Account Number:");
                        int ACnumber = int.Parse(Console.ReadLine());
                        foreach (var item in AllAccounts)
                        {
                            if (item.AccountNumber == ACnumber)
                            {
                                Console.WriteLine($"Account Name:{item.AccountOBJ.name}");
                                Console.WriteLine($"Account Balence:{item.AccountOBJ.Balance}");
                            }
                            else
                            {
                                Console.WriteLine("The Account is Not Found!");
                            }
                        }
                    }
                    else if (userOption == 4)//get transaction history
                    {
                        Console.WriteLine("Enter Account Number:");
                        int ACnumber = int.Parse(Console.ReadLine());
                        foreach (var item in AllAccounts)
                        {
                            if (item.AccountNumber == ACnumber)
                            {
                                Console.WriteLine($"Account Name:{item.AccountOBJ.name}");
                                foreach(var items in item.AccountOBJ.AllTransaction)
                                {
                                    Console.WriteLine($"Date:{items.Date} Amount:{items.Amount} Note:{items.Note}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("The Account is Not Found!");
                            }
                        }
                    }
                    else if (userOption == 5)//listing all accounts in Bank
                    {
                        ListAllAccounts();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter 1 To Exit\n2 To Continue");
                int UserChoice = int.Parse(Console.ReadLine());
                if (UserChoice == 1)
                {
                    Retry = false;
                }
            }
            while (Retry);
        }
        public static void ListAllAccounts()
        {
            foreach (var item in AllAccounts)
            {
                Console.WriteLine(item.AccountOBJ.name);
            }
        }
    }
}
