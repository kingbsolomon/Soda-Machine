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

        }
    }
}
