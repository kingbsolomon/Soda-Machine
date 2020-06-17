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
            //UserInterface.
        }









        public void SodaSelection()
        {
            bool sodaSelection = false;

            string sodaChoice = UserInterface.ChooseSodaMenu();
            while (!sodaSelection) 
            {
           
                switch (sodaChoice)
                {
                    case "1":


                }
            }
        }


        public void InitTempRegister()
        {
            UserInterface.WhatCoinsInMachine();
            AddQuartersToTempRegister(UserInterface.InsertQuarters());
            AddDimesToTempRegister(UserInterface.InsertDimes());
            AddNicklesToTempRegister(UserInterface.InsertNickles());
            AddPenniesToTempRegister(UserInterface.InsertPennies());
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
