using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class Transaction
    {
        public string beneficiary;
        public string benefactor;
        public double amount;
    }
    public class User
    {
        public string username;
        string password;
        public double Balance;
        public string LastAccess;
        Stack<Transaction> transactions;
        public User(string user, string pass)
        {
            username = user;
            password = pass;
        }
        public bool checkPassword(string pass)
        {
            if (pass == password)
            {
                return true;
            }
            else { return false; }
        }
        public void setPassword(string pass)
        {
            password = pass;
        }
    }
}
