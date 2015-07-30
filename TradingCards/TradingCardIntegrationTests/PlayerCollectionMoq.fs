namespace TradingCardIntegrationTests

module PlayerCollectionMoq =
    open NUnit.Framework
    open FsUnit
    open Moq
    open TradingCardEngine

    [<Test>]
    let ``Test that I can add a card to my hand`` () =
        let deck = new Mock<ICardCollection> ()
        do (deck.Setup (fun x -> x.GetRandom())).Returns( new Card (4, 5)) |> ignore

        let player = new Player()
        player.SetDeck deck.Object
        player.HandCount |> should equal 0
        player.AddCardToHand ()
        player.HandCount |> should equal 1
