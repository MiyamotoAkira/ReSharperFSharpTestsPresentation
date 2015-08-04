namespace TickSpeckTests

module StepDefinitions =
    open TickSpec
    open TradingCardEngine
    open NUnit.Framework

    let game = Game()
    let player = Player()

    let [<Given>] ``I have a player`` () =
        game.SetFirstPlayer player

    let [<Given>] ``the player has a deck`` () =
        game.SetFirstPlayerDeck ()

    let[<When>] ``I create the starting hand`` () =
        game.SetFirstPlayerHand ()

    let[<Then>] ``the player has three cards on his hand`` () =
        Assert.AreEqual(3, player.HandCount)
