using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;
        bool sodaMachineContinue = true;

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
            UserInterface.Welcome();
            string paymentChoice = UserInterface.ChoosePayment();
            PaymentChoice(paymentChoice);
        }
        public void PaymentChoice(string paymentChoice)
        {
            while (sodaMachineContinue)
            {
                switch (paymentChoice)
                {
                    case "1":
                            CoinSodaMachineLoop();
                            MakeAnotherPurchase();
                            paymentChoice = UserInterface.ChoosePayment();
                            break;

                    case "2":
                            CardSodaMachineLoop();
                            MakeAnotherPurchase();
                            paymentChoice = UserInterface.ChoosePayment();
                            break;
                    default:
                        paymentChoice = UserInterface.ChoosePayment();
                        break;
                }
            }
        }
        public void CardSodaMachineLoop()
        {
            bool inSodaMachineInventory = false;

            UserInterface.CardBalance(customer.wallet.card);
            

            while (!inSodaMachineInventory)
            {
                string sodaChoice = SodaSelection();
                inSodaMachineInventory = sodaMachine.InInventory(sodaChoice);
                //UserInterface.CardBalance(customer.wallet);
            }
            CheckEnoughMoneyCard();
        }
        public void CoinSodaMachineLoop()
        {
            bool inSodaMachineInventory = false;
            double moneyPrintOut;

            InitTempRegister();
            moneyPrintOut = sodaMachine.MoneyInTempRegister();
            UserInterface.MoneyPrintOut(Math.Round(moneyPrintOut,2)); 

            while (!inSodaMachineInventory) 
            { 
                string sodaChoice = SodaSelection();
                inSodaMachineInventory = sodaMachine.InInventory(sodaChoice);
            }
            CheckEnoughMoney();
        }
        public bool MakeAnotherPurchase()
        {
            string anotherPurchase = UserInterface.AnotherPurchase().ToLower();
            switch (anotherPurchase)
            {
                case "y":
                    sodaMachineContinue = true;
                    break;
                case "n":
                    sodaMachineContinue = false;
                    break;
                default:
                    sodaMachineContinue = false;
                    break;
            }
            return sodaMachineContinue;
        }
        public void CheckEnoughMoney()
        {
            bool changeCheck = CheckChangeAvailable();

            if ((sodaMachine.tempMoneyTotal >= sodaMachine.tempCan.Cost) || changeCheck)
            {
                customer.backpack.MyCans.Add(sodaMachine.tempCan);
                sodaMachine.inventory.Remove(sodaMachine.tempCan);
                AddMoneyToSodaMachine();
                GiveChange();
            }
            else if((sodaMachine.tempMoneyTotal < sodaMachine.tempCan.Cost) || !changeCheck)
            {
                UserInterface.InsufficientFunds();
                ReturnMoney();
            }
        }
        public void CheckEnoughMoneyCard()
        {
            if (customer.wallet.card.AvailableFunds >= sodaMachine.tempCan.Cost)
            {
                customer.backpack.MyCans.Add(sodaMachine.tempCan);
                sodaMachine.inventory.Remove(sodaMachine.tempCan);
                customer.wallet.card.AvailableFunds -= sodaMachine.tempCan.Cost;
                sodaMachine.electronicRegister += sodaMachine.tempCan.Cost;
            }
            else if (customer.wallet.card.AvailableFunds < sodaMachine.tempCan.Cost)
            {
                UserInterface.InsufficientFunds();
            }
        }
        public void ReturnMoney()
        {
            int tempRegisterCount = sodaMachine.tempRegister.Count;
            for (int i = 0; i < tempRegisterCount; i++)
            {
                customer.wallet.walletMoney.Add(sodaMachine.tempRegister[0]);
                sodaMachine.tempRegister.RemoveAt(0);
            }
        }
        public void AddMoneyToSodaMachine()
        {
            int tempRegisterCount = sodaMachine.tempRegister.Count;
            for (int i = 0; i < tempRegisterCount; i++)
            {
                sodaMachine.register.Add(sodaMachine.tempRegister[0]);
                sodaMachine.tempRegister.RemoveAt(0);
            }
        }
        public void GiveChange()
        {
            double change = sodaMachine.tempMoneyTotal - sodaMachine.tempCan.Cost;
            UserInterface.ChangeAmount(change);

            while (change >= 0.25)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Quarter").ToList().Count > 0)
                { 
                    change -= 0.25;
                    AddQuarterChangeToWallet();
                }
            }
            while (change >= 0.10)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Dime").ToList().Count > 0)
                {
                    change -= 0.10;
                    AddDimeChangeToWallet();
                }
            }
            while (change >= 0.05)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Nickle").ToList().Count > 0)
                {
                    change -= 0.05;
                    AddNickleChangeToWallet();
                }
            }
            while (change >= 0.01)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Penny").ToList().Count > 0)
                {
                    change -= 0.01;
                    AddPennyChangeToWallet();
                }
            }
        }
        public bool CheckChangeAvailable()
        {
            double change = sodaMachine.tempMoneyTotal - sodaMachine.tempCan.Cost;
            while (change >= 0.25)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Quarter").ToList().Count > 0)
                {
                    change -= 0.25;
                    AddQuarterChangeToWallet();
                }
            }
            while (change >= 0.10)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Dime").ToList().Count > 0)
                {
                    change -= 0.10;
                    AddDimeChangeToWallet();
                }
            }
            while (change >= 0.05)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Nickle").ToList().Count > 0)
                {
                    change -= 0.05;
                    AddNickleChangeToWallet();
                }
            }
            while (change >= 0.01)
            {
                if (customer.wallet.walletMoney.Where(c => c.name == "Penny").ToList().Count > 0)
                {
                    change -= 0.01;
                    AddPennyChangeToWallet();
                }
            }
            if(change == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string SodaSelection()
        {
            string sodaName = "";
            string sodaChoice = UserInterface.ChooseSodaMenu();

                switch (sodaChoice)
                {
                    case "1":
                        sodaName = "Root Beer";
                        break;
                    case "2":
                        sodaName = "Cola";
                        break;
                    case "3":
                        sodaName = "Orange Soda";
                        break;
                    default:
                        UserInterface.ValidSelection();
                        SodaSelection();
                        break;
                }
            return sodaName;
        }
        public void InitTempRegister()
        {
            sodaMachine.tempRegister = new List<Coin>();
            UserInterface.WhatCoinsInMachine();
            AddQuartersToTempRegister(UserInterface.InsertQuarters());
            AddDimesToTempRegister(UserInterface.InsertDimes());
            AddNicklesToTempRegister(UserInterface.InsertNickles());
            AddPenniesToTempRegister(UserInterface.InsertPennies());
            Console.Clear();
        }
        public void AddQuartersToTempRegister(int quarters)
        {
            int amountOfQuarters = customer.wallet.walletMoney.Where(c => c.name == "Quarter").ToList().Count;

            if (amountOfQuarters >= quarters)
            { 
                for (int i = 0; i < quarters; i++)
                {
                    for (int j = 0; j < customer.wallet.walletMoney.Count; j++)
                    {
                        if (customer.wallet.walletMoney[j].name == "Quarter")
                        {
                            sodaMachine.tempRegister.Add(customer.wallet.walletMoney[j]);
                            customer.wallet.walletMoney.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            else
            {
                UserInterface.ValidSelection();
                AddQuartersToTempRegister(UserInterface.InsertQuarters());
            }
        }
        public void AddDimesToTempRegister(int dimes)
        {
            int amountOfDimes = customer.wallet.walletMoney.Where(c => c.name == "Dime").ToList().Count;

            if (amountOfDimes >= dimes)
            {
                for (int i = 0; i < dimes; i++)
                {
                    for (int j = 0; j < customer.wallet.walletMoney.Count; j++)
                    {
                        if (customer.wallet.walletMoney[j].name == "Dime")
                        {
                            sodaMachine.tempRegister.Add(customer.wallet.walletMoney[j]);
                            customer.wallet.walletMoney.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            else
            {
                UserInterface.ValidSelection();
                AddDimesToTempRegister(UserInterface.InsertDimes());

            }
        }
        public void AddNicklesToTempRegister(int nickles)
        {
            int amountOfNickles = customer.wallet.walletMoney.Where(c => c.name == "Nickle").ToList().Count;

            if (amountOfNickles >= nickles)
            {
                for (int i = 0; i < nickles; i++)
                {
                    for (int j = 0; j < customer.wallet.walletMoney.Count; j++)
                    {
                        if (customer.wallet.walletMoney[j].name == "Nickle")
                        {
                            sodaMachine.tempRegister.Add(customer.wallet.walletMoney[j]);
                            customer.wallet.walletMoney.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            else
            {
                UserInterface.ValidSelection();
                AddNicklesToTempRegister(UserInterface.InsertNickles());
            }
        }
        public void AddPenniesToTempRegister(int pennies)
        {
            int amountOfPennies = customer.wallet.walletMoney.Where(c => c.name == "Penny").ToList().Count;

            if (amountOfPennies >= pennies)
            {
                for (int i = 0; i < pennies; i++)
                {
                    for (int j = 0; j < customer.wallet.walletMoney.Count; j++)
                    {
                        if (customer.wallet.walletMoney[j].name == "Penny")
                        {
                            sodaMachine.tempRegister.Add(customer.wallet.walletMoney[j]);
                            customer.wallet.walletMoney.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            else
            {
                UserInterface.ValidSelection();
                AddPenniesToTempRegister(UserInterface.InsertPennies());
            }
        }
        public void AddQuarterChangeToWallet()
        {
                for (int i = 0; i < sodaMachine.register.Count; i++)
                {
                    if (sodaMachine.register[i].name == "Quarter")
                    {
                        customer.wallet.walletMoney.Add(sodaMachine.register[i]);
                        sodaMachine.register.RemoveAt(i);
                        break;
                    }
                }
        }
        public void AddDimeChangeToWallet()
        {
            for (int i = 0; i < sodaMachine.register.Count; i++)
            {
                if (sodaMachine.register[i].name == "Dime")
                {
                    customer.wallet.walletMoney.Add(sodaMachine.register[i]);
                    sodaMachine.register.RemoveAt(i);
                    break;
                }
            }
        }
        public void AddNickleChangeToWallet()
        {
            for (int i = 0; i < sodaMachine.register.Count; i++)
            {
                if (sodaMachine.register[i].name == "Nickle")
                {
                    customer.wallet.walletMoney.Add(sodaMachine.register[i]);
                    sodaMachine.register.RemoveAt(i);
                    break;
                }
            }
        }
        public void AddPennyChangeToWallet()
        {
            for (int i = 0; i < sodaMachine.register.Count; i++)
            {
                if (sodaMachine.register[i].name == "Penny")
                {
                    customer.wallet.walletMoney.Add(sodaMachine.register[i]);
                    sodaMachine.register.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
//customer.wallet.walletMoney.Where(c => c.name == "Quarter").ToList().Count;

/*int quarterCounter = 0;
foreach(Coin coin in customer.wallet.walletMoney)
{
    if(coin.name == "Quarter")
    {
        quarterCounter++;
    }
}*/
