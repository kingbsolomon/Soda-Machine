using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;

        public List<Coin> tempRegister;
        public  double tempMoneyTotal;
        public SodaMachine()
        {
            register = new List<Coin>();
            inventory = new List<Can>();

            InitRegister();
            InitInventory();
        }
 
        private void InitRegister()
        {
            for (int i = 0; i < 20; i++)
            {
                register.Add(new Quarter());
            }

            for (int i = 0; i < 10; i++)
            {
                register.Add(new Dime());
            }

            for (int i = 0; i < 20; i++)
            {
                register.Add(new Nickle());
            }

            for (int i = 0; i < 50; i++)
            {
                register.Add(new Penny());
            }
        }
        private void InitInventory()
        {
            for (int i = 0; i < 20; i++)
            {
                inventory.Add(new RootBeer());
            }
            for (int i = 0; i < 20; i++)
            {
                inventory.Add(new Cola());
            }
            for (int i = 0; i < 20; i++)
            {
                inventory.Add(new OrangeSoda());
            }
        }
        public bool InInventory(string name)
        {
            bool inInventory = false;
            for(int i= 0; i < inventory.Count; i++)
            {
                if (inventory[i].name == name)
                {
                    inInventory = true;
                    tempRegister = new List<Coin>();
                    break;
                }
                else
                {
                    inInventory = false;
                }
            }
            return inInventory;
        }
        public double MoneyInTempRegister()
        {
            tempMoneyTotal = 0;
            for (int i = 0; i < tempRegister.Count; i++)
            {
                tempMoneyTotal += tempRegister[i].Value;
            }
            return tempMoneyTotal;
        }

        // 



    }
}
