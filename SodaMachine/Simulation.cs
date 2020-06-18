using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
            UserInterface.Welcome();
            SodaMachineLoop();
            
            
            




        }

        public void SodaMachineLoop()
        {
            bool sodaMachineContinue = true;
            bool inSodaMachineInventory = false;
            double moneyPrintOut;

            while (sodaMachineContinue)
            {
                UserInterface.ChoosePayment();
                InitTempRegister();
                moneyPrintOut = sodaMachine.MoneyInTempRegister();
                UserInterface.MoneyPrintOut(moneyPrintOut); //you have inserted $x.xx into soda machine

                while (!inSodaMachineInventory) 
                { 
                string sodaChoice = SodaSelection();
                inSodaMachineInventory = sodaMachine.InInventory(sodaChoice);
                }
            }
        }
        public void CheckEnoughMoney()
        {
            if (sodaMachine.tempMoneyTotal >= sodaMachine.tempCan.Cost)
            {
                customer.backpack.MyCans.Add(sodaMachine.tempCan);
                sodaMachine.inventory.Remove(sodaMachine.tempCan);
            }
            else
            {
                UserInterface.InsufficientFunds();
                ReturnMoney();

            }
        }

        public void ReturnMoney()
        {
            for (int i = 0; i < sodaMachine.tempRegister.Count; i++)
            {
                customer.wallet.walletMoney.Add(sodaMachine.tempRegister[i]);
                sodaMachine.tempRegister.RemoveAt(i);
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
                        sodaName = "Orange Soda";
                        break;
                    case "3":
                        sodaName = "Cola";
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection");
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
        public void AddDimesToTempRegister(int dimes)
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
        public void AddNicklesToTempRegister(int nickles)
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
        public void AddPenniesToTempRegister(int pennies)
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
    }
}
