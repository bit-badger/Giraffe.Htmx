module Giraffe.ViewEngine.Htmx

/// Serialize a list of key/value pairs to JSON (very rudimentary)
let private toJson (kvps : (string * string) list) =
    kvps
    |> List.map (fun kvp -> sprintf "\"%s\": \"%s\"" (fst kvp) ((snd kvp).Replace ("\"", "\\\"")))
    |> String.concat ", "
    |> sprintf "{ %s }"


/// Valid values for the `hx-encoding` attribute
[<RequireQualifiedAccess>]
module HxEncoding =
    
    /// A standard HTTP form
    let Form          = "application/x-www-form-urlencoded"
    
    /// A multipart form (used for file uploads)
    let MultipartForm = "multipart/form-data"


/// Helper to create the `hx-headers` attribute
[<RequireQualifiedAccess>]
module HxHeaders =
    
    /// Create headers from a list of key/value pairs
    let From = toJson


/// Values / helpers for the `hx-params` attribute
[<RequireQualifiedAccess>]
module HxParams =
    
    /// Include all parameters
    let All  = "*"
    
    /// Include no parameters
    let None = "none"
    
    /// Include the specified parameters
    let With   fields = match fields with [] -> "" | _ -> fields |> List.reduce (fun acc it -> $"{acc},{it}")
    
    /// Exclude the specified parameters
    let Except fields = With fields |> sprintf "not %s"


/// Helpers to define `hx-request` attribute values
[<RequireQualifiedAccess>]
module HxRequest =
    
    /// Convert a boolean to its lowercase string equivalent
    let private toLowerBool (it : bool) =
        (string it).ToLowerInvariant ()
    
    /// Configure the request with various options
    let Configure (opts : string list) =
        opts
        |> String.concat ", "
        |> sprintf "{ %s }"
    
    /// Set a timeout (in milliseconds)
    let Timeout (ms : int) = $"\"timeout\": {ms}"
    
    /// Include or exclude credentials from the request
    let Credentials = toLowerBool >> sprintf "\"credentials\": %s"
    
    /// Exclude or include headers from the request
    let NoHeaders = toLowerBool >> sprintf "\"noHeaders\": %s"


/// Helpers for the `hx-trigger` attribute
[<RequireQualifiedAccess>]
module HxTrigger =
    
    /// Append a filter to a trigger
    let private appendFilter filter (trigger : string) =
        match trigger.Contains "[" with
        | true ->
            let parts = trigger.Split ('[', ']')
            $"{parts[0]}[{parts[1]}&&{filter}]"
        | false -> $"{trigger}[{filter}]"
    
    /// Trigger the event on a click
    let Click = "click"
    
    /// Trigger the event on page load
    let Load = "load"
    
    /// Trigger the event when the item is visible
    let Revealed = "revealed"
    
    /// Trigger this event every [timing declaration]
    let Every (duration : string) = $"every {duration}"
    
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
    
    /// Append a modifier to the current trigger
    let private appendModifier modifier current =
        if current = "" then modifier else $"{current} {modifier}"
    
    /// Only trigger once
    let Once = appendModifier "once"
    
    /// Trigger when changed
    let Changed = appendModifier "changed"
    
    /// Delay execution; resets every time the event is seen
    let Delay = sprintf "delay:%s" >> appendModifier
    
    /// Throttle execution; ignore other events, fire when duration passes
    let Throttle = sprintf "throttle:%s" >> appendModifier
    
    /// Trigger this event from a CSS selector
    let From = sprintf "from:%s" >> appendModifier
    
    /// Trigger this event from the `document` object
    let FromDocument = From "document"
    
    /// Trigger this event from the `window` object
    let FromWindow = From "window"
    
    /// Trigger this event from the closest parent CSS selector
    let FromClosest = sprintf "closest %s" >> From
    
    /// Trigger this event from the closest child CSS selector
    let FromFind = sprintf "find %s" >> From
    
    /// Target the given CSS selector with the results of this event
    let Target = sprintf "target:%s" >> appendModifier
    
    /// Prevent any further events from occurring after this one fires
    let Consume = appendModifier "consume"
    
    /// Configure queueing when events fire when others are in flight; if unspecified, the default is "last"
    let Queue = sprintf "queue:%s" >> appendModifier
    
    /// Queue the first event, discard all others (i.e., a FIFO queue of 1)
    let QueueFirst = Queue "first"
    
    /// Queue the last event; discards current when another is received (i.e., a LIFO queue of 1)
    let QueueLast = Queue "last"
    
    /// Queue all events; discard none
    let QueueAll = Queue "all"
    
    /// Queue no events; discard all
    let QueueNone = Queue "none"


/// Helper to create the `hx-vals` attribute
[<RequireQualifiedAccess>]
module HxVals =
    
    /// Create values from a list of key/value pairs
    let From = toJson


/// Attributes and flags for htmx
[<AutoOpen>]
module HtmxAttrs =
    
    /// Progressively enhances anchors and forms to use AJAX requests (use `_hxNoBoost` to set to false)
    let _hxBoost      = attr "hx-boost" "true"
    
    /// Shows a confirm() dialog before issuing a request
    let _hxConfirm    = attr "hx-confirm"
    
    /// Issues a DELETE to the specified URL
    let _hxDelete     = attr "hx-delete"
    
    /// Disables htmx processing for the given node and any children nodes
    let _hxDisable    = flag "hx-disable"
    
    /// Disinherit all ("*") or specific htmx attributes
    let _hxDisinherit = attr "hx-disinherit"
    
    /// Changes the request encoding type
    let _hxEncoding   = attr "hx-encoding"
    
    /// Extensions to use for this element
    let _hxExt        = attr "hx-ext"
    
    /// Issues a GET to the specified URL
    let _hxGet        = attr "hx-get"
    
    /// Adds to the headers that will be submitted with the request
    let _hxHeaders    = attr "hx-headers"
    
    /// Set to "false" to prevent pages with sensitive information from being stored in the history cache
    let _hxHistory    = attr "hx-history"
    
    /// The element to snapshot and restore during history navigation
    let _hxHistoryElt = flag "hx-history-elt"
    
    /// Includes additional data in AJAX requests
    let _hxInclude    = attr "hx-include"
    
    /// The element to put the htmx-request class on during the AJAX request
    let _hxIndicator  = attr "hx-indicator"
    
    /// Overrides a previous `hx-boost`
    let _hxNoBoost    = attr "hx-boost" "false"
    
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
    let _hxPushUrl    = attr "hx-push-url"
    
    /// Issues a PUT to the specified URL
    let _hxPut        = attr "hx-put"
    
    /// Replaces the current URL in the browser's history stack
    let _hxReplaceUrl = attr "hx-replace-url"
    
    /// Configures various aspects of the request
    let _hxRequest    = attr "hx-request"
    
    /// Selects a subset of the server response to process
    let _hxSelect     = attr "hx-select"
    
    /// Selects a subset of an out-of-band server response
    let _hxSelectOob  = attr "hx-select-oob"
    
    /// Establishes and listens to Server Sent Event (SSE) sources for events
    let _hxSse        = attr "hx-sse"
    
    /// Controls how the response content is swapped into the DOM (e.g. 'outerHTML' or 'beforeEnd')
    let _hxSwap       = attr "hx-swap"
    
    /// Marks content in a response as being "Out of Band", i.e. swapped somewhere other than the target
    let _hxSwapOob    = attr "hx-swap-oob"
    
    /// Synchronize events based on another element
    let _hxSync       = attr "hx-sync"
    
    /// Specifies the target element to be swapped
    let _hxTarget     = attr "hx-target"
    
    /// Specifies the event that triggers the request
    let _hxTrigger    = attr "hx-trigger"
    
    /// Validate an input element (uses HTML5 validation API)
    let _hxValidate   = flag "hx-validate"
    
    /// Adds to the parameters that will be submitted with the request
    let _hxVals       = attr "hx-vals"
    
    /// Establishes a WebSocket or sends information to one
    let _hxWs         = attr "hx-ws"


/// Script tags to pull htmx into an web page
module Script =
  
    /// Script tag to load the minified version from unpkg.com
    let minified =
        script [ _src         "https://unpkg.com/htmx.org@1.8.6"
                 _integrity   "sha384-Bj8qm/6B+71E6FQSySofJOUjA/gq330vEqjFx9LakWybUySyI1IQHwPtbTU7bNwx"
                 _crossorigin "anonymous" ] []

    /// Script tag to load the unminified version from unpkg.com
    let unminified =
        script [ _src         "https://unpkg.com/htmx.org@1.8.6/dist/htmx.js"
                 _integrity   "sha384-denUmZOxhLrCvV+ej1uWe4EXwjmJtWzbg0sjv6YfuHhUAP0CEVIArcYjlUbJHh87"
                 _crossorigin "anonymous" ] []


/// Functions to extract and render an HTML fragment from a document
[<RequireQualifiedAccess>]
module RenderFragment =
    
    /// Does this element have an ID matching the requested ID name?
    let private isIdElement nodeId (elt : XmlElement) =
        snd elt
        |> Array.exists (fun attr ->
            match attr with
            | KeyValue (name, value) -> name = "id" && value = nodeId
            | Boolean _ -> false)

    /// Generate a message if the requested ID node is not found
    let private nodeNotFound (nodeId : string) =
        $"<em>&ndash; ID {nodeId} not found &ndash;</em>"
    
    /// Find the node with the named ID
    let rec findIdNode nodeId (node : XmlNode) : XmlNode option =
        match node with
        | Text _ -> None
        | VoidElement elt -> if isIdElement nodeId elt then Some node else None
        | ParentNode (elt, children) ->
            if isIdElement nodeId elt then Some node else children |> List.tryPick (fun c -> findIdNode nodeId c)
    
    /// Functions to render a fragment as a string
    [<RequireQualifiedAccess>]
    module AsString =

        /// Render to HTML for the given ID
        let htmlFromNodes nodeId (nodes : XmlNode list) =
            match nodes |> List.tryPick(fun node -> findIdNode nodeId node) with
            | Some idNode -> RenderView.AsString.htmlNode idNode
            | None -> nodeNotFound nodeId

        /// Render to HTML for the given ID
        let htmlFromNode nodeId node =
            match findIdNode nodeId node with
            | Some idNode -> RenderView.AsString.htmlNode idNode
            | None -> nodeNotFound nodeId

    /// Functions to render a fragment as bytes
    [<RequireQualifiedAccess>]
    module AsBytes =

        let private utf8 = System.Text.Encoding.UTF8

        /// Render to HTML for the given ID
        let htmlFromNodes nodeId (nodes : XmlNode list) =
            match nodes |> List.tryPick(fun node -> findIdNode nodeId node) with
            | Some idNode -> RenderView.AsBytes.htmlNode idNode
            | None -> nodeNotFound nodeId |> utf8.GetBytes

        /// Render to HTML for the given ID
        let htmlFromNode nodeId node =
            match findIdNode nodeId node with
            | Some idNode -> RenderView.AsBytes.htmlNode idNode
            | None -> nodeNotFound nodeId |> utf8.GetBytes

    /// Functions to render a fragment into a StringBuilder
    [<RequireQualifiedAccess>]
    module IntoStringBuilder =

        /// Render to HTML for the given ID
        let htmlFromNodes sb nodeId (nodes : XmlNode list) =
            match nodes |> List.tryPick(fun node -> findIdNode nodeId node) with
            | Some idNode -> RenderView.IntoStringBuilder.htmlNode sb idNode
            | None -> nodeNotFound nodeId |> sb.Append |> ignore

        /// Render to HTML for the given ID
        let htmlFromNode sb nodeId node =
            match findIdNode nodeId node with
            | Some idNode -> RenderView.IntoStringBuilder.htmlNode sb idNode
            | None -> nodeNotFound nodeId |> sb.Append |> ignore
