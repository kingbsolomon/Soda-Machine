using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SodaMachine
{
    public static class UserInterface
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to the Soda Machine");
            Console.WriteLine("I am here to cure your thirst needs!");
        }
        
        public static void WhatCoinsInMachine()
        {
            Console.WriteLine("Please Insert Coins into the Soda Machine");
            InsertQuarters();
            InsertDimes();
            InsertNickles();
            InsertPennies();
        }

        public static int InsertQuarters()
        {
            Console.Write("How many Quarters would you like to insert? ");
            int tempQuarters = Int32.Parse(Console.ReadLine());
            return tempQuarters;
        }

        public static int InsertDimes()
        {
            Console.Write("How many Dimes would you like to insert? ");
            int tempDimes = Int32.Parse(Console.ReadLine());
            return tempDimes;
        }

        public static int InsertNickles()
        {
            Console.Write("How many Nickles would you like to insert? ");
            int tempNickles = Int32.Parse(Console.ReadLine());
            return tempNickles;
        }

        public static int InsertPennies()
        {
            Console.Write("How many Pennies would you like to insert? ");
            int tempPennies = Int32.Parse(Console.ReadLine());
            return tempPennies;
        }


        public static string ChoosePayment()
        {
            Console.WriteLine("Please select a payment method:");
            Console.WriteLine("1: Coins\t2: Card");
            string paySelection = Console.ReadLine();
            return paySelection;
        }

        public static string ChooseSodaMenu()
        {
            Console.WriteLine("Please select which type of Soda you would like:");
            Console.WriteLine("1: Root Beer\t2: Orange Soda\t3: Cola");
            string sodaSelection = Console.ReadLine();
            return sodaSelection;
        }

    }
}
