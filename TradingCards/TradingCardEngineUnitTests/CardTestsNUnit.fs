namespace TradingCardEngineUnitTests

module CardTestsNUnit = 
    open NUnit.Framework
    open FsUnit
    open TradingCardEngine

    [<Test>]
    [<Category("NUnit")>]
    let ``Create card with values and check Cost`` () =
        let card = Card(4,5)
        Assert.AreEqual(4, card.Cost)
