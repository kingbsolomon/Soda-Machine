using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> WalletMoney;
        public Card Card;

        public Wallet()
        {
            WalletMoney = new List<Coin>();
            Card = new Card();
            InitWallet();
        }

        public void InitWallet()
        {
            for(int i = 0; i < 12; i++)
            {
                WalletMoney.Add(new Quarter());
            }
            for (int i = 0; i < 10; i++)
            {
                WalletMoney.Add(new Dime());
            }
            for (int i = 0; i < 10; i++)
            {
                WalletMoney.Add(new Nickle());
            }
            for (int i = 0; i < 50; i++)
            {
                WalletMoney.Add(new Penny());
            }
        }

    }
}
