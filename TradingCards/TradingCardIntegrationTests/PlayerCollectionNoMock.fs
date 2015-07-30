namespace TradingCardIntegrationTests

module PlayerCollectionNoMock =
    open NUnit.Framework
    open FsUnit
    open NSubstitute
    open TradingCardEngine

    [<Test>]
    let ``Test that I can add a card to my hand`` () =
        let deck = {
            new ICardCollection with
                member this.GetRandom() =
                    new Card(4,5)
                member this.RemoveCard card =
                    ()
                member this.Count =
                    1
                member this.AddCard card =
                    ()
                member this.RemoveLast () = 
                    ()
                member this.ShowAsString () =
                    string Empty
                member this.RemoveCardWithValue value = 
                    ()
        }

        let player = new Player()
        player.SetDeck deck
        player.HandCount |> should equal 0
        player.AddCardToHand ()
        player.HandCount |> should equal 1

