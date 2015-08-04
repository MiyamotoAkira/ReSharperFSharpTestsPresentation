using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCardEngine;

namespace TradingCardCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.CreateFirstPlayer();
            game.CreateSecondPlayer();
            game.SetFirstPlayerDeck();
            game.SetFirstPlayerHand();
            game.SetSecondPlayerDeck();
            game.SetSecondPlayerDeck();
            game.GameLoop();
        }
    }
}
