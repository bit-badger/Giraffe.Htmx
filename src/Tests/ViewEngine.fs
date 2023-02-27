module ViewEngine

open Expecto
open Giraffe.ViewEngine

/// Tests for the HxEncoding module
let hxEncoding =
    testList "Encoding" [
        test "Form is correct" {
            Expect.equal ("application/x-www-form-urlencoded", HxEncoding.Form)
        }
        test "MultipartForm is correct" {
            Expect.equal ("multipart/form-data", HxEncoding.MultipartForm)
        }
    ]

/// Tests for the HxHeaders module
let hxHeaders =
    testList "Headers" [
        test "From succeeds with an empty list" {
            Expect.equal ("{  }", HxHeaders.From [])
        }
        test "From succeeds and escapes quotes" {
            Expect.equal ("{ \"test\": \"one two three\", \"again\": \"four \\\"five\\\" six\" }",
                         HxHeaders.From [ "test", "one two three"; "again", "four \"five\" six" ])
        }
    ]

/// Tests for the HxParams module
let hxParams =
    testList "Params" [
        test "All is correct" {
            Expect.equal ("*", HxParams.All)
        }
        test "None is correct" {
            Expect.equal ("none", HxParams.None)
        }
        test "With succeeds with empty list" {
            Expect.equal ("", HxParams.With [])
        }
        test "With succeeds with one list item" {
            Expect.equal ("boo", HxParams.With [ "boo" ])
        }
        test "With succeeds with multiple list items" {
            Expect.equal ("foo,bar,baz", HxParams.With [ "foo"; "bar"; "baz" ])
        }
        test "Except succeeds with empty list" {
            Expect.equal ("not ", HxParams.Except [])
        }
        test "Except succeeds with one list item" {
            Expect.equal ("not that", HxParams.Except [ "that" ])
        }
        test "Except succeeds with multiple list items" {
            Expect.equal ("not blue,green", HxParams.Except [ "blue"; "green" ])
        }
    ]

/// Tests for the HxRequest module
let hxRequest =
    testList "Request" [
        test "Configure succeeds with an empty list" {
            Expect.equal ("{  }", HxRequest.Configure [])
        }
        test "Configure succeeds with a non-empty list" {
            Expect.equal ("{ \"a\": \"b\", \"c\": \"d\" }", HxRequest.Configure [ "\"a\": \"b\""; "\"c\": \"d\"" ])
        }
        test "Configure succeeds with all known params configured" {
            Expect.equal ("{ \"timeout\": 1000, \"credentials\": false, \"noHeaders\": true }",
                        HxRequest.Configure [ HxRequest.Timeout 1000; HxRequest.Credentials false; HxRequest.NoHeaders true ])
        }
        test "Timeout succeeds" {
            Expect.equal ("\"timeout\": 50", HxRequest.Timeout 50)
        }
        test "Credentials succeeds when set to true" {
            Expect.equal ("\"credentials\": true", HxRequest.Credentials true)
        }
        test "Credentials succeeds when set to false" {
            Expect.equal ("\"credentials\": false", HxRequest.Credentials false)
        }
        test "NoHeaders succeeds when set to true" {
            Expect.equal ("\"noHeaders\": true", HxRequest.NoHeaders true)
        }
        test "NoHeaders succeeds when set to false" {
            Expect.equal ("\"noHeaders\": false", HxRequest.NoHeaders false)
        }
    ]

/// Tests for the HxTrigger module
let hxTrigger =
    testList "Trigger" [
        test "Click is correct" {
            Expect.equal ("click", HxTrigger.Click)
        }
        test "Load is correct" {
            Expect.equal ("load", HxTrigger.Load)
        }
        test "Revealed is correct" {
            Expect.equal ("revealed", HxTrigger.Revealed)
        }
        test "Every succeeds" {
            Expect.equal ("every 3s", HxTrigger.Every "3s")
        }
        test "Filter.Alt succeeds" {
            Expect.equal ("click[altKey]", HxTrigger.Filter.Alt HxTrigger.Click)
        }
        test "Filter.Ctrl succeeds" {
            Expect.equal ("click[ctrlKey]", HxTrigger.Filter.Ctrl HxTrigger.Click)
        }
        test "Filter.Shift succeeds" {
            Expect.equal ("click[shiftKey]", HxTrigger.Filter.Shift HxTrigger.Click)
        }
        test "Filter.CtrlAlt succeeds" {
            Expect.equal ("click[ctrlKey&&altKey]", HxTrigger.Filter.CtrlAlt HxTrigger.Click)
        }
        test "Filter.CtrlShift succeeds" {
            Expect.equal ("click[ctrlKey&&shiftKey]", HxTrigger.Filter.CtrlShift HxTrigger.Click)
        }
        test "Filter.CtrlAltShift succeeds" {
            Expect.equal ("click[ctrlKey&&altKey&&shiftKey]", HxTrigger.Filter.CtrlAltShift HxTrigger.Click)
        }
        test "Filter.AltShift succeeds" {
            Expect.equal ("click[altKey&&shiftKey]", HxTrigger.Filter.AltShift HxTrigger.Click)
        }
        test "Once succeeds when it is the first modifier" {
            Expect.equal ("once", HxTrigger.Once "")
        }
        test "Once succeeds when it is not the first modifier" {
            Expect.equal ("click once", HxTrigger.Once "click")
        }
        test "Changed succeeds when it is the first modifier" {
            Expect.equal ("changed", HxTrigger.Changed "")
        }
        test "Changed succeeds when it is not the first modifier" {
            Expect.equal ("click changed", HxTrigger.Changed "click")
        }
        test "Delay succeeds when it is the first modifier" {
            Expect.equal ("delay:1s", HxTrigger.Delay "1s" "")
        }
        test "Delay succeeds when it is not the first modifier" {
            Expect.equal ("click delay:2s", HxTrigger.Delay "2s" "click")
        }
        test "Throttle succeeds when it is the first modifier" {
            Expect.equal ("throttle:4s", HxTrigger.Throttle "4s" "")
        }
        test "Throttle succeeds when it is not the first modifier" {
            Expect.equal ("click throttle:7s", HxTrigger.Throttle "7s" "click")
        }
        test "From succeeds when it is the first modifier" {
            Expect.equal ("from:.nav", HxTrigger.From ".nav" "")
        }
        test "From succeeds when it is not the first modifier" {
            Expect.equal ("click from:#somewhere", HxTrigger.From "#somewhere" "click")
        }
        test "FromDocument succeeds when it is the first modifier" {
            Expect.equal ("from:document", HxTrigger.FromDocument "")
        } 
        test "FromDocument succeeds when it is not the first modifier" {
            Expect.equal ("click from:document", HxTrigger.FromDocument "click")
        }
        test "FromWindow succeeds when it is the first modifier" {
            Expect.equal ("from:window", HxTrigger.FromWindow "")
        }
        test "FromWindow succeeds when it is not the first modifier" {
            Expect.equal ("click from:window", HxTrigger.FromWindow "click")
        }
        test "FromClosest succeeds when it is the first modifier" {
            Expect.equal ("from:closest div", HxTrigger.FromClosest "div" "")
        }
        test "FromClosest succeeds when it is not the first modifier" {
            Expect.equal ("click from:closest p", HxTrigger.FromClosest "p" "click")
        }
        test "FromFind succeeds when it is the first modifier" {
            Expect.equal ("from:find li", HxTrigger.FromFind "li" "")
        }
        test "FromFind succeeds when it is not the first modifier" {
            Expect.equal ("click from:find .spot", HxTrigger.FromFind ".spot" "click")
        }
        test "Target succeeds when it is the first modifier" {
            Expect.equal ("target:main", HxTrigger.Target "main" "")
        }
        test "Target succeeds when it is not the first modifier" {
            Expect.equal ("click target:footer", HxTrigger.Target "footer" "click")
        }
        test "Consume succeeds when it is the first modifier" {
            Expect.equal ("consume", HxTrigger.Consume "")
        }
        test "Consume succeeds when it is not the first modifier" {
            Expect.equal ("click consume", HxTrigger.Consume "click")
        }
        test "Queue succeeds when it is the first modifier" {
            Expect.equal ("queue:abc", HxTrigger.Queue "abc" "")
        }
        test "Queue succeeds when it is not the first modifier" {
            Expect.equal ("click queue:def", HxTrigger.Queue "def" "click")
        }
        test "QueueFirst succeeds when it is the first modifier" {
            Expect.equal ("queue:first", HxTrigger.QueueFirst "")
        }
        test "QueueFirst succeeds when it is not the first modifier" {
            Expect.equal ("click queue:first", HxTrigger.QueueFirst "click")
        }
        test "QueueLast succeeds when it is the first modifier" {
            Expect.equal ("queue:last", HxTrigger.QueueLast "")
        }
        test "QueueLast succeeds when it is not the first modifier" {
            Expect.equal ("click queue:last", HxTrigger.QueueLast "click")
        }
        test "QueueAll succeeds when it is the first modifier" {
            Expect.equal ("queue:all", HxTrigger.QueueAll "")
        }
        test "QueueAll succeeds when it is not the first modifier" {
            Expect.equal ("click queue:all", HxTrigger.QueueAll "click")
        }
        test "QueueNone succeeds when it is the first modifier" {
            Expect.equal ("queue:none", HxTrigger.QueueNone "")
        }
        test "QueueNone succeeds when it is not the first modifier" {
            Expect.equal ("click queue:none", HxTrigger.QueueNone "click")
        }
    ]

/// Tests for the HxVals module
let hxVals =
    testList "Vals" [
        test "From succeeds with an empty list" {
            Expect.equal ("{  }", HxVals.From [])
        }
        test "From succeeds and escapes quotes" {
            Expect.equal ("{ \"test\": \"a \\\"b\\\" c\", \"2\": \"d e f\" }",
                        HxVals.From [ "test", "a \"b\" c"; "2", "d e f" ])
        }
    ]

/// Tests for the HtmxAttrs module
let attributes =
    testList "Attributes" [

        /// Pipe-able assertion for a rendered node 
        let shouldRender expected node = Expect.equal (expected, RenderView.AsString.htmlNode node)

        test "_hxBoost succeeds" {
            div [ _hxBoost ] [] |> shouldRender """<div hx-boost="true"></div>"""
        }
        test "_hxConfirm succeeds" {
            button [ _hxConfirm "REALLY?!?" ] [] |> shouldRender """<button hx-confirm="REALLY?!?"></button>"""
        }
        test "_hxDelete succeeds" {
            span [ _hxDelete "/this-endpoint" ] [] |> shouldRender """<span hx-delete="/this-endpoint"></span>"""
        }
        test "_hxDisable succeeds" {
            p [ _hxDisable ] [] |> shouldRender """<p hx-disable></p>"""
        }
        test "_hxDisinherit succeeds" {
            strong [ _hxDisinherit "*" ] [] |> shouldRender """<strong hx-disinherit="*"></strong>"""
        }
        test "_hxEncoding succeeds" {
            form [ _hxEncoding "utf-7" ] [] |> shouldRender """<form hx-encoding="utf-7"></form>"""
        }
        test "_hxExt succeeds" {
            section [ _hxExt "extendme" ] [] |> shouldRender """<section hx-ext="extendme"></section>"""
        }
        test "_hxGet succeeds" {
            article [ _hxGet "/the-text" ] [] |> shouldRender """<article hx-get="/the-text"></article>"""
        }
        test "_hxHeaders succeeds" {
            figure [ _hxHeaders """{ "X-Special-Header": "some-header" }""" ] []
            |> shouldRender """<figure hx-headers="{ &quot;X-Special-Header&quot;: &quot;some-header&quot; }"></figure>"""
        }
        test "_hxHistory succeeds" {
            span [ _hxHistory "false" ] [] |> shouldRender """<span hx-history="false"></span>"""
        }
        test "_hxHistoryElt succeeds" {
            table [ _hxHistoryElt ] [] |> shouldRender """<table hx-history-elt></table>"""
        }
        test "_hxInclude succeeds" {
            a [ _hxInclude ".extra-stuff" ] [] |> shouldRender """<a hx-include=".extra-stuff"></a>"""
        }
        test "_hxIndicator succeeds" {
            aside [ _hxIndicator "#spinner" ] [] |> shouldRender """<aside hx-indicator="#spinner"></aside>"""
        }
        test "_hxNoBoost succeeds" {
            td [ _hxNoBoost ] [] |> shouldRender """<td hx-boost="false"></td>"""
        }
        test "_hxParams succeeds" {
            br [ _hxParams "[p1,p2]" ] |> shouldRender """<br hx-params="[p1,p2]">"""
        }
        test "_hxPatch succeeds" {
            div [ _hxPatch "/arrrgh" ] [] |> shouldRender """<div hx-patch="/arrrgh"></div>"""
        }
        test "_hxPost succeeds" {
            hr [ _hxPost "/hear-ye-hear-ye" ] |> shouldRender """<hr hx-post="/hear-ye-hear-ye">"""
        }
        test "_hxPreserve succeeds" {
            img [ _hxPreserve ] |> shouldRender """<img hx-preserve="true">"""
        }
        test "_hxPrompt succeeds" {
            strong [ _hxPrompt "Who goes there?" ] [] |> shouldRender """<strong hx-prompt="Who goes there?"></strong>"""
        }
        test "_hxPushUrl succeeds" {
            dl [ _hxPushUrl "/a-b-c" ] [] |> shouldRender """<dl hx-push-url="/a-b-c"></dl>"""
        }
        test "_hxPut succeeds" {
            s [ _hxPut "/take-this" ] [] |> shouldRender """<s hx-put="/take-this"></s>"""
        }
        test "_hxReplaceUrl succeeds" {
            p [ _hxReplaceUrl "/something-else" ] [] |> shouldRender """<p hx-replace-url="/something-else"></p>"""
        }
        test "_hxRequest succeeds" {
            u [ _hxRequest "noHeaders" ] [] |> shouldRender """<u hx-request="noHeaders"></u>"""
        }
        test "_hxSelect succeeds" {
            nav [ _hxSelect "#navbar" ] [] |> shouldRender """<nav hx-select="#navbar"></nav>"""
        }
        test "_hxSelectOob succeeds" {
            section [ _hxSelectOob "#oob" ] [] |> shouldRender """<section hx-select-oob="#oob"></section>"""
        }
        test "_hxSse succeeds" {
            footer [ _hxSse "connect:/my-events" ] [] |> shouldRender """<footer hx-sse="connect:/my-events"></footer>"""
        }
        test "_hxSwap succeeds" {
            del [ _hxSwap "innerHTML" ] [] |> shouldRender """<del hx-swap="innerHTML"></del>"""
        }
        test "_hxSwapOob succeeds" {
            li [ _hxSwapOob "true" ] [] |> shouldRender """<li hx-swap-oob="true"></li>"""
        }
        test "_hxSync succeeds" {
            nav [ _hxSync "closest form:abort" ] [] |> shouldRender """<nav hx-sync="closest form:abort"></nav>"""
        }
        test "_hxTarget succeeds" {
            header [ _hxTarget "#somewhereElse" ] [] |> shouldRender """<header hx-target="#somewhereElse"></header>"""
        }
        test "_hxTrigger succeeds" {
            figcaption [ _hxTrigger "load" ] [] |> shouldRender """<figcaption hx-trigger="load"></figcaption>"""
        }
        test "_hxVals succeeds" {
            dt [ _hxVals """{ "extra": "values" }""" ] []
            |> shouldRender """<dt hx-vals="{ &quot;extra&quot;: &quot;values&quot; }"></dt>"""
        }
        test "_hxWs succeeds" {
            ul [ _hxWs "connect:/web-socket" ] [] |> shouldRender """<ul hx-ws="connect:/web-socket"></ul>"""
        }
    ]

/// Tests for the Script module
let script =
    testList "Script" [
        test "Script.minified succeeds" {
            let html = RenderView.AsString.htmlNode Script.minified
            Expect.equal
                ("""<script src="https://unpkg.com/htmx.org@1.8.5" integrity="sha384-7aHh9lqPYGYZ7sTHvzP1t3BAfLhYSTy9ArHdP3Xsr9/3TlGurYgcPBoFmXX2TX/w" crossorigin="anonymous"></script>""",
                html)
        }
        test "Script.unminified succeeds" {
            let html = RenderView.AsString.htmlNode Script.unminified
            Expect.equal
                ("""<script src="https://unpkg.com/htmx.org@1.8.5/dist/htmx.js" integrity="sha384-VgGOQitu5eD5qAdh1QPLvPeTt1X4/Iw9B2sfYw+p3xtTumxaRv+onip7FX+P6q30" crossorigin="anonymous"></script>""",
                html)
        }
    ]

open System.Text

/// Tests for the RenderFragment module
let renderFragment =
    testList "RenderFragment" [
        test "RenderFragment.findIdNode fails with a Text node" {
            Expect.isFalse (Option.isSome (RenderFragment.findIdNode "blue" (Text "")))
        }
        test "RenderFragment.findIdNode fails with a VoidElement without a matching ID" {
            Expect.isFalse (Option.isSome (RenderFragment.findIdNode "purple" (br [ _id "mauve" ])))
        }
        test "RenderFragment.findIdNode fails with a ParentNode with no children with a matching ID" {
            Expect.isFalse (Option.isSome (RenderFragment.findIdNode "green" (p [] [ str "howdy"; span [] [ str "huh" ] ])))
        }
        test "RenderFragment.findIdNode succeeds with a VoidElement with a matching ID" {
            let leNode = hr [ _id "groovy" ]
            let foundNode = RenderFragment.findIdNode "groovy" leNode
            Expect.isTrue (Option.isSome foundNode)
            Assert.Same (leNode, foundNode.Value)
        }
        test "RenderFragment.findIdNode succeeds with a ParentNode with a child with a matching ID" {
            let leNode = span [ _id "its-me" ] [ str "Mario" ]
            let foundNode = RenderFragment.findIdNode "its-me" (p [] [ str "test"; str "again"; leNode; str "un mas" ])
            Expect.isTrue (Option.isSome foundNode)
            Assert.Same (leNode, foundNode.Value)
        }
        /// Generate a message if the requested ID node is not found
        let private nodeNotFound (nodeId : string) =
            $"<em>&ndash; ID {nodeId} not found &ndash;</em>"

        /// Tests for the AsString module
        testList "AsString" [
            test "RenderFragment.AsString.htmlFromNodes succeeds when an ID is matched" {
                let html =
                    RenderFragment.AsString.htmlFromNodes "needle"
                        [ p [] []; p [ _id "haystack" ] [ span [ _id "needle" ] [ str "ouch" ]; str "hay"; str "hay" ]]
                Expect.equal ("""<span id="needle">ouch</span>""", html)
            }
            test "RenderFragment.AsString.htmlFromNodes fails when an ID is not matched" {
                Expect.equal (nodeNotFound "oops", RenderFragment.AsString.htmlFromNodes "oops" [])
            }
            test "RenderFragment.AsString.htmlFromNode succeeds when ID is matched at top level" {
                let html = RenderFragment.AsString.htmlFromNode "wow" (p [ _id "wow" ] [ str "found it" ])
                Expect.equal ("""<p id="wow">found it</p>""", html)
            }
            test "RenderFragment.AsString.htmlFromNode succeeds when ID is matched in child element" {
                let html =
                    div [] [ p [] [ str "not it" ]; p [ _id "hey" ] [ str "ta-da" ]]
                    |> RenderFragment.AsString.htmlFromNode "hey"
                Expect.equal ("""<p id="hey">ta-da</p>""", html)
            }
            test "RenderFragment.AsString.htmlFromNode fails when an ID is not matched" {
                Expect.equal (nodeNotFound "me", RenderFragment.AsString.htmlFromNode "me" (hr []))
            }
        ]
        /// Tests for the AsBytes module
        testList "AsBytes" [
            
            /// Alias for UTF-8 encoding
            let private utf8 = Encoding.UTF8

            test "RenderFragment.AsBytes.htmlFromNodes succeeds when an ID is matched" {
                let bytes =
                    RenderFragment.AsBytes.htmlFromNodes "found"
                        [ p [] []; p [ _id "not-it" ] [ str "nope"; span [ _id "found" ] [ str "boo" ]; str "nope" ]]
                Expect.equal<byte> (utf8.GetBytes """<span id="found">boo</span>""", bytes)
            }
            test "RenderFragment.AsBytes.htmlFromNodes fails when an ID is not matched" {
                Expect.equal<byte> (utf8.GetBytes (nodeNotFound "whiff"), RenderFragment.AsBytes.htmlFromNodes "whiff" [])
            }
            test "RenderFragment.AsBytes.htmlFromNode succeeds when ID is matched at top level" {
                let bytes = RenderFragment.AsBytes.htmlFromNode "first" (p [ _id "first" ] [ str "!!!" ])
                Expect.equal<byte> (utf8.GetBytes """<p id="first">!!!</p>""", bytes)
            }
            test "RenderFragment.AsBytes.htmlFromNode succeeds when ID is matched in child element" {
                let bytes =
                    div [] [ p [] [ str "not me" ]; p [ _id "child" ] [ str "node" ]]
                    |> RenderFragment.AsBytes.htmlFromNode "child"
                Expect.equal<byte> (utf8.GetBytes """<p id="child">node</p>""", bytes)
            }
            test "RenderFragment.AsBytes.htmlFromNode fails when an ID is not matched" {
                Expect.equal<byte> (utf8.GetBytes (nodeNotFound "foo"), RenderFragment.AsBytes.htmlFromNode "foo" (hr []))
            }
        ]
        /// Tests for the IntoStringBuilder module
        testList "IntoStringBuilder" [
            test "RenderFragment.IntoStringBuilder.htmlFromNodes succeeds when an ID is matched" {
                let sb = StringBuilder ()
                RenderFragment.IntoStringBuilder.htmlFromNodes sb "find-me"
                    [ p [] []; p [ _id "peekaboo" ] [ str "bzz"; str "nope"; span [ _id "find-me" ] [ str ";)" ] ]]
                Expect.equal ("""<span id="find-me">;)</span>""", string sb)
            }
            test "RenderFragment.IntoStringBuilder.htmlFromNodes fails when an ID is not matched" {
                let sb = StringBuilder ()
                RenderFragment.IntoStringBuilder.htmlFromNodes sb "missing" []
                Expect.equal (nodeNotFound "missing", string sb)
            }
            test "RenderFragment.IntoStringBuilder.htmlFromNode succeeds when ID is matched at top level" {
                let sb = StringBuilder ()
                RenderFragment.IntoStringBuilder.htmlFromNode sb "top" (p [ _id "top" ] [ str "pinnacle" ])
                Expect.equal ("""<p id="top">pinnacle</p>""", string sb)
            }
            test "RenderFragment.IntoStringBuilder.htmlFromNode succeeds when ID is matched in child element" {
                let sb = StringBuilder ()
                div [] [ p [] [ str "nada" ]; p [ _id "it" ] [ str "is here" ]]
                |> RenderFragment.IntoStringBuilder.htmlFromNode sb "it"
                Expect.equal ("""<p id="it">is here</p>""", string sb)
            }
            test "RenderFragment.IntoStringBuilder.htmlFromNode fails when an ID is not matched" {
                let sb = StringBuilder ()
                RenderFragment.IntoStringBuilder.htmlFromNode sb "bar" (hr [])
                Expect.equal (nodeNotFound "bar", string sb)
            }
        ]
    ]

/// All tests in this module
let allTests =
    testList "ViewEngine.Htmx"
             [ hxEncoding; hxHeaders; hxParams; hxRequest; hxTrigger; hxVals; attributes; script; renderFragment ]
