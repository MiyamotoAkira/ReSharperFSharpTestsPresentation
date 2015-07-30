namespace TradingCardEngineUnitTests

module CardTestsFSUnit = 
    open NUnit.Framework
    open FsUnit
    open TradingCardEngine

    [<Test>]
    [<Category("FsUnit")>]
    let ``Create card with values and check Damage`` () =
        let card = Card(4,5)
        card.Damage |> should equal 5

