module Giraffe.Htmx.Tests

open System
open Giraffe.Htmx
open Microsoft.AspNetCore.Http
open NSubstitute
open Xunit

/// Tests for the IHeaderDictionary extension properties
module IHeaderDictionaryExtensions =
  
  [<Fact>]
  let ``HxBoosted succeeds when the header is not present`` () =
    let ctx = Substitute.For<HttpContext> ()
    ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
    Option.isNone ctx.Request.Headers.HxBoosted |> Assert.True
  
  [<Fact>]
  let ``HxBoosted succeeds when the header is present and true`` () =
    let ctx = Substitute.For<HttpContext> ()
    let dic = HeaderDictionary ()
    dic.Add ("HX-Boosted", "true")
    ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
    Option.isSome ctx.Request.Headers.HxBoosted |> Assert.True
    Option.get ctx.Request.Headers.HxBoosted |> Assert.True

  [<Fact>]
  let ``HxBoosted succeeds when the header is present and false`` () =
    let ctx = Substitute.For<HttpContext> ()
    let dic = HeaderDictionary ()
    dic.Add ("HX-Boosted", "false")
    ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
    Option.isSome ctx.Request.Headers.HxBoosted |> Assert.True
    Option.get ctx.Request.Headers.HxBoosted |> Assert.False

  [<Fact>]
  let ``HxCurrentUrl succeeds when the header is not present`` () =
    let ctx = Substitute.For<HttpContext> ()
    ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
    Option.isNone ctx.Request.Headers.HxCurrentUrl |> Assert.True
  
  [<Fact>]
  let ``HxCurrentUrl succeeds when the header is present`` () =
    let ctx = Substitute.For<HttpContext> ()
    let dic = HeaderDictionary ()
    dic.Add ("HX-Current-URL", "http://localhost/test.htm")
    ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
    Option.isSome ctx.Request.Headers.HxCurrentUrl |> Assert.True
    Assert.Equal (Uri "http://localhost/test.htm", Option.get ctx.Request.Headers.HxCurrentUrl)
  
  [<Fact>]
  let ``HxHistoryRestoreRequest succeeds when the header is not present`` () =
    let ctx = Substitute.For<HttpContext> ()
    ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
    Option.isNone ctx.Request.Headers.HxHistoryRestoreRequest |> Assert.True
  
  [<Fact>]
  let ``HxHistoryRestoreRequest succeeds when the header is present and true`` () =
    let ctx = Substitute.For<HttpContext> ()
    let dic = HeaderDictionary ()
    dic.Add ("HX-History-Restore-Request", "true")
    ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
    Option.isSome ctx.Request.Headers.HxHistoryRestoreRequest |> Assert.True
    Option.get ctx.Request.Headers.HxHistoryRestoreRequest |> Assert.True

  [<Fact>]
  let ``HxHistoryRestoreRequest succeeds when the header is present and false`` () =
    let ctx = Substitute.For<HttpContext> ()
    let dic = HeaderDictionary ()
    dic.Add ("HX-History-Restore-Request", "false")
    ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
    Option.isSome ctx.Request.Headers.HxHistoryRestoreRequest |> Assert.True
    Option.get ctx.Request.Headers.HxHistoryRestoreRequest |> Assert.False


