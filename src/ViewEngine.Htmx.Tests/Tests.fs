module Giraffe.ViewEngine.Htmx.Tests

open Giraffe.ViewEngine
open Xunit

/// Tests for the HxEncoding module
module Encoding =

    [<Fact>]
    let ``Form is correct`` () =
        Assert.Equal ("application/x-www-form-urlencoded", HxEncoding.Form)

    [<Fact>]
    let ``MultipartForm is correct`` () =
        Assert.Equal ("multipart/form-data", HxEncoding.MultipartForm)


/// Tests for the HxHeaders module
module Headers =

    [<Fact>]
    let ``From succeeds with an empty list`` () =
        Assert.Equal ("{  }", HxHeaders.From [])

    [<Fact>]
    let ``From succeeds and escapes quotes`` () =
        Assert.Equal ("{ \"test\": \"one two three\", \"again\": \"four \\\"five\\\" six\" }",
                      HxHeaders.From [ "test", "one two three"; "again", "four \"five\" six" ])


/// Tests for the HxParams module
module Params =

    [<Fact>]
    let ``All is correct`` () =
        Assert.Equal ("*", HxParams.All)

    [<Fact>]
    let ``None is correct`` () =
        Assert.Equal ("none", HxParams.None)

    [<Fact>]
    let ``With succeeds with empty list`` () =
        Assert.Equal ("", HxParams.With [])

    [<Fact>]
    let ``With succeeds with one list item`` () =
        Assert.Equal ("boo", HxParams.With [ "boo" ])

    [<Fact>]
    let ``With succeeds with multiple list items`` () =
        Assert.Equal ("foo,bar,baz", HxParams.With [ "foo"; "bar"; "baz" ])

    [<Fact>]
    let ``Except succeeds with empty list`` () =
        Assert.Equal ("not ", HxParams.Except [])

    [<Fact>]
    let ``Except succeeds with one list item`` () =
        Assert.Equal ("not that", HxParams.Except [ "that" ])

    [<Fact>]
    let ``Except succeeds with multiple list items`` () =
        Assert.Equal ("not blue,green", HxParams.Except [ "blue"; "green" ])


/// Tests for the HxRequest module
module Request =

    [<Fact>]
    let ``Configure succeeds with an empty list`` () =
        Assert.Equal ("{  }", HxRequest.Configure [])

    [<Fact>]
    let ``Configure succeeds with a non-empty list`` () =
        Assert.Equal ("{ \"a\": \"b\", \"c\": \"d\" }", HxRequest.Configure [ "\"a\": \"b\""; "\"c\": \"d\"" ])

    [<Fact>]
    let ``Configure succeeds with all known params configured`` () =
        Assert.Equal ("{ \"timeout\": 1000, \"credentials\": false, \"noHeaders\": true }",
                      HxRequest.Configure [ HxRequest.Timeout 1000; HxRequest.Credentials false; HxRequest.NoHeaders true ])

    [<Fact>]
    let ``Timeout succeeds`` () =
        Assert.Equal ("\"timeout\": 50", HxRequest.Timeout 50)

    [<Fact>]
    let ``Credentials succeeds when set to true`` () =
        Assert.Equal ("\"credentials\": true", HxRequest.Credentials true)

    [<Fact>]
    let ``Credentials succeeds when set to false`` () =
        Assert.Equal ("\"credentials\": false", HxRequest.Credentials false)

    [<Fact>]
    let ``NoHeaders succeeds when set to true`` () =
        Assert.Equal ("\"noHeaders\": true", HxRequest.NoHeaders true)

    [<Fact>]
    let ``NoHeaders succeeds when set to false`` () =
        Assert.Equal ("\"noHeaders\": false", HxRequest.NoHeaders false)

  
/// Tests for the HxTrigger module
module Trigger =

    [<Fact>]
    let ``Click is correct`` () =
        Assert.Equal ("click", HxTrigger.Click)

    [<Fact>]
    let ``Load is correct`` () =
        Assert.Equal ("load", HxTrigger.Load)

    [<Fact>]
    let ``Revealed is correct`` () =
        Assert.Equal ("revealed", HxTrigger.Revealed)

    [<Fact>]
    let ``Every succeeds`` () =
        Assert.Equal ("every 3s", HxTrigger.Every "3s")

    [<Fact>]
    let ``Filter.Alt succeeds`` () =
        Assert.Equal ("click[altKey]", HxTrigger.Filter.Alt HxTrigger.Click)

    [<Fact>]
    let ``Filter.Ctrl succeeds`` () =
        Assert.Equal ("click[ctrlKey]", HxTrigger.Filter.Ctrl HxTrigger.Click)

    [<Fact>]
    let ``Filter.Shift succeeds`` () =
        Assert.Equal ("click[shiftKey]", HxTrigger.Filter.Shift HxTrigger.Click)

    [<Fact>]
    let ``Filter.CtrlAlt succeeds`` () =
        Assert.Equal ("click[ctrlKey&&altKey]", HxTrigger.Filter.CtrlAlt HxTrigger.Click)

    [<Fact>]
    let ``Filter.CtrlShift succeeds`` () =
        Assert.Equal ("click[ctrlKey&&shiftKey]", HxTrigger.Filter.CtrlShift HxTrigger.Click)

    [<Fact>]
    let ``Filter.CtrlAltShift succeeds`` () =
        Assert.Equal ("click[ctrlKey&&altKey&&shiftKey]", HxTrigger.Filter.CtrlAltShift HxTrigger.Click)

    [<Fact>]
    let ``Filter.AltShift succeeds`` () =
        Assert.Equal ("click[altKey&&shiftKey]", HxTrigger.Filter.AltShift HxTrigger.Click)

    [<Fact>]
    let ``Once succeeds when it is the first modifier`` () =
        Assert.Equal ("once", HxTrigger.Once "")

    [<Fact>]
    let ``Once succeeds when it is not the first modifier`` () =
        Assert.Equal ("click once", HxTrigger.Once "click")

    [<Fact>]
    let ``Changed succeeds when it is the first modifier`` () =
        Assert.Equal ("changed", HxTrigger.Changed "")

    [<Fact>]
    let ``Changed succeeds when it is not the first modifier`` () =
        Assert.Equal ("click changed", HxTrigger.Changed "click")

    [<Fact>]
    let ``Delay succeeds when it is the first modifier`` () =
        Assert.Equal ("delay:1s", HxTrigger.Delay "1s" "")

    [<Fact>]
    let ``Delay succeeds when it is not the first modifier`` () =
        Assert.Equal ("click delay:2s", HxTrigger.Delay "2s" "click")

    [<Fact>]
    let ``Throttle succeeds when it is the first modifier`` () =
        Assert.Equal ("throttle:4s", HxTrigger.Throttle "4s" "")

    [<Fact>]
    let ``Throttle succeeds when it is not the first modifier`` () =
        Assert.Equal ("click throttle:7s", HxTrigger.Throttle "7s" "click")

    [<Fact>]
    let ``From succeeds when it is the first modifier`` () =
        Assert.Equal ("from:.nav", HxTrigger.From ".nav" "")

    [<Fact>]
    let ``From succeeds when it is not the first modifier`` () =
        Assert.Equal ("click from:#somewhere", HxTrigger.From "#somewhere" "click")

    [<Fact>]
    let ``FromDocument succeeds when it is the first modifier`` () =
        Assert.Equal ("from:document", HxTrigger.FromDocument "")
      
    [<Fact>]
    let ``FromDocument succeeds when it is not the first modifier`` () =
        Assert.Equal ("click from:document", HxTrigger.FromDocument "click")

    [<Fact>]
    let ``FromWindow succeeds when it is the first modifier`` () =
        Assert.Equal ("from:window", HxTrigger.FromWindow "")

    [<Fact>]
    let ``FromWindow succeeds when it is not the first modifier`` () =
        Assert.Equal ("click from:window", HxTrigger.FromWindow "click")

    [<Fact>]
    let ``FromClosest succeeds when it is the first modifier`` () =
        Assert.Equal ("from:closest div", HxTrigger.FromClosest "div" "")

    [<Fact>]
    let ``FromClosest succeeds when it is not the first modifier`` () =
        Assert.Equal ("click from:closest p", HxTrigger.FromClosest "p" "click")

    [<Fact>]
    let ``FromFind succeeds when it is the first modifier`` () =
        Assert.Equal ("from:find li", HxTrigger.FromFind "li" "")

    [<Fact>]
    let ``FromFind succeeds when it is not the first modifier`` () =
        Assert.Equal ("click from:find .spot", HxTrigger.FromFind ".spot" "click")

    [<Fact>]
    let ``Target succeeds when it is the first modifier`` () =
        Assert.Equal ("target:main", HxTrigger.Target "main" "")

    [<Fact>]
    let ``Target succeeds when it is not the first modifier`` () =
        Assert.Equal ("click target:footer", HxTrigger.Target "footer" "click")

    [<Fact>]
    let ``Consume succeeds when it is the first modifier`` () =
        Assert.Equal ("consume", HxTrigger.Consume "")

    [<Fact>]
    let ``Consume succeeds when it is not the first modifier`` () =
        Assert.Equal ("click consume", HxTrigger.Consume "click")

    [<Fact>]
    let ``Queue succeeds when it is the first modifier`` () =
        Assert.Equal ("queue:abc", HxTrigger.Queue "abc" "")

    [<Fact>]
    let ``Queue succeeds when it is not the first modifier`` () =
        Assert.Equal ("click queue:def", HxTrigger.Queue "def" "click")

    [<Fact>]
    let ``QueueFirst succeeds when it is the first modifier`` () =
        Assert.Equal ("queue:first", HxTrigger.QueueFirst "")

    [<Fact>]
    let ``QueueFirst succeeds when it is not the first modifier`` () =
        Assert.Equal ("click queue:first", HxTrigger.QueueFirst "click")

    [<Fact>]
    let ``QueueLast succeeds when it is the first modifier`` () =
        Assert.Equal ("queue:last", HxTrigger.QueueLast "")

    [<Fact>]
    let ``QueueLast succeeds when it is not the first modifier`` () =
        Assert.Equal ("click queue:last", HxTrigger.QueueLast "click")

    [<Fact>]
    let ``QueueAll succeeds when it is the first modifier`` () =
        Assert.Equal ("queue:all", HxTrigger.QueueAll "")

    [<Fact>]
    let ``QueueAll succeeds when it is not the first modifier`` () =
        Assert.Equal ("click queue:all", HxTrigger.QueueAll "click")

    [<Fact>]
    let ``QueueNone succeeds when it is the first modifier`` () =
        Assert.Equal ("queue:none", HxTrigger.QueueNone "")

    [<Fact>]
    let ``QueueNone succeeds when it is not the first modifier`` () =
        Assert.Equal ("click queue:none", HxTrigger.QueueNone "click")


/// Tests for the HxVals module
module Vals =

    [<Fact>]
    let ``From succeeds with an empty list`` () =
        Assert.Equal ("{  }", HxVals.From [])

    [<Fact>]
    let ``From succeeds and escapes quotes`` () =
        Assert.Equal ("{ \"test\": \"a \\\"b\\\" c\", \"2\": \"d e f\" }",
                      HxVals.From [ "test", "a \"b\" c"; "2", "d e f" ])


/// Tests for the HtmxAttrs module
module Attributes =

    /// Pipe-able assertion for a rendered node 
    let shouldRender expected node = Assert.Equal (expected, RenderView.AsString.htmlNode node)

    [<Fact>]
    let ``_hxBoost succeeds`` () =
        div [ _hxBoost ] [] |> shouldRender """<div hx-boost="true"></div>"""

    [<Fact>]
    let ``_hxConfirm succeeds`` () =
        button [ _hxConfirm "REALLY?!?" ] [] |> shouldRender """<button hx-confirm="REALLY?!?"></button>"""

    [<Fact>]
    let ``_hxDelete succeeds`` () =
        span [ _hxDelete "/this-endpoint" ] [] |> shouldRender """<span hx-delete="/this-endpoint"></span>"""

    [<Fact>]
    let ``_hxDisable succeeds`` () =
        p [ _hxDisable ] [] |> shouldRender """<p hx-disable></p>"""

    [<Fact>]
    let ``_hxDisinherit succeeds`` () =
        strong [ _hxDisinherit "*" ] [] |> shouldRender """<strong hx-disinherit="*"></strong>"""

    [<Fact>]
    let ``_hxEncoding succeeds`` () =
        form [ _hxEncoding "utf-7" ] [] |> shouldRender """<form hx-encoding="utf-7"></form>"""

    [<Fact>]
    let ``_hxExt succeeds`` () =
        section [ _hxExt "extendme" ] [] |> shouldRender """<section hx-ext="extendme"></section>"""

    [<Fact>]
    let ``_hxGet succeeds`` () =
        article [ _hxGet "/the-text" ] [] |> shouldRender """<article hx-get="/the-text"></article>"""

    [<Fact>]
    let ``_hxHeaders succeeds`` () =
        figure [ _hxHeaders """{ "X-Special-Header": "some-header" }""" ] []
        |> shouldRender """<figure hx-headers="{ &quot;X-Special-Header&quot;: &quot;some-header&quot; }"></figure>"""

    [<Fact>]
    let ``_hxHistory succeeds`` () =
        span [ _hxHistory "false" ] [] |> shouldRender """<span hx-history="false"></span>"""
    
    [<Fact>]
    let ``_hxHistoryElt succeeds`` () =
        table [ _hxHistoryElt ] [] |> shouldRender """<table hx-history-elt></table>"""

    [<Fact>]
    let ``_hxInclude succeeds`` () =
        a [ _hxInclude ".extra-stuff" ] [] |> shouldRender """<a hx-include=".extra-stuff"></a>"""

    [<Fact>]
    let ``_hxIndicator succeeds`` () =
        aside [ _hxIndicator "#spinner" ] [] |> shouldRender """<aside hx-indicator="#spinner"></aside>"""

    [<Fact>]
    let ``_hxNoBoost succeeds`` () =
        td [ _hxNoBoost ] [] |> shouldRender """<td hx-boost="false"></td>"""

    [<Fact>]
    let ``_hxParams succeeds`` () =
        br [ _hxParams "[p1,p2]" ] |> shouldRender """<br hx-params="[p1,p2]">"""

    [<Fact>]
    let ``_hxPatch succeeds`` () =
        div [ _hxPatch "/arrrgh" ] [] |> shouldRender """<div hx-patch="/arrrgh"></div>"""

    [<Fact>]
    let ``_hxPost succeeds`` () =
        hr [ _hxPost "/hear-ye-hear-ye" ] |> shouldRender """<hr hx-post="/hear-ye-hear-ye">"""

    [<Fact>]
    let ``_hxPreserve succeeds`` () =
        img [ _hxPreserve ] |> shouldRender """<img hx-preserve="true">"""

    [<Fact>]
    let ``_hxPrompt succeeds`` () =
        strong [ _hxPrompt "Who goes there?" ] [] |> shouldRender """<strong hx-prompt="Who goes there?"></strong>"""

    [<Fact>]
    let ``_hxPushUrl succeeds`` () =
        dl [ _hxPushUrl "/a-b-c" ] [] |> shouldRender """<dl hx-push-url="/a-b-c"></dl>"""

    [<Fact>]
    let ``_hxPut succeeds`` () =
        s [ _hxPut "/take-this" ] [] |> shouldRender """<s hx-put="/take-this"></s>"""

    [<Fact>]
    let ``_hxReplaceUrl succeeds`` () =
        p [ _hxReplaceUrl "/something-else" ] [] |> shouldRender """<p hx-replace-url="/something-else"></p>"""

    [<Fact>]
    let ``_hxRequest succeeds`` () =
        u [ _hxRequest "noHeaders" ] [] |> shouldRender """<u hx-request="noHeaders"></u>"""

    [<Fact>]
    let ``_hxSelect succeeds`` () =
        nav [ _hxSelect "#navbar" ] [] |> shouldRender """<nav hx-select="#navbar"></nav>"""

    [<Fact>]
    let ``_hxSelectOob succeeds`` () =
        section [ _hxSelectOob "#oob" ] [] |> shouldRender """<section hx-select-oob="#oob"></section>"""

    [<Fact>]
    let ``_hxSse succeeds`` () =
        footer [ _hxSse "connect:/my-events" ] [] |> shouldRender """<footer hx-sse="connect:/my-events"></footer>"""

    [<Fact>]
    let ``_hxSwap succeeds`` () =
        del [ _hxSwap "innerHTML" ] [] |> shouldRender """<del hx-swap="innerHTML"></del>"""

    [<Fact>]
    let ``_hxSwapOob succeeds`` () =
        li [ _hxSwapOob "true" ] [] |> shouldRender """<li hx-swap-oob="true"></li>"""

    [<Fact>]
    let ``_hxSync succeeds`` () =
        nav [ _hxSync "closest form:abort" ] [] |> shouldRender """<nav hx-sync="closest form:abort"></nav>"""

    [<Fact>]
    let ``_hxTarget succeeds`` () =
        header [ _hxTarget "#somewhereElse" ] [] |> shouldRender """<header hx-target="#somewhereElse"></header>"""

    [<Fact>]  
    let ``_hxTrigger succeeds`` () =
        figcaption [ _hxTrigger "load" ] [] |> shouldRender """<figcaption hx-trigger="load"></figcaption>"""

    [<Fact>]
    let ``_hxVals succeeds`` () =
        dt [ _hxVals """{ "extra": "values" }""" ] []
        |> shouldRender """<dt hx-vals="{ &quot;extra&quot;: &quot;values&quot; }"></dt>"""

    [<Fact>]
    let ``_hxWs succeeds`` () =
        ul [ _hxWs "connect:/web-socket" ] [] |> shouldRender """<ul hx-ws="connect:/web-socket"></ul>"""


/// Tests for the Script module
module Script =

    [<Fact>]
    let ``Script.minified succeeds`` () =
        let html = RenderView.AsString.htmlNode Script.minified
        Assert.Equal
            ("""<script src="https://unpkg.com/htmx.org@1.8.5" integrity="sha384-7aHh9lqPYGYZ7sTHvzP1t3BAfLhYSTy9ArHdP3Xsr9/3TlGurYgcPBoFmXX2TX/w" crossorigin="anonymous"></script>""",
             html)

    [<Fact>]
    let ``Script.unminified succeeds`` () =
        let html = RenderView.AsString.htmlNode Script.unminified
        Assert.Equal
            ("""<script src="https://unpkg.com/htmx.org@1.8.5/dist/htmx.js" integrity="sha384-VgGOQitu5eD5qAdh1QPLvPeTt1X4/Iw9B2sfYw+p3xtTumxaRv+onip7FX+P6q30" crossorigin="anonymous"></script>""",
             html)


/// Tests for the RenderFragment module
module RenderFragment =

    open System.Text

    [<Fact>]
    let ``RenderFragment.findIdNode fails with a Text node`` () =
        Assert.False (Option.isSome (RenderFragment.findIdNode "blue" (Text "")))

    [<Fact>]
    let ``RenderFragment.findIdNode fails with a VoidElement without a matching ID`` () =
        Assert.False (Option.isSome (RenderFragment.findIdNode "purple" (br [ _id "mauve" ])))

    [<Fact>]
    let ``RenderFragment.findIdNode fails with a ParentNode with no children with a matching ID`` () =
        Assert.False (Option.isSome (RenderFragment.findIdNode "green" (p [] [ str "howdy"; span [] [ str "huh" ] ])))
    
    [<Fact>]
    let ``RenderFragment.findIdNode succeeds with a VoidElement with a matching ID`` () =
        let leNode = hr [ _id "groovy" ]
        let foundNode = RenderFragment.findIdNode "groovy" leNode
        Assert.True (Option.isSome foundNode)
        Assert.Same (leNode, foundNode.Value)
    
    [<Fact>]
    let ``RenderFragment.findIdNode succeeds with a ParentNode with a child with a matching ID`` () =
        let leNode = span [ _id "its-me" ] [ str "Mario" ]
        let foundNode = RenderFragment.findIdNode "its-me" (p [] [ str "test"; str "again"; leNode; str "un mas" ])
        Assert.True (Option.isSome foundNode)
        Assert.Same (leNode, foundNode.Value)
    
    /// Generate a message if the requested ID node is not found
    let private nodeNotFound (nodeId : string) =
        $"<em>&ndash; ID {nodeId} not found &ndash;</em>"

    /// Tests for the AsString module
    module AsString =
        
        [<Fact>]
        let ``RenderFragment.AsString.htmlFromNodes succeeds when an ID is matched`` () =
            let html =
                RenderFragment.AsString.htmlFromNodes "needle"
                    [ p [] []; p [ _id "haystack" ] [ span [ _id "needle" ] [ str "ouch" ]; str "hay"; str "hay" ]]
            Assert.Equal ("""<span id="needle">ouch</span>""", html)

        [<Fact>]
        let ``RenderFragment.AsString.htmlFromNodes fails when an ID is not matched`` () =
            Assert.Equal (nodeNotFound "oops", RenderFragment.AsString.htmlFromNodes "oops" [])
        
        [<Fact>]
        let ``RenderFragment.AsString.htmlFromNode succeeds when ID is matched at top level`` () =
            let html = RenderFragment.AsString.htmlFromNode "wow" (p [ _id "wow" ] [ str "found it" ])
            Assert.Equal ("""<p id="wow">found it</p>""", html)
        
        [<Fact>]
        let ``RenderFragment.AsString.htmlFromNode succeeds when ID is matched in child element`` () =
            let html =
                div [] [ p [] [ str "not it" ]; p [ _id "hey" ] [ str "ta-da" ]]
                |> RenderFragment.AsString.htmlFromNode "hey"
            Assert.Equal ("""<p id="hey">ta-da</p>""", html)
        
        [<Fact>]
        let ``RenderFragment.AsString.htmlFromNode fails when an ID is not matched`` () =
            Assert.Equal (nodeNotFound "me", RenderFragment.AsString.htmlFromNode "me" (hr []))

    /// Tests for the AsBytes module
    module AsBytes =
        
        /// Alias for UTF-8 encoding
        let private utf8 = Encoding.UTF8

        [<Fact>]
        let ``RenderFragment.AsBytes.htmlFromNodes succeeds when an ID is matched`` () =
            let bytes =
                RenderFragment.AsBytes.htmlFromNodes "found"
                    [ p [] []; p [ _id "not-it" ] [ str "nope"; span [ _id "found" ] [ str "boo" ]; str "nope" ]]
            Assert.Equal<byte> (utf8.GetBytes """<span id="found">boo</span>""", bytes)

        [<Fact>]
        let ``RenderFragment.AsBytes.htmlFromNodes fails when an ID is not matched`` () =
            Assert.Equal<byte> (utf8.GetBytes (nodeNotFound "whiff"), RenderFragment.AsBytes.htmlFromNodes "whiff" [])
        
        [<Fact>]
        let ``RenderFragment.AsBytes.htmlFromNode succeeds when ID is matched at top level`` () =
            let bytes = RenderFragment.AsBytes.htmlFromNode "first" (p [ _id "first" ] [ str "!!!" ])
            Assert.Equal<byte> (utf8.GetBytes """<p id="first">!!!</p>""", bytes)
        
        [<Fact>]
        let ``RenderFragment.AsBytes.htmlFromNode succeeds when ID is matched in child element`` () =
            let bytes =
                div [] [ p [] [ str "not me" ]; p [ _id "child" ] [ str "node" ]]
                |> RenderFragment.AsBytes.htmlFromNode "child"
            Assert.Equal<byte> (utf8.GetBytes """<p id="child">node</p>""", bytes)
        
        [<Fact>]
        let ``RenderFragment.AsBytes.htmlFromNode fails when an ID is not matched`` () =
            Assert.Equal<byte> (utf8.GetBytes (nodeNotFound "foo"), RenderFragment.AsBytes.htmlFromNode "foo" (hr []))

    /// Tests for the IntoStringBuilder module
    module IntoStringBuilder =
        
        [<Fact>]
        let ``RenderFragment.IntoStringBuilder.htmlFromNodes succeeds when an ID is matched`` () =
            let sb = StringBuilder ()
            RenderFragment.IntoStringBuilder.htmlFromNodes sb "find-me"
                [ p [] []; p [ _id "peekaboo" ] [ str "bzz"; str "nope"; span [ _id "find-me" ] [ str ";)" ] ]]
            Assert.Equal ("""<span id="find-me">;)</span>""", string sb)

        [<Fact>]
        let ``RenderFragment.IntoStringBuilder.htmlFromNodes fails when an ID is not matched`` () =
            let sb = StringBuilder ()
            RenderFragment.IntoStringBuilder.htmlFromNodes sb "missing" []
            Assert.Equal (nodeNotFound "missing", string sb)
        
        [<Fact>]
        let ``RenderFragment.IntoStringBuilder.htmlFromNode succeeds when ID is matched at top level`` () =
            let sb = StringBuilder ()
            RenderFragment.IntoStringBuilder.htmlFromNode sb "top" (p [ _id "top" ] [ str "pinnacle" ])
            Assert.Equal ("""<p id="top">pinnacle</p>""", string sb)
        
        [<Fact>]
        let ``RenderFragment.IntoStringBuilder.htmlFromNode succeeds when ID is matched in child element`` () =
            let sb = StringBuilder ()
            div [] [ p [] [ str "nada" ]; p [ _id "it" ] [ str "is here" ]]
            |> RenderFragment.IntoStringBuilder.htmlFromNode sb "it"
            Assert.Equal ("""<p id="it">is here</p>""", string sb)
        
        [<Fact>]
        let ``RenderFragment.IntoStringBuilder.htmlFromNode fails when an ID is not matched`` () =
            let sb = StringBuilder ()
            RenderFragment.IntoStringBuilder.htmlFromNode sb "bar" (hr [])
            Assert.Equal (nodeNotFound "bar", string sb)
