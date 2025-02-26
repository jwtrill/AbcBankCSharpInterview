﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bank_tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestApp()
        {
            Account checkingAccount = new Account(Account.CHECKING);
            Account savingsAccount = new Account(Account.SAVINGS);

            Customer henry = new Customer("Henry")
                .OpenAccount(checkingAccount)
                .OpenAccount(savingsAccount);

            checkingAccount.Deposit(100.0);
            savingsAccount.Deposit(4000.0);
            savingsAccount.Withdraw(200.0);

            string expectedStatement = "Statement for Henry\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00";

            string actualStatement = henry.GetStatement();

            Assert.AreEqual(expectedStatement, actualStatement);
        }

        [TestMethod]
        public void TestOneAccount()
        {
            Customer oscar = new Customer("Oscar")
                .OpenAccount(new Account(Account.SAVINGS));

            int expectedAccounts = 1;
            int actualAccounts = oscar.GetNumberOfAccounts();

            Assert.AreEqual(expectedAccounts, actualAccounts);
        }

        [TestMethod]
        public void TestTwoAccount()
        {
            Customer oscar = new Customer("Oscar")
                 .OpenAccount(new Account(Account.SAVINGS))
                 .OpenAccount(new Account(Account.CHECKING));

            int expectedAccounts = 2;
            int actualAccounts = oscar.GetNumberOfAccounts();

            Assert.AreEqual(expectedAccounts, actualAccounts);
        }

        [TestMethod]
        public void TestThreeAccounts()
        {
            Customer oscar = new Customer("Oscar")
                    .OpenAccount(new Account(Account.SAVINGS))
                    .OpenAccount(new Account(Account.CHECKING))
                    .OpenAccount(new Account(Account.MAXI_SAVINGS));

            int expectedAccounts = 3;
            int actualAccounts = oscar.GetNumberOfAccounts();

            Assert.AreEqual(expectedAccounts, actualAccounts);
        }
    }
}
