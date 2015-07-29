using System;
using System.Collections.Generic;
using static System.Console;

namespace TradingCardEngine
{
    public class Game
    {
        public void GameLoop()
        {
            var player1 = new Player();
            var player2 = new Player();

            var deck1 = CreateBasicDeck();
            var deck2 = CreateBasicDeck();

            player1.SetDeck(deck1);
            player1.AddCardToHand();
            player1.AddCardToHand();
            player1.AddCardToHand();

            player2.SetDeck(deck2);
            player2.AddCardToHand();
            player2.AddCardToHand();
            player2.AddCardToHand();

            var activePlayer = player1;
            var inactivePlayer = player2;
            while (PlayersAreAlive(player1, player2))
            {
                WriteLine($"Player1 Life :{player1.Life} Mana: {player1.Mana}");
                WriteLine($"Player2 Life :{player2.Life} Mana: {player2.Mana}");
                PlayerTurn(ref activePlayer, ref inactivePlayer);
                
            }
        }

        private void PlayerTurn(ref Player activePlayer, ref Player inactivePlayer)
        {
            ManaPhase(activePlayer);
            DrawCardPhase(activePlayer);
            DiscardPhase(activePlayer);

            var canPlay = true;
            while (canPlay)
            {
                WriteLine("Play a card from the following set: " + activePlayer.ShowHandAsString());
                WriteLine("Press P to pass");
                var read = ReadLine();

                if (read != "p")
                {
                    var value = int.Parse(read);
                    activePlayer.RemoveCardFromHandWithValue(value);
                    inactivePlayer.ReduceLife(value);
                }

                if (activePlayer.HandCount == 0 || read == "p")
                {
                    canPlay = false;
                }
            }

            var temp = activePlayer;
            activePlayer = inactivePlayer;
            inactivePlayer = temp;
        }

        private static void DiscardPhase(Player activePlayer)
        {
            if (activePlayer.HandCount > 5)
            {
                activePlayer.DiscardLastCardFromHand();
            }
        }

        private static void DrawCardPhase(Player activePlayer)
        {
            if (activePlayer.DeckCount > 0)
            {
                activePlayer.AddCardToHand();
            }
            else
            {
                activePlayer.ReduceLife(1);
            }
        }

        private static void ManaPhase(Player activePlayer)
        {
            if (activePlayer.Mana < 10)
            {
                activePlayer.AddMana(1);
            }
        }

        private static CardCollection CreateBasicDeck()
        {
            return new CardCollection(new List<Card>
            {
                new Card(0,0),
                new Card(0,0),
                new Card(1,1),
                new Card(1,1),
                new Card(2,2),
                new Card(2,2),
                new Card(2,2),
                new Card(3,3),
                new Card(3,3),
                new Card(3,3),
                new Card(3,3),
                new Card(4,4),
                new Card(4,4),
                new Card(4,4),
                new Card(5,5),
                new Card(5,5),
                new Card(6,6),
                new Card(6,6),
                new Card(7,7),
                new Card(8,8)
            });
        }

        private static bool PlayersAreAlive(Player player1, Player player2)
        {
            return player1.IsPlayerAlive() && player2.IsPlayerAlive();
        }

        private void unnededMethod()
        {
        } 
    }
}