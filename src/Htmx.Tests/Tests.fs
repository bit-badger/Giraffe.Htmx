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

    [<Fact>]
    let ``HxPrompt succeeds when the header is not present`` () =
        let ctx = Substitute.For<HttpContext> ()
        ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
        Option.isNone ctx.Request.Headers.HxPrompt |> Assert.True
  
    [<Fact>]
    let ``HxPrompt succeeds when the header is present`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Prompt", "of course")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Option.isSome ctx.Request.Headers.HxPrompt |> Assert.True
        Assert.Equal("of course", Option.get ctx.Request.Headers.HxPrompt)

    [<Fact>]
    let ``HxRequest succeeds when the header is not present`` () =
        let ctx = Substitute.For<HttpContext> ()
        ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
        Option.isNone ctx.Request.Headers.HxRequest |> Assert.True
  
    [<Fact>]
    let ``HxRequest succeeds when the header is present and true`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Request", "true")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Option.isSome ctx.Request.Headers.HxRequest |> Assert.True
        Option.get ctx.Request.Headers.HxRequest |> Assert.True

    [<Fact>]
    let ``HxRequest succeeds when the header is present and false`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Request", "false")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Option.isSome ctx.Request.Headers.HxRequest |> Assert.True
        Option.get ctx.Request.Headers.HxRequest |> Assert.False

    [<Fact>]
    let ``HxTarget succeeds when the header is not present`` () =
        let ctx = Substitute.For<HttpContext> ()
        ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
        Option.isNone ctx.Request.Headers.HxTarget |> Assert.True
  
    [<Fact>]
    let ``HxTarget succeeds when the header is present`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Target", "#leItem")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Option.isSome ctx.Request.Headers.HxTarget |> Assert.True
        Assert.Equal("#leItem", Option.get ctx.Request.Headers.HxTarget)

    [<Fact>]
    let ``HxTrigger succeeds when the header is not present`` () =
        let ctx = Substitute.For<HttpContext> ()
        ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
        Option.isNone ctx.Request.Headers.HxTrigger |> Assert.True
  
    [<Fact>]
    let ``HxTrigger succeeds when the header is present`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Trigger", "#trig")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Option.isSome ctx.Request.Headers.HxTrigger |> Assert.True
        Assert.Equal("#trig", Option.get ctx.Request.Headers.HxTrigger)

    [<Fact>]
    let ``HxTriggerName succeeds when the header is not present`` () =
        let ctx = Substitute.For<HttpContext> ()
        ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
        Option.isNone ctx.Request.Headers.HxTriggerName |> Assert.True
  
    [<Fact>]
    let ``HxTriggerName succeeds when the header is present`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Trigger-Name", "click")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Option.isSome ctx.Request.Headers.HxTriggerName |> Assert.True
        Assert.Equal("click", Option.get ctx.Request.Headers.HxTriggerName)


/// Tests for the HttpRequest extension properties
module HttpRequestExtensions =
  
    [<Fact>]
    let ``IsHtmx succeeds when request is not from htmx`` () =
        let ctx = Substitute.For<HttpContext> ()
        ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
        Assert.False ctx.Request.IsHtmx
  
    [<Fact>]
    let ``IsHtmx succeeds when request is from htmx`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Request", "true")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Assert.True ctx.Request.IsHtmx
  
    [<Fact>]
    let ``IsHtmxRefresh succeeds when request is not from htmx`` () =
        let ctx = Substitute.For<HttpContext> ()
        ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
        Assert.False ctx.Request.IsHtmxRefresh

    [<Fact>]
    let ``IsHtmxRefresh succeeds when request is from htmx, but not a refresh`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Request", "true")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Assert.False ctx.Request.IsHtmxRefresh

    [<Fact>]
    let ``IsHtmxRefresh succeeds when request is from htmx and is a refresh`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        dic.Add ("HX-Request", "true")
        dic.Add ("HX-History-Restore-Request", "true")
        ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
        Assert.True ctx.Request.IsHtmxRefresh


/// Tests for the HttpHandler functions provided in the Handlers module
module HandlerTests =
  
    open System.Threading.Tasks
    
    /// Dummy "next" parameter to get the pipeline to execute/terminate
    let next (ctx : HttpContext) = Task.FromResult (Some ctx)
    
    [<Fact>]
    let ``withHxPushUrl succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxPushUrl "/a-new-url" next ctx
            Assert.True (dic.ContainsKey "HX-Push-Url")
            Assert.Equal ("/a-new-url", dic["HX-Push-Url"][0])
        }

    [<Fact>]
    let ``withHxNoPushUrl succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxNoPushUrl next ctx
            Assert.True (dic.ContainsKey "HX-Push-Url")
            Assert.Equal ("false", dic["HX-Push-Url"][0])
        }

    [<Fact>]
    let ``withHxRedirect succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxRedirect "/somewhere-else" next ctx
            Assert.True (dic.ContainsKey "HX-Redirect")
            Assert.Equal ("/somewhere-else", dic["HX-Redirect"][0])
        }

    [<Fact>]
    let ``withHxRefresh succeeds when set to true`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxRefresh true next ctx
            Assert.True (dic.ContainsKey "HX-Refresh")
            Assert.Equal ("true", dic["HX-Refresh"][0])
        }

    [<Fact>]
    let ``withHxRefresh succeeds when set to false`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxRefresh false next ctx
            Assert.True (dic.ContainsKey "HX-Refresh")
            Assert.Equal ("false", dic["HX-Refresh"][0])
        }

    [<Fact>]
    let ``withHxReplaceUrl succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxReplaceUrl "/a-substitute-url" next ctx
            Assert.True (dic.ContainsKey "HX-Replace-Url")
            Assert.Equal ("/a-substitute-url", dic["HX-Replace-Url"][0])
        }

    [<Fact>]
    let ``withHxNoReplaceUrl succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxNoReplaceUrl next ctx
            Assert.True (dic.ContainsKey "HX-Replace-Url")
            Assert.Equal ("false", dic["HX-Replace-Url"][0])
        }

    [<Fact>]
    let ``withHxReswap succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxReswap HxSwap.BeforeEnd next ctx
            Assert.True (dic.ContainsKey "HX-Reswap")
            Assert.Equal (HxSwap.BeforeEnd, dic["HX-Reswap"][0])
        }
      
    [<Fact>]
    let ``withHxRetarget succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxRetarget "#somewhereElse" next ctx
            Assert.True (dic.ContainsKey "HX-Retarget")
            Assert.Equal ("#somewhereElse", dic["HX-Retarget"][0])
        }
      
    [<Fact>]
    let ``withHxTrigger succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxTrigger "doSomething" next ctx
            Assert.True (dic.ContainsKey "HX-Trigger")
            Assert.Equal ("doSomething", dic["HX-Trigger"][0])
        }

    [<Fact>]
    let ``withHxTriggerMany succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxTriggerMany [ "blah", "foo"; "bleh", "bar" ] next ctx
            Assert.True (dic.ContainsKey "HX-Trigger")
            Assert.Equal ("""{ "blah": "foo", "bleh": "bar" }""", dic["HX-Trigger"][0])
        }

    [<Fact>]
    let ``withHxTriggerAfterSettle succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxTriggerAfterSettle "byTheWay" next ctx
            Assert.True (dic.ContainsKey "HX-Trigger-After-Settle")
            Assert.Equal ("byTheWay", dic["HX-Trigger-After-Settle"][0])
        }

    [<Fact>]
    let ``withHxTriggerManyAfterSettle succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxTriggerManyAfterSettle [ "oof", "ouch"; "hmm", "uh" ] next ctx
            Assert.True (dic.ContainsKey "HX-Trigger-After-Settle")
            Assert.Equal ("""{ "oof": "ouch", "hmm": "uh" }""", dic["HX-Trigger-After-Settle"][0])
        }

    [<Fact>]
    let ``withHxTriggerAfterSwap succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxTriggerAfterSwap "justASec" next ctx
            Assert.True (dic.ContainsKey "HX-Trigger-After-Swap")
            Assert.Equal ("justASec", dic["HX-Trigger-After-Swap"][0])
        }

    [<Fact>]
    let ``withHxTriggerManyAfterSwap succeeds`` () =
        let ctx = Substitute.For<HttpContext> ()
        let dic = HeaderDictionary ()
        ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
        task {
            let! _ = withHxTriggerManyAfterSwap [ "this", "1"; "that", "2" ] next ctx
            Assert.True (dic.ContainsKey "HX-Trigger-After-Swap")
            Assert.Equal ("""{ "this": "1", "that": "2" }""", dic["HX-Trigger-After-Swap"][0])
        }
