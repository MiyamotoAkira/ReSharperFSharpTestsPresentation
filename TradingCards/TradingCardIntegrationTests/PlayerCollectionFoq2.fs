namespace TradingCardIntegrationTests

module PlayerCollectionFoq2 =
    open NUnit.Framework
    open FsUnit
    open Foq
    open TradingCardEngine

    [<Test>]
    let ``Test that I can add a card to my hand`` () =
        let deck = Mock.With(fun (x : ICardCollection) -> <@ x.GetRandom () --> new Card(4,5) @>)

        let player = new Player()
        player.SetDeck deck 
        player.HandCount |> should equal 0
        player.AddCardToHand ()
        player.HandCount |> should equal 1