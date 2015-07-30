namespace TradingCardIntegrationTests

module PlayerCollectionFoq =
    open NUnit.Framework
    open FsUnit
    open Foq
    open TradingCardEngine

    [<Test>]
    let ``Test that I can add a card to my hand`` () =
        let deck = Mock<ICardCollection>()
                    .Setup(fun x -> <@ x.GetRandom() @>).Returns(new Card (4,5))
                    .Create()
        
        let player = new Player()
        player.SetDeck deck 
        player.HandCount |> should equal 0
        player.AddCardToHand ()
        player.HandCount |> should equal 1