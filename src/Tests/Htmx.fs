module Htmx

open System
open Expecto
open Giraffe.Htmx
open Microsoft.AspNetCore.Http
open NSubstitute

/// Tests for the IHeaderDictionary extension properties
let dictExtensions =
    testList "IHeaderDictionaryExtensions" [
        testList "HxBoosted" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxBoosted "There should not have been a header returned"
            }
            test "succeeds when the header is present and true" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Boosted", "true")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxBoosted "There should be a header present"
                Expect.isTrue ctx.Request.Headers.HxBoosted.Value "The header value should have been true"
            }
            test "succeeds when the header is present and false" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Boosted", "false")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxBoosted "There should be a header present"
                Expect.isFalse ctx.Request.Headers.HxBoosted.Value "The header value should have been false"
            }
        ]
        testList "HxCurrentUrl" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxCurrentUrl "There should not have been a header returned"
            }
            test "succeeds when the header is present" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Current-URL", "http://localhost/test.htm")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxCurrentUrl "There should be a header present"
                Expect.equal
                    ctx.Request.Headers.HxCurrentUrl.Value (Uri "http://localhost/test.htm")
                    "The header value was not correct"
            }
        ]
        testList "HxHistoryRestoreRequest" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxHistoryRestoreRequest "There should not have been a header returned"
            }
            test "succeeds when the header is present and true" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-History-Restore-Request", "true")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxHistoryRestoreRequest "There should be a header present"
                Expect.isTrue ctx.Request.Headers.HxHistoryRestoreRequest.Value "The header value should have been true"
            }
            test "succeeds when the header is present and false" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-History-Restore-Request", "false")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxHistoryRestoreRequest "There should be a header present"
                Expect.isFalse
                    ctx.Request.Headers.HxHistoryRestoreRequest.Value "The header should have been false"
            }
        ]
        testList "HxPrompt" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxPrompt "There should not have been a header returned"
            }
            test "succeeds when the header is present" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Prompt", "of course")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxPrompt "There should be a header present"
                Expect.equal ctx.Request.Headers.HxPrompt.Value "of course" "The header value was incorrect"
            }
        ]
        testList "HxRequest" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxRequest "There should not have been a header returned"
            }
            test "succeeds when the header is present and true" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Request", "true")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxRequest "There should be a header present"
                Expect.isTrue ctx.Request.Headers.HxRequest.Value "The header should have been true"
            }
            test "succeeds when the header is present and false" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Request", "false")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxRequest "There should be a header present"
                Expect.isFalse ctx.Request.Headers.HxRequest.Value "The header should have been false"
            }
        ]
        testList "HxTarget" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxTarget "There should not have been a header returned"
            }
            test "succeeds when the header is present" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Target", "#leItem")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxTarget "There should be a header present"
                Expect.equal ctx.Request.Headers.HxTarget.Value "#leItem" "The header value was incorrect"
            }
        ]
        testList "HxTrigger" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxTrigger "There should not have been a header returned"
            }
            test "succeeds when the header is present" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Trigger", "#trig")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxTrigger "There should be a header present"
                Expect.equal ctx.Request.Headers.HxTrigger.Value "#trig" "The header value was incorrect"
            }
        ]
        testList "HxTriggerName" [
            test "succeeds when the header is not present" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isNone ctx.Request.Headers.HxTriggerName "There should not have been a header returned"
            }
            test "HxTriggerName succeeds when the header is present" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Trigger-Name", "click")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isSome ctx.Request.Headers.HxTriggerName "There should be a header present"
                Expect.equal ctx.Request.Headers.HxTriggerName.Value "click" "The header value was incorrect"
            }
        ]
    ]

/// Tests for the HttpRequest extension properties
let reqExtensions =
    testList "HttpRequestExtensions" [
        testList "IsHtmx" [
            test "succeeds when request is not from htmx" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isFalse ctx.Request.IsHtmx "The request should not be an htmx request"
            }    
            test "succeeds when request is from htmx" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Request", "true")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isTrue ctx.Request.IsHtmx "The request should have been an htmx request"
            }
        ]
        testList "IsHtmxRefresh" [
            test "succeeds when request is not from htmx" {
                let ctx = Substitute.For<HttpContext> ()
                ctx.Request.Headers.ReturnsForAnyArgs (HeaderDictionary ()) |> ignore
                Expect.isFalse ctx.Request.IsHtmxRefresh "The request should not have been an htmx refresh"
            }
            test "succeeds when request is from htmx, but not a refresh" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Request", "true")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isFalse ctx.Request.IsHtmxRefresh "The request should not have been an htmx refresh"
            }
            test "IsHtmxRefresh succeeds when request is from htmx and is a refresh" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                dic.Add ("HX-Request", "true")
                dic.Add ("HX-History-Restore-Request", "true")
                ctx.Request.Headers.ReturnsForAnyArgs dic |> ignore
                Expect.isTrue ctx.Request.IsHtmxRefresh "The request should have been an htmx refresh"
            }
        ]
    ]

open System.Threading.Tasks

/// Dummy "next" parameter to get the pipeline to execute/terminate
let next (ctx : HttpContext) = Task.FromResult (Some ctx)
        
/// Tests for the HttpHandler functions provided in the Handlers module
let handlers =
    testList "HandlerTests" [
        testTask "withHxPushUrl succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxPushUrl "/a-new-url" next ctx
            Expect.isTrue (dic.ContainsKey "HX-Push-Url") "The HX-Push-Url header should be present"
            Expect.equal dic["HX-Push-Url"].[0] "/a-new-url" "The HX-Push-Url value was incorrect"
        }
        testTask "withHxNoPushUrl succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxNoPushUrl next ctx
            Expect.isTrue (dic.ContainsKey "HX-Push-Url") "The HX-Push-Url header should be present"
            Expect.equal dic["HX-Push-Url"].[0] "false" "The HX-Push-Url value was incorrect"
        }
        testTask "withHxRedirect succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxRedirect "/somewhere-else" next ctx
            Expect.isTrue (dic.ContainsKey "HX-Redirect") "The HX-Redirect header should be present"
            Expect.equal dic["HX-Redirect"].[0] "/somewhere-else" "The HX-Redirect value was incorrect"
        }
        testList "withHxRefresh" [
            testTask "succeeds when set to true" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
                let! _ = withHxRefresh true next ctx
                Expect.isTrue (dic.ContainsKey "HX-Refresh") "The HX-Refresh header should be present"
                Expect.equal dic["HX-Refresh"].[0] "true" "The HX-Refresh value was incorrect"
            }
            testTask "succeeds when set to false" {
                let ctx = Substitute.For<HttpContext> ()
                let dic = HeaderDictionary ()
                ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
                let! _ = withHxRefresh false next ctx
                Expect.isTrue (dic.ContainsKey "HX-Refresh") "The HX-Refresh header should be present"
                Expect.equal dic["HX-Refresh"].[0] "false" "The HX-Refresh value was incorrect"
            }
        ]
        testTask "withHxReplaceUrl succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxReplaceUrl "/a-substitute-url" next ctx
            Expect.isTrue (dic.ContainsKey "HX-Replace-Url") "The HX-Replace-Url header should be present"
            Expect.equal dic["HX-Replace-Url"].[0] "/a-substitute-url" "The HX-Replace-Url value was incorrect"
        }
        testTask "withHxNoReplaceUrl succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxNoReplaceUrl next ctx
            Expect.isTrue (dic.ContainsKey "HX-Replace-Url") "The HX-Replace-Url header should be present"
            Expect.equal dic["HX-Replace-Url"].[0] "false" "The HX-Replace-Url value was incorrect"
        }
        testTask "withHxReswap succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxReswap HxSwap.BeforeEnd next ctx
            Expect.isTrue (dic.ContainsKey "HX-Reswap") "The HX-Reswap header should be present"
            Expect.equal dic["HX-Reswap"].[0] HxSwap.BeforeEnd "The HX-Reswap value was incorrect"
        } 
        testTask "withHxRetarget succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxRetarget "#somewhereElse" next ctx
            Expect.isTrue (dic.ContainsKey "HX-Retarget") "The HX-Retarget header should be present"
            Expect.equal dic["HX-Retarget"].[0] "#somewhereElse" "The HX-Retarget value was incorrect"
        }
        testTask "withHxTrigger succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxTrigger "doSomething" next ctx
            Expect.isTrue (dic.ContainsKey "HX-Trigger") "The HX-Trigger header should be present"
            Expect.equal dic["HX-Trigger"].[0] "doSomething" "The HX-Trigger value was incorrect"
        }
        testTask "withHxTriggerMany succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxTriggerMany [ "blah", "foo"; "bleh", "bar" ] next ctx
            Expect.isTrue (dic.ContainsKey "HX-Trigger") "The HX-Trigger header should be present"
            Expect.equal
                dic["HX-Trigger"].[0] """{ "blah": "foo", "bleh": "bar" }""" "The HX-Trigger value was incorrect"
        }
        testTask "withHxTriggerAfterSettle succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxTriggerAfterSettle "byTheWay" next ctx
            Expect.isTrue
                (dic.ContainsKey "HX-Trigger-After-Settle") "The HX-Trigger-After-Settle header should be present"
            Expect.equal dic["HX-Trigger-After-Settle"].[0] "byTheWay" "The HX-Trigger-After-Settle value was incorrect"
        }
        testTask "withHxTriggerManyAfterSettle succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxTriggerManyAfterSettle [ "oof", "ouch"; "hmm", "uh" ] next ctx
            Expect.isTrue
                (dic.ContainsKey "HX-Trigger-After-Settle") "The HX-Trigger-After-Settle header should be present"
            Expect.equal
                dic["HX-Trigger-After-Settle"].[0] """{ "oof": "ouch", "hmm": "uh" }"""
                "The HX-Trigger-After-Settle value was incorrect"
        }
        testTask "withHxTriggerAfterSwap succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxTriggerAfterSwap "justASec" next ctx
            Expect.isTrue (dic.ContainsKey "HX-Trigger-After-Swap") "The HX-Trigger-After-Swap header should be present"
            Expect.equal dic["HX-Trigger-After-Swap"].[0] "justASec" "The HX-Trigger-After-Swap value was incorrect"
        }
        testTask "withHxTriggerManyAfterSwap succeeds" {
            let ctx = Substitute.For<HttpContext> ()
            let dic = HeaderDictionary ()
            ctx.Response.Headers.ReturnsForAnyArgs dic |> ignore
            let! _ = withHxTriggerManyAfterSwap [ "this", "1"; "that", "2" ] next ctx
            Expect.isTrue (dic.ContainsKey "HX-Trigger-After-Swap") "The HX-Trigger-After-Swap header should be present"
            Expect.equal
                dic["HX-Trigger-After-Swap"].[0] """{ "this": "1", "that": "2" }"""
                "The HX-Trigger-After-Swap value was incorrect"
        }
    ]

/// All tests for this module
let allTests = testList "Htmx" [ dictExtensions; reqExtensions; handlers ]
