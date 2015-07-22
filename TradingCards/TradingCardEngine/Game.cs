using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TradingCardEngine
{
    public class Game
    {
        public void GameLoop()
        {

            var player1 = new Dictionary<string, int> {{"life", 30}, {"Mana", 0}};
            var player2 = new Dictionary<string, int> { { "life", 30 }, { "Mana", 0 } };

            var player1Cards = new List<int> {0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8};
            var player2Cards = new List<int> {0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };

            Random rand1 = new Random();
            Random rand2 = new Random();

            var value1 = rand1.Next(player1Cards.Count);
            var player1Hand = new List<int>();
            player1Hand.Add(player1Cards[value1]);
            player1Cards.RemoveAt(value1);
            value1 = rand1.Next(player1Cards.Count);
            player1Hand.Add(player1Cards[value1]);
            player1Cards.RemoveAt(value1);
            value1 = rand1.Next(player1Cards.Count);
            player1Hand.Add(player1Cards[value1]);
            player1Cards.RemoveAt(value1);

            var value2 = rand1.Next(player2Cards.Count);
            var player2Hand = new List<int>();
            player2Hand.Add(player2Cards[value2]);
            player2Cards.RemoveAt(value2);
            value2 = rand2.Next(player2Cards.Count);
            player2Hand.Add(player2Cards[value2]);
            player2Cards.RemoveAt(value2);
            value2 = rand2.Next(player2Cards.Count);
            player2Hand.Add(player2Cards[value2]);
            player2Cards.RemoveAt(value2);

            var playerTurn = 1;
            while (player1["life"] != 0 && player2["life"] != 0)
            {
                Console.WriteLine(String.Format("Player1 Life :{0} Mana: {1}", player1["life"], player1["Mana"]));
                Console.WriteLine(String.Format("Player2 Life :{0} Mana: {1}", player2["life"], player2["Mana"]));
                if (playerTurn == 1)
                {
                    if (player1["Mana"] < 10)
                    {
                        player1["Mana"] = player1["Mana"] + 1;
                    }

                    if (player1Cards.Count > 0)
                    {
                        value1 = rand1.Next(player1Cards.Count);
                        player1Hand.Add(player1Cards[value1]);
                        player1Cards.RemoveAt(value1);
                    }
                    else
                    {
                        player1["life"] = player1["life"] - 1;
                    }

                    if (player1Hand.Count > 5)
                    {
                        player1Hand.RemoveAt(player1Hand.Count - 1);
                    }

                    var canPlay = true;
                    while (canPlay)
                    {
                        Console.WriteLine("Play a card from the following set: " + String.Join(",", player1Hand));
                        Console.WriteLine("Press P to pass");
                        var read = Console.ReadLine();

                        if (read != "p")
                        {
                            var value = int.Parse(read);
                            player2["life"] = player2["life"] - value;
                            player1Hand.Remove(value);
                        }

                        if (player1Hand.Count == 0 || read == "p")
                        {
                            canPlay = false;
                        }
                    }

                    playerTurn = 2;
                }
                else
                {
                    if (player2["Mana"] < 10)
                    {
                        player2["Mana"] = player2["Mana"] + 1;
                    }

                    if (player2Cards.Count > 0)
                    {
                        value1 = rand1.Next(player2Cards.Count);
                        player2Hand.Add(player2Cards[value1]);
                        player2Cards.RemoveAt(value1);
                    }
                    else
                    {
                        player2["life"] = player2["life"] - 1;
                    }

                    if (player2Hand.Count > 5)
                    {
                        player2Hand.RemoveAt(player2Hand.Count - 1);
                    }

                    var canPlay = true;
                    while (canPlay)
                    {
                        Console.WriteLine("Play a card from the following set: " + String.Join(",", player2Hand));
                        Console.WriteLine("Press P to pass");
                        var read = Console.ReadLine();

                        if (read != "p")
                        {
                            var value = int.Parse(read);
                            player1["life"] = player1["life"] - value;
                            player2Hand.Remove(value);
                        }

                        if (player2Hand.Count == 0 || read == "p")
                        {
                            canPlay = false;
                        }
                    }

                    playerTurn = 1;
                }
            }
        } 
    }
}