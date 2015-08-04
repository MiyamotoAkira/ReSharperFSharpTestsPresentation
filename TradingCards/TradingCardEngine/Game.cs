using System.Collections.Generic;
using static System.Console;

namespace TradingCardEngine
{
    public class Game
    {
        private IPlayer player1;
        private IPlayer player2;

        public void GameLoop()
        {
            var activePlayer = player1;
            var inactivePlayer = player2;
            while (PlayersAreAlive(player1, player2))
            {
                WriteLine($"Player1 Life :{player1.Life} Mana: {player1.Mana}");
                WriteLine($"Player2 Life :{player2.Life} Mana: {player2.Mana}");
                PlayerTurn(ref activePlayer, ref inactivePlayer);
            }
        }

        public void SetSecondPlayerHand()
        {
            player2.AddCardToHand();
            player2.AddCardToHand();
            player2.AddCardToHand();
        }

        public void SetSecondPlayerDeck()
        {
            var deck2 = CreateBasicDeck();
            player2.SetDeck(deck2);
        }

        public void SetFirstPlayerHand()
        {
            player1.AddCardToHand();
            player1.AddCardToHand();
            player1.AddCardToHand();
        }

        public void SetFirstPlayerDeck()
        {
            var deck1 = CreateBasicDeck();
            player1.SetDeck(deck1);
        }

        public void CreateSecondPlayer()
        {
            player2 = new Player();
        }

        public void SetFirstPlayer(IPlayer player)
        {
            player1 = player;
        }

        public void SetSecondPlayer(IPlayer player)
        {
            player2 = player;
        }

        public void CreateFirstPlayer()
        {
            player1 = new Player();
        }

        private void PlayerTurn(ref IPlayer activePlayer, ref IPlayer inactivePlayer)
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

        private static void DiscardPhase(IPlayer activePlayer)
        {
            if (activePlayer.HandCount > 5)
            {
                activePlayer.DiscardLastCardFromHand();
            }
        }

        private static void DrawCardPhase(IPlayer activePlayer)
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

        private static void ManaPhase(IPlayer activePlayer)
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
                new Card(0, 0),
                new Card(0, 0),
                new Card(1, 1),
                new Card(1, 1),
                new Card(2, 2),
                new Card(2, 2),
                new Card(2, 2),
                new Card(3, 3),
                new Card(3, 3),
                new Card(3, 3),
                new Card(3, 3),
                new Card(4, 4),
                new Card(4, 4),
                new Card(4, 4),
                new Card(5, 5),
                new Card(5, 5),
                new Card(6, 6),
                new Card(6, 6),
                new Card(7, 7),
                new Card(8, 8)
            });
        }

        public static bool PlayersAreAlive(IPlayer player1, IPlayer player2)
        {
            return player1.IsPlayerAlive() && player2.IsPlayerAlive();
        }

        private void unnededMethod()
        {
        }
    }
}