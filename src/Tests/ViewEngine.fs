module ViewEngine

open Expecto
open Giraffe.ViewEngine
open Giraffe.ViewEngine.Htmx

/// Tests for the HxEncoding module
let hxEncoding =
    testList "HxEncoding" [
        test "Form is correct" {
            Expect.equal HxEncoding.Form "application/x-www-form-urlencoded" "Form encoding not correct"
        }
        test "MultipartForm is correct" {
            Expect.equal HxEncoding.MultipartForm "multipart/form-data" "Multipart form encoding not correct"
        }
    ]

let hxEvent =
    testList "HxEvent" [
        testList "Abort" [
            test "ToString succeeds" {
                Expect.equal (string Abort) "abort" "Abort event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (Abort.ToHxOnString()) "abort" "Abort hx-on event name not correct"
            }
        ]
        testList "AfterOnLoad" [
            test "ToString succeeds" {
                Expect.equal (string AfterOnLoad) "afterOnLoad" "AfterOnLoad event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (AfterOnLoad.ToHxOnString()) "after-on-load" "AfterOnLoad hx-on event name not correct"
            }
        ]
        testList "AfterProcessNode" [
            test "ToString succeeds" {
                Expect.equal (string AfterProcessNode) "afterProcessNode" "AfterProcessNode event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (AfterProcessNode.ToHxOnString())
                    "after-process-node"
                    "AfterProcessNode hx-on event name not correct"
            }
        ]
        testList "AfterRequest" [
            test "ToString succeeds" {
                Expect.equal (string AfterRequest) "afterRequest" "AfterRequest event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (AfterRequest.ToHxOnString()) "after-request" "AfterRequest hx-on event name not correct"
            }
        ]
        testList "AfterSettle" [
            test "ToString succeeds" {
                Expect.equal (string AfterSettle) "afterSettle" "AfterSettle event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (AfterSettle.ToHxOnString()) "after-settle" "AfterSettle hx-on event name not correct"
            }
        ]
        testList "AfterSwap" [
            test "ToString succeeds" {
                Expect.equal (string AfterSwap) "afterSwap" "AfterSwap event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (AfterSwap.ToHxOnString()) "after-swap" "AfterSwap hx-on event name not correct"
            }
        ]
        testList "BeforeCleanupElement" [
            test "ToString succeeds" {
                Expect.equal
                    (string BeforeCleanupElement) "beforeCleanupElement" "BeforeCleanupElement event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (BeforeCleanupElement.ToHxOnString())
                    "before-cleanup-element"
                    "BeforeCleanupElement hx-on event name not correct"
            }
        ]
        testList "BeforeOnLoad" [
            test "ToString succeeds" {
                Expect.equal (string BeforeOnLoad) "beforeOnLoad" "BeforeOnLoad event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (BeforeOnLoad.ToHxOnString()) "before-on-load" "BeforeOnLoad hx-on event name not correct"
            }
        ]
        testList "BeforeProcessNode" [
            test "ToString succeeds" {
                Expect.equal (string BeforeProcessNode) "beforeProcessNode" "BeforeProcessNode event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (BeforeProcessNode.ToHxOnString())
                    "before-process-node"
                    "BeforeProcessNode hx-on event name not correct"
            }
        ]
        testList "BeforeRequest" [
            test "ToString succeeds" {
                Expect.equal (string BeforeRequest) "beforeRequest" "BeforeRequest event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (BeforeRequest.ToHxOnString()) "before-request" "BeforeRequest hx-on event name not correct"
            }
        ]
        testList "BeforeSwap" [
            test "ToString succeeds" {
                Expect.equal (string BeforeSwap) "beforeSwap" "BeforeSwap event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (BeforeSwap.ToHxOnString()) "before-swap" "BeforeSwap hx-on event name not correct"
            }
        ]
        testList "BeforeSend" [
            test "ToString succeeds" {
                Expect.equal (string BeforeSend) "beforeSend" "BeforeSend event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (BeforeSend.ToHxOnString()) "before-send" "BeforeSend hx-on event name not correct"
            }
        ]
        testList "ConfigRequest" [
            test "ToString succeeds" {
                Expect.equal (string ConfigRequest) "configRequest" "ConfigRequest event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (ConfigRequest.ToHxOnString()) "config-request" "ConfigRequest hx-on event name not correct"
            }
        ]
        testList "Confirm" [
            test "ToString succeeds" {
                Expect.equal (string Confirm) "confirm" "Confirm event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (Confirm.ToHxOnString()) "confirm" "Confirm hx-on event name not correct"
            }
        ]
        testList "HistoryCacheError" [
            test "ToString succeeds" {
                Expect.equal (string HistoryCacheError) "historyCacheError" "HistoryCacheError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (HistoryCacheError.ToHxOnString())
                    "history-cache-error"
                    "HistoryCacheError hx-on event name not correct"
            }
        ]
        testList "HistoryCacheMiss" [
            test "ToString succeeds" {
                Expect.equal (string HistoryCacheMiss) "historyCacheMiss" "HistoryCacheMiss event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (HistoryCacheMiss.ToHxOnString())
                    "history-cache-miss"
                    "HistoryCacheMiss hx-on event name not correct"
            }
        ]
        testList "HistoryCacheMissError" [
            test "ToString succeeds" {
                Expect.equal
                    (string HistoryCacheMissError)
                    "historyCacheMissError"
                    "HistoryCacheMissError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (HistoryCacheMissError.ToHxOnString())
                    "history-cache-miss-error"
                    "HistoryCacheMissError hx-on event name not correct"
            }
        ]
        testList "HistoryCacheMissLoad" [
            test "ToString succeeds" {
                Expect.equal
                    (string HistoryCacheMissLoad) "historyCacheMissLoad" "HistoryCacheMissLoad event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (HistoryCacheMissLoad.ToHxOnString())
                    "history-cache-miss-load"
                    "HistoryCacheMissLoad hx-on event name not correct"
            }
        ]
        testList "HistoryRestore" [
            test "ToString succeeds" {
                Expect.equal (string HistoryRestore) "historyRestore" "HistoryRestore event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (HistoryRestore.ToHxOnString()) "history-restore" "HistoryRestore hx-on event name not correct"
            }
        ]
        testList "BeforeHistorySave" [
            test "ToString succeeds" {
                Expect.equal (string BeforeHistorySave) "beforeHistorySave" "BeforeHistorySave event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (BeforeHistorySave.ToHxOnString())
                    "before-history-save"
                    "BeforeHistorySave hx-on event name not correct"
            }
        ]
        testList "Load" [
            test "ToString succeeds" {
                Expect.equal (string Load) "load" "Load event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (Load.ToHxOnString()) "load" "Load hx-on event name not correct"
            }
        ]
        testList "NoSseSourceError" [
            test "ToString succeeds" {
                Expect.equal (string NoSseSourceError) "noSSESourceError" "NoSseSourceError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (NoSseSourceError.ToHxOnString())
                    "no-sse-source-error"
                    "NoSseSourceError hx-on event name not correct"
            }
        ]
        testList "OnLoadError" [
            test "ToString succeeds" {
                Expect.equal (string OnLoadError) "onLoadError" "OnLoadError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (OnLoadError.ToHxOnString()) "on-load-error" "OnLoadError hx-on event name not correct"
            }
        ]
        testList "OobAfterSwap" [
            test "ToString succeeds" {
                Expect.equal (string OobAfterSwap) "oobAfterSwap" "OobAfterSwap event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (OobAfterSwap.ToHxOnString()) "oob-after-swap" "OobAfterSwap hx-on event name not correct"
            }
        ]
        testList "OobBeforeSwap" [
            test "ToString succeeds" {
                Expect.equal (string OobBeforeSwap) "oobBeforeSwap" "OobBeforeSwap event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (OobBeforeSwap.ToHxOnString()) "oob-before-swap" "OobBeforeSwap hx-on event name not correct"
            }
        ]
        testList "OobErrorNoTarget" [
            test "ToString succeeds" {
                Expect.equal (string OobErrorNoTarget) "oobErrorNoTarget" "OobErrorNoTarget event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (OobErrorNoTarget.ToHxOnString())
                    "oob-error-no-target"
                    "OobErrorNoTarget hx-on event name not correct"
            }
        ]
        testList "Prompt" [
            test "ToString succeeds" {
                Expect.equal (string Prompt) "prompt" "Prompt event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (Prompt.ToHxOnString()) "prompt" "Prompt hx-on event name not correct"
            }
        ]
        testList "PushedIntoHistory" [
            test "ToString succeeds" {
                Expect.equal (string PushedIntoHistory) "pushedIntoHistory" "PushedIntoHistory event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (PushedIntoHistory.ToHxOnString())
                    "pushed-into-history"
                    "PushedIntoHistory hx-on event name not correct"
            }
        ]
        testList "ResponseError" [
            test "ToString succeeds" {
                Expect.equal (string ResponseError) "responseError" "ResponseError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (ResponseError.ToHxOnString()) "response-error" "ResponseError hx-on event name not correct"
            }
        ]
        testList "SendError" [
            test "ToString succeeds" {
                Expect.equal (string SendError) "sendError" "SendError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (SendError.ToHxOnString()) "send-error" "SendError hx-on event name not correct"
            }
        ]
        testList "SseError" [
            test "ToString succeeds" {
                Expect.equal (string SseError) "sseError" "SseError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (SseError.ToHxOnString()) "sse-error" "SseError hx-on event name not correct"
            }
        ]
        testList "SseOpen" [
            test "ToString succeeds" {
                Expect.equal (string SseOpen) "sseOpen" "SseOpen event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (SseOpen.ToHxOnString()) "sse-open" "SseOpen hx-on event name not correct"
            }
        ]
        testList "SwapError" [
            test "ToString succeeds" {
                Expect.equal (string SwapError) "swapError" "SwapError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (SwapError.ToHxOnString()) "swap-error" "SwapError hx-on event name not correct"
            }
        ]
        testList "TargetError" [
            test "ToString succeeds" {
                Expect.equal (string TargetError) "targetError" "TargetError event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (TargetError.ToHxOnString()) "target-error" "TargetError hx-on event name not correct"
            }
        ]
        testList "Timeout" [
            test "ToString succeeds" {
                Expect.equal (string Timeout) "timeout" "Timeout event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (Timeout.ToHxOnString()) "timeout" "Timeout hx-on event name not correct"
            }
        ]
        testList "ValidationValidate" [
            test "ToString succeeds" {
                Expect.equal
                    (string ValidationValidate) "validation:validate" "ValidationValidate event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (ValidationValidate.ToHxOnString())
                    "validation:validate"
                    "ValidationValidate hx-on event name not correct"
            }
        ]
        testList "ValidationFailed" [
            test "ToString succeeds" {
                Expect.equal (string ValidationFailed) "validation:failed" "ValidationFailed event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (ValidationFailed.ToHxOnString())
                    "validation:failed"
                    "ValidationFailed hx-on event name not correct"
            }
        ]
        testList "ValidationHalted" [
            test "ToString succeeds" {
                Expect.equal (string ValidationHalted) "validation:halted" "ValidationHalted event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal
                    (ValidationHalted.ToHxOnString())
                    "validation:halted"
                    "ValidationHalted hx-on event name not correct"
            }
        ]
        testList "XhrAbort" [
            test "ToString succeeds" {
                Expect.equal (string XhrAbort) "xhr:abort" "XhrAbort event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (XhrAbort.ToHxOnString()) "xhr:abort" "XhrAbort hx-on event name not correct"
            }
        ]
        testList "XhrLoadEnd" [
            test "ToString succeeds" {
                Expect.equal (string XhrLoadEnd) "xhr:loadend" "XhrLoadEnd event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (XhrLoadEnd.ToHxOnString()) "xhr:loadend" "XhrLoadEnd hx-on event name not correct"
            }
        ]
        testList "XhrLoadStart" [
            test "ToString succeeds" {
                Expect.equal (string XhrLoadStart) "xhr:loadstart" "XhrLoadStart event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (XhrLoadStart.ToHxOnString()) "xhr:loadstart" "XhrLoadStart hx-on event name not correct"
            }
        ]
        testList "XhrProgress" [
            test "ToString succeeds" {
                Expect.equal (string XhrProgress) "xhr:progress" "XhrProgress event name not correct"
            }
            test "ToHxOnString succeeds" {
                Expect.equal (XhrProgress.ToHxOnString()) "xhr:progress" "XhrProgress hx-on event name not correct"
            }
        ]
        
    ]
/// Tests for the HxHeaders module
let hxHeaders =
    testList "HxHeaders" [
        testList "From" [
            test "succeeds with an empty list" {
                Expect.equal (HxHeaders.From []) "{  }" "Empty headers not correct"
            }
            test "succeeds and escapes quotes" {
                Expect.equal
                    (HxHeaders.From [ "test", "one two three"; "again", """four "five" six""" ])
                    """{ "test": "one two three", "again": "four \"five\" six" }""" "Headers not correct"
            }
        ]
    ]

/// Tests for the HxParams module
let hxParams =
    testList "HxParams" [
        test "All is correct" {
            Expect.equal HxParams.All "*" "All is not correct"
        }
        test "None is correct" {
            Expect.equal HxParams.None "none" "None is not correct"
        }
        testList "With" [
            test "succeeds with empty list" {
                Expect.equal (HxParams.With []) "" "With with empty list should have been blank"
            }
            test "succeeds with one list item" {
                Expect.equal (HxParams.With [ "boo" ]) "boo" "With single item incorrect"
            }
            test "succeeds with multiple list items" {
                Expect.equal (HxParams.With [ "foo"; "bar"; "baz" ]) "foo,bar,baz" "With multiple items incorrect"
            }
        ]
        testList "Except" [
            test "succeeds with empty list" {
                Expect.equal (HxParams.Except []) "not " "Except with empty list incorrect"
            }
            test "succeeds with one list item" {
                Expect.equal (HxParams.Except [ "that" ]) "not that" "Except single item incorrect"
            }
            test "succeeds with multiple list items" {
                Expect.equal (HxParams.Except [ "blue"; "green" ]) "not blue,green" "Except multiple items incorrect"
            }
        ]
    ]

/// Tests for the HxRequest module
let hxRequest =
    testList "HxRequest" [
        testList "Configure" [
            test "succeeds with an empty list" {
                Expect.equal (HxRequest.Configure []) "{  }" "Configure with empty list incorrect"
            }
            test "succeeds with a non-empty list" {
                Expect.equal
                    (HxRequest.Configure [ "\"a\": \"b\""; "\"c\": \"d\"" ]) """{ "a": "b", "c": "d" }"""
                    "Configure with a non-empty list incorrect"
            }
            test "succeeds with all known params configured" {
                Expect.equal
                    (HxRequest.Configure
                        [ HxRequest.Timeout 1000; HxRequest.Credentials false; HxRequest.NoHeaders true ])
                    """{ "timeout": 1000, "credentials": false, "noHeaders": true }"""
                    "Configure with all known params incorrect"
            }
        ]
        test "Timeout succeeds" {
            Expect.equal (HxRequest.Timeout 50) "\"timeout\": 50" "Timeout value incorrect"
        }
        testList "Credentials" [
            test "succeeds when set to true" {
                Expect.equal (HxRequest.Credentials true) "\"credentials\": true" "Credentials value incorrect"
            }
            test "succeeds when set to false" {
                Expect.equal (HxRequest.Credentials false) "\"credentials\": false" "Credentials value incorrect"
            }
        ]
        testList "NoHeaders" [
            test "succeeds when set to true" {
                Expect.equal (HxRequest.NoHeaders true) "\"noHeaders\": true" "NoHeaders value incorrect"
            }
            test "succeeds when set to false" {
                Expect.equal (HxRequest.NoHeaders false) "\"noHeaders\": false" "NoHeaders value incorrect"
            }
        ]
    ]

/// Tests for the HxTrigger module
let hxTrigger =
    testList "HxTrigger" [
        test "Click is correct" {
            Expect.equal HxTrigger.Click "click" "Click is incorrect"
        }
        test "Load is correct" {
            Expect.equal HxTrigger.Load "load" "Load is incorrect"
        }
        test "Revealed is correct" {
            Expect.equal HxTrigger.Revealed "revealed" "Revealed is incorrect"
        }
        test "Every succeeds" {
            Expect.equal (HxTrigger.Every "3s") "every 3s" "Every is incorrect"
        }
        testList "Filter" [
            test "Alt succeeds" {
                Expect.equal (HxTrigger.Filter.Alt HxTrigger.Click) "click[altKey]" "Alt filter incorrect"
            }
            test "Ctrl succeeds" {
                Expect.equal (HxTrigger.Filter.Ctrl HxTrigger.Click) "click[ctrlKey]" "Ctrl filter incorrect"
            }
            test "Shift succeeds" {
                Expect.equal (HxTrigger.Filter.Shift HxTrigger.Click) "click[shiftKey]" "Shift filter incorrect"
            }
            test "CtrlAlt succeeds" {
                Expect.equal
                    (HxTrigger.Filter.CtrlAlt HxTrigger.Click) "click[ctrlKey&&altKey]" "Ctrl+Alt filter incorrect"
            }
            test "CtrlShift succeeds" {
                Expect.equal
                    (HxTrigger.Filter.CtrlShift HxTrigger.Click) "click[ctrlKey&&shiftKey]"
                    "Ctrl+Shift filter incorrect"
            }
            test "CtrlAltShift succeeds" {
                Expect.equal
                    (HxTrigger.Filter.CtrlAltShift HxTrigger.Click) "click[ctrlKey&&altKey&&shiftKey]"
                    "Ctrl+Alt+Shift filter incorrect"
            }
            test "AltShift succeeds" {
                Expect.equal
                    (HxTrigger.Filter.AltShift HxTrigger.Click) "click[altKey&&shiftKey]" "Alt+Shift filter incorrect"
            }
        ]
        testList "Once" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.Once "") "once" "Once modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.Once "click") "click once" "Once modifier incorrect"
            }
        ]
        testList "Changed" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.Changed "") "changed" "Changed modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.Changed "click") "click changed" "Changed modifier incorrect"
            }
        ]
        testList "Delay" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.Delay "1s" "") "delay:1s" "Delay modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.Delay "2s" "click") "click delay:2s" "Delay modifier incorrect"
            }
        ]
        testList "Throttle" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.Throttle "4s" "") "throttle:4s" "Throttle modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.Throttle "7s" "click") "click throttle:7s" "Throttle modifier incorrect"
            }
        ]
        testList "From" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.From ".nav" "") "from:.nav" "From modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.From "#somewhere" "click") "click from:#somewhere" "From modifier incorrect"
            }
        ]
        testList "FromDocument" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.FromDocument "") "from:document" "FromDocument modifier incorrect"
            } 
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.FromDocument "click") "click from:document" "FromDocument modifier incorrect"
            }
        ]
        testList "FromWindow" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.FromWindow "") "from:window" "FromWindow modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.FromWindow "click") "click from:window" "FromWindow modifier incorrect"
            }
        ]
        testList "FromClosest" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.FromClosest "div" "") "from:closest div" "FromClosest modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.FromClosest "p" "click") "click from:closest p" "FromClosest modifier incorrect"
            }
        ]
        testList "FromFind" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.FromFind "li" "") "from:find li" "FromFind modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.FromFind ".spot" "click") "click from:find .spot" "FromFind modifier incorrect"
            }
        ]
        testList "Target" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.Target "main" "") "target:main" "Target modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.Target "footer" "click") "click target:footer" "Target modifier incorrect"
            }
        ]
        testList "Consume" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.Consume "") "consume" "Consume modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.Consume "click") "click consume" "Consume modifier incorrect"
            }
        ]
        testList "Queue" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.Queue "abc" "") "queue:abc" "Queue modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.Queue "def" "click") "click queue:def" "Queue modifier incorrect"
            }
        ]
        testList "QueueFirst" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.QueueFirst "") "queue:first" "QueueFirst modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.QueueFirst "click") "click queue:first" "QueueFirst modifier incorrect"
            }
        ]
        testList "QueueLast" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.QueueLast "") "queue:last" "QueueLast modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.QueueLast "click") "click queue:last" "QueueLast modifier incorrect"
            }
        ]
        testList "QueueAll" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.QueueAll "") "queue:all" "QueueAll modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.QueueAll "click") "click queue:all" "QueueAll modifier incorrect"
            }
        ]
        testList "QueueNone" [
            test "succeeds when it is the first modifier" {
                Expect.equal (HxTrigger.QueueNone "") "queue:none" "QueueNone modifier incorrect"
            }
            test "succeeds when it is not the first modifier" {
                Expect.equal (HxTrigger.QueueNone "click") "click queue:none" "QueueNone modifier incorrect"
            }
        ]
    ]

/// Tests for the HxVals module
let hxVals =
    testList "HxVals" [
        testList "From" [
            test "succeeds with an empty list" {
                Expect.equal (HxVals.From []) "{  }" "From with an empty list is incorrect"
            }
            test "succeeds and escapes quotes" {
                Expect.equal
                    (HxVals.From [ "test", """a "b" c"""; "2", "d e f" ])
                    """{ "test": "a \"b\" c", "2": "d e f" }""" "From value is incorrect"
            }
        ]
    ]

/// Pipe-able assertion for a rendered node 
let shouldRender expected node =
    Expect.equal (RenderView.AsString.htmlNode node) expected "Rendered HTML incorrect"

/// Tests for the HtmxAttrs module
let attributes =
    testList "Attributes" [

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
        test "_hxDisabledElt succeeds" {
            button [ _hxDisabledElt "this" ] [] |> shouldRender """<button hx-disabled-elt="this"></button>"""
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
        test "_hxOnEvent succeeds" {
            a [ _hxOnEvent "click" "doThis()" ] [] |> shouldRender """<a hx-on:click="doThis()"></a>"""
        }
        test "_hxOnHxEvent succeeds" {
            strong [ _hxOnHxEvent BeforeSwap "changeStuff()" ] []
            |> shouldRender """<strong hx-on::before-swap="changeStuff()"></strong>"""
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
            strong [ _hxPrompt "Who goes there?" ] []
            |> shouldRender """<strong hx-prompt="Who goes there?"></strong>"""
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
            footer [ _hxSse "connect:/my-events" ] []
            |> shouldRender """<footer hx-sse="connect:/my-events"></footer>"""
        }
        test "_hxSwap succeeds" {
            del [ _hxSwap "innerHTML" ] [] |> shouldRender """<del hx-swap="innerHTML"></del>"""
        }
        test "_hxSwapWithTransition succeeds" {
            del [ _hxSwapWithTransition "innerHTML" ] []
            |> shouldRender """<del hx-swap="innerHTML transition:true"></del>"""
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
        test "_sseSwap succeeds" {
            ul [ _sseSwap "sseMessageName" ] [] |> shouldRender """<ul sse-swap="sseMessageName"></ul>"""
        }
        test "_sseConnect succeeds" {
            div [ _sseConnect "/gps/sse" ] [] |> shouldRender """<div sse-connect="/gps/sse"></div>"""
        }
    ]

/// Tests for the Script module
let script =
    testList "Script" [
        test "minified succeeds" {
            let html = RenderView.AsString.htmlNode Script.minified
            Expect.equal
                html
                """<script src="https://unpkg.com/htmx.org@1.9.11" integrity="sha384-0gxUXCCR8yv9FM2b+U3FDbsKthCI66oH5IA9fHppQq9DDMHuMauqq1ZHBpJxQ0J0" crossorigin="anonymous"></script>"""
                "Minified script tag is incorrect"
        }
        test "unminified succeeds" {
            let html = RenderView.AsString.htmlNode Script.unminified
            Expect.equal
                html
                """<script src="https://unpkg.com/htmx.org@1.9.11/dist/htmx.js" integrity="sha384-l9bYT9SL4CAW0Hl7pAOpfRc18mys1b0wK4U8UtGnWOxPVbVMgrOdB+jyz/WY8Jue" crossorigin="anonymous"></script>"""
                "Unminified script tag is incorrect"
        }
    ]

open System.Text

/// Tests for the RenderFragment module
let renderFragment =
    testList "RenderFragment" [
        
        /// Validate that the two object references are the same object
        let isSame obj1 obj2 message =
            Expect.isTrue (obj.ReferenceEquals (obj1, obj2)) message
        
        testList "findIdNode" [
            test "fails with a Text node" {
                Expect.isNone (RenderFragment.findIdNode "blue" (Text "")) "There should not have been a node found"
            }
            test "fails with a VoidElement without a matching ID" {
                Expect.isNone
                    (RenderFragment.findIdNode "purple" (br [ _id "mauve" ])) "There should not have been a node found"
            }
            test "fails with a ParentNode with no children with a matching ID" {
                Expect.isNone
                    (RenderFragment.findIdNode "green" (p [] [ str "howdy"; span [] [ str "huh" ] ]))
                    "There should not have been a node found"
            }
            test "succeeds with a VoidElement with a matching ID" {
                let leNode = hr [ _id "groovy" ]
                let foundNode = RenderFragment.findIdNode "groovy" leNode
                Expect.isSome foundNode "There should have been a node found"
                isSame leNode foundNode.Value "The node should have been the same object"
            }
            test "succeeds with a ParentNode with a child with a matching ID" {
                let leNode = span [ _id "its-me" ] [ str "Mario" ]
                let foundNode =
                    RenderFragment.findIdNode "its-me" (p [] [ str "test"; str "again"; leNode; str "un mas" ])
                Expect.isSome foundNode "There should have been a node found"
                isSame leNode foundNode.Value "The node should have been the same object"
            }
        ]

        /// Generate a message if the requested ID node is not found
        let nodeNotFound (nodeId : string) =
            $"<em>&ndash; ID {nodeId} not found &ndash;</em>"

        testList "AsString" [
            testList "htmlFromNodes" [
                test "succeeds when an ID is matched" {
                    let html =
                        RenderFragment.AsString.htmlFromNodes "needle"
                            [   p [] []
                                p [ _id "haystack" ] [ str "hay"; span [ _id "needle" ] [ str "ouch" ]; str "hay" ]
                            ]
                    Expect.equal html """<span id="needle">ouch</span>""" "HTML is incorrect"
                }
                test "fails when an ID is not matched" {
                    Expect.equal
                        (RenderFragment.AsString.htmlFromNodes "oops" []) (nodeNotFound "oops") "HTML is incorrect"
                }
            ]
            testList "htmlFromNode" [
                test "succeeds when ID is matched at top level" {
                    let html = RenderFragment.AsString.htmlFromNode "wow" (p [ _id "wow" ] [ str "found it" ])
                    Expect.equal html """<p id="wow">found it</p>""" "HTML is incorrect"
                }
                test "succeeds when ID is matched in child element" {
                    let html =
                        div [] [ p [] [ str "not it" ]; p [ _id "hey" ] [ str "ta-da" ]]
                        |> RenderFragment.AsString.htmlFromNode "hey"
                    Expect.equal html """<p id="hey">ta-da</p>""" "HTML is incorrect"
                }
                test "fails when an ID is not matched" {
                    Expect.equal
                        (RenderFragment.AsString.htmlFromNode "me" (hr [])) (nodeNotFound "me") "HTML is incorrect"
                }
            ]
        ]
        testList "AsBytes" [
            
            /// Alias for UTF-8 encoding
            let utf8 = Encoding.UTF8

            testList "htmlFromNodes" [
                test "succeeds when an ID is matched" {
                    let bytes =
                        RenderFragment.AsBytes.htmlFromNodes "found"
                            [   p [] []
                                p [ _id "not-it" ] [ str "nope"; span [ _id "found" ] [ str "boo" ]; str "nope" ]
                            ]
                    Expect.equal bytes (utf8.GetBytes """<span id="found">boo</span>""") "HTML bytes are incorrect"
                }
                test "fails when an ID is not matched" {
                    Expect.equal
                        (RenderFragment.AsBytes.htmlFromNodes "whiff" []) (utf8.GetBytes (nodeNotFound "whiff"))
                        "HTML bytes are incorrect"
                }
            ]
            testList "htmlFromNode" [
                test "succeeds when ID is matched at top level" {
                    let bytes = RenderFragment.AsBytes.htmlFromNode "first" (p [ _id "first" ] [ str "!!!" ])
                    Expect.equal bytes (utf8.GetBytes """<p id="first">!!!</p>""") "HTML bytes are incorrect"
                }
                test "succeeds when ID is matched in child element" {
                    let bytes =
                        div [] [ p [] [ str "not me" ]; p [ _id "child" ] [ str "node" ]]
                        |> RenderFragment.AsBytes.htmlFromNode "child"
                    Expect.equal bytes (utf8.GetBytes """<p id="child">node</p>""") "HTML bytes are incorrect"
                }
                test "fails when an ID is not matched" {
                    Expect.equal
                        (RenderFragment.AsBytes.htmlFromNode "foo" (hr [])) (utf8.GetBytes (nodeNotFound "foo"))
                        "HTML bytes are incorrect"
                }
            ]
        ]
        testList "IntoStringBuilder" [
            testList "htmlFromNodes" [
                test "succeeds when an ID is matched" {
                    let sb = StringBuilder ()
                    RenderFragment.IntoStringBuilder.htmlFromNodes sb "find-me"
                        [ p [] []; p [ _id "peekaboo" ] [ str "bzz"; str "nope"; span [ _id "find-me" ] [ str ";)" ] ]]
                    Expect.equal (string sb) """<span id="find-me">;)</span>""" "HTML is incorrect"
                }
                test "fails when an ID is not matched" {
                    let sb = StringBuilder ()
                    RenderFragment.IntoStringBuilder.htmlFromNodes sb "missing" []
                    Expect.equal (string sb) (nodeNotFound "missing") "HTML is incorrect"
                }
            ]
            testList "htmlFromNode" [
                test "succeeds when ID is matched at top level" {
                    let sb = StringBuilder ()
                    RenderFragment.IntoStringBuilder.htmlFromNode sb "top" (p [ _id "top" ] [ str "pinnacle" ])
                    Expect.equal (string sb) """<p id="top">pinnacle</p>""" "HTML is incorrect"
                }
                test "succeeds when ID is matched in child element" {
                    let sb = StringBuilder ()
                    div [] [ p [] [ str "nada" ]; p [ _id "it" ] [ str "is here" ]]
                    |> RenderFragment.IntoStringBuilder.htmlFromNode sb "it"
                    Expect.equal (string sb) """<p id="it">is here</p>""" "HTML is incorrect"
                }
                test "fails when an ID is not matched" {
                    let sb = StringBuilder ()
                    RenderFragment.IntoStringBuilder.htmlFromNode sb "bar" (hr [])
                    Expect.equal (string sb) (nodeNotFound "bar") "HTML is incorrect"
                }
            ]
        ]
    ]

#nowarn "44"

/// Tests for the HtmxAttrs module
let deprecatedAttributes =
    testList "Deprecated Attributes" [
        test "_hxOn succeeds" {
            let newLine = "\n"
            strong [ _hxOn "submit: alert('oops')\nclick: alert('howdy!')" ] []
            |> shouldRender $"""<strong hx-on="submit: alert(&#39;oops&#39;){newLine}click: alert(&#39;howdy!&#39;)"></strong>"""
        }
    ]

/// All tests in this module
let allTests =
    testList "ViewEngine.Htmx" [
        hxEncoding
        hxEvent
        hxHeaders
        hxParams
        hxRequest
        hxTrigger
        hxVals
        attributes
        script
        renderFragment
        deprecatedAttributes
    ]
