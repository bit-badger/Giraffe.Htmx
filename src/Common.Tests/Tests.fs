module Tests

open Giraffe.Htmx
open Xunit

/// Tests for the HxSwap module
module Swap =

    [<Fact>]
    let ``InnerHtml is correct`` () =
        Assert.Equal ("innerHTML", HxSwap.InnerHtml)

    [<Fact>]
    let ``OuterHtml is correct`` () =
        Assert.Equal ("outerHTML", HxSwap.OuterHtml)

    [<Fact>]
    let ``BeforeBegin is correct`` () =
        Assert.Equal ("beforebegin", HxSwap.BeforeBegin)

    [<Fact>]
    let ``BeforeEnd is correct`` () =
        Assert.Equal ("beforeend", HxSwap.BeforeEnd)

    [<Fact>]
    let ``AfterBegin is correct`` () =
        Assert.Equal ("afterbegin", HxSwap.AfterBegin)

    [<Fact>]
    let ``AfterEnd is correct`` () =
        Assert.Equal ("afterend", HxSwap.AfterEnd)

    [<Fact>]
    let ``None is correct`` () =
        Assert.Equal ("none", HxSwap.None)
