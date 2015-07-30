namespace TradingCardIntegrationTests

module PlayerCollectionNSubstitute =
    open NUnit.Framework
    open FsUnit
    open NSubstitute
    open TradingCardEngine

    [<Test>]
    let ``Test that I can add a card to my hand`` () =
        let deck = Substitute.For<ICardCollection> ()
        do deck.GetRandom().Returns( new Card (4, 5) ) |> ignore

        let player = new Player()
        player.SetDeck deck
        player.HandCount |> should equal 0
        player.AddCardToHand ()
        player.HandCount |> should equal 1
