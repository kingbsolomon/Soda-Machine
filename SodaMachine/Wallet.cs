using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> walletMoney;
        public Card card;

        public Wallet()
        {
            walletMoney = new List<Coin>();
            card = new Card();
            InitWallet();
        }

        public void InitWallet()
        {
            for(int i = 0; i < 12; i++)
            {
                walletMoney.Add(new Quarter());
                
            }
            for (int i = 0; i < 10; i++)
            {
                walletMoney.Add(new Dime());
            }
            for (int i = 0; i < 10; i++)
            {
                walletMoney.Add(new Nickle());
            }
            for (int i = 0; i < 50; i++)
            {
                walletMoney.Add(new Penny());
            }
        }

        

    }
}
