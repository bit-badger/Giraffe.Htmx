module Giraffe.ViewEngine.Htmx

/// Valid values for the `hx-encoding` attribute
[<RequireQualifiedAccess>]
module HxEncoding =
  /// A standard HTTP form
  let Form          = "application/x-www-form-urlencoded"
  /// A multipart form (used for file uploads)
  let MultipartForm = "multipart/form-data"

// TODO: hx-header helper

/// Values / helpers for the `hx-params` attribute
[<RequireQualifiedAccess>]
module HxParams =
  /// Include all parameters
  let All  = "*"
  /// Include no parameters
  let None = "none"
  /// Include the specified parameters
  let With   fields = fields |> List.reduce (fun acc it -> $"{acc},{it}")
  /// Exclude the specified parameters
  let Except fields = With fields |> sprintf "not %s"

// TODO: hx-request helper

/// Valid values for the `hx-swap` attribute (may be combined with swap/settle/scroll/show config)
[<RequireQualifiedAccess>]
module HxSwap =
  /// The default, replace the inner html of the target element
  let InnerHtml   = "innerHTML"
  /// Replace the entire target element with the response
  let OuterHtml   = "outerHTML"
  /// Insert the response before the target element
  let BeforeBegin = "beforebegin"
  /// Insert the response before the first child of the target element
  let AfterBegin  = "afterbegin"
  /// Insert the response after the last child of the target element
  let BeforeEnd   = "beforeend"
  /// Insert the response after the target element
  let AfterEnd    = "afterend"
  /// Does not append content from response (out of band items will still be processed).
  let None        = "none"

/// Helpers for the `hx-trigger` attribute
[<RequireQualifiedAccess>]
module HxTrigger =
  /// Append a filter to a trigger
  let private appendFilter filter (trigger : string) =
    match trigger.Contains "[" with
    | true ->
        let parts = trigger.Split ('[', ']')
        sprintf "%s[%s&&%s]" parts.[0] parts.[1] filter
    | false -> sprintf "%s[%s]" trigger filter
  /// Trigger the event on a click
  let Click = "click"
  /// Trigger the event on page load
  let Load  = "load"
  /// Helpers for defining filters
  module Filter =
    /// Only trigger the event if the `ALT` key is pressed
    let Alt          = appendFilter "altKey"
    /// Only trigger the event if the `CTRL` key is pressed
    let Ctrl         = appendFilter "ctrlKey"
    /// Only trigger the event if the `SHIFT` key is pressed
    let Shift        = appendFilter "shiftKey"
    /// Only trigger the event if `CTRL+ALT` are pressed
    let CtrlAlt      = Ctrl    >> Alt
    /// Only trigger the event if `CTRL+SHIFT` are pressed
    let CtrlShift    = Ctrl    >> Shift
    /// Only trigger the event if `CTRL+ALT+SHIFT` are pressed
    let CtrlAltShift = CtrlAlt >> Shift
    /// Only trigger the event if `ALT+SHIFT` are pressed
    let AltShift     = Alt     >> Shift
  
  // TODO: more stuff for the hx-trigger helper

// TODO: hx-vals helper


/// Attributes and flags for HTMX
[<AutoOpen>]
module HtmxAttrs =
  /// Progressively enhances anchors and forms to use AJAX requests
  let _hxBoost      = attr "hx-boost" "true"
  /// Shows a confim() dialog before issuing a request
  let _hxConfirm    = attr "hx-confirm"
  /// Issues a DELETE to the specified URL
  let _hxDelete     = attr "hx-delete"
  /// Disables htmx processing for the given node and any children nodes
  let _hxDisable    = flag "hx-disable"
  /// Changes the request encoding type
  let _hxEncoding   = attr "hx-encoding"
  /// Extensions to use for this element
  let _hxExt        = attr "hx-ext"
  /// Issues a GET to the specified URL
  let _hxGet        = attr "hx-get"
  /// Adds to the headers that will be submitted with the request
  let _hxHeaders    = attr "hx-headers"
  /// The element to snapshot and restore during history navigation
  let _hxHistoryElt = flag "hx-history-elt"
  /// Includes additional data in AJAX requests
  let _hxInclude    = attr "hx-include"
  /// The element to put the htmx-request class on during the AJAX request
  let _hxIndicator  = attr "hx-indicator"
  /// Filters the parameters that will be submitted with a request
  let _hxParams     = attr "hx-params"
  /// Issues a PATCH to the specified URL
  let _hxPatch      = attr "hx-patch"
  /// Issues a POST to the specified URL
  let _hxPost       = attr "hx-post"
  /// Preserves an element between requests
  let _hxPreserve   = attr "hx-preserve" "true"
  /// Shows a prompt before submitting a request
  let _hxPrompt     = attr "hx-prompt"
  /// Pushes the URL into the location bar, creating a new history entry
  let _hxPushUrl    = flag "hx-push-url"
  /// Issues a PUT to the specified URL
  let _hxPut        = attr "hx-put"
  /// Configures various aspects of the request
  let _hxRequest    = attr "hx-request"
  /// Selects a subset of the server response to process
  let _hxSelect     = attr "hx-select"
  /// Establishes and listens to Server Sent Event (SSE) sources for events
  let _hxSse        = attr "hx-sse"
  /// Marks content in a response as being "Out of Band", i.e. swapped somewhere other than the target
  let _hxSwapOob    = attr "hx-swap-oob"
  /// Controls how the response content is swapped into the DOM (e.g. 'outerHTML' or 'beforeEnd')
  let _hxSwap       = attr "hx-swap"
  /// Specifies the target element to be swapped
  let _hxTarget     = attr "hx-target"
  /// Specifies the event that triggers the request
  let _hxTrigger    = attr "hx-trigger"
  /// Adds to the parameters that will be submitted with the request
  let _hxVals       = attr "hx-vals"
  /// Establishes a WebSocket or sends information to one
  let _hxWs         = attr "hx-ws"
