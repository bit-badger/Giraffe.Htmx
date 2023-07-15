module Giraffe.Htmx

open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Primitives
open System

/// Determine if the given header is present
let private hdr (headers : IHeaderDictionary) hdr =
    match headers[hdr] with it when it = StringValues.Empty -> None | it -> Some it[0]

/// Extensions to the header dictionary
type IHeaderDictionary with
  
    /// Indicates that the request is via an element using `hx-boost`
    member this.HxBoosted with get () = hdr this "HX-Boosted" |> Option.map bool.Parse
    
    /// The current URL of the browser _(note that this does not update until after settle)_
    member this.HxCurrentUrl with get () = hdr this "HX-Current-URL" |> Option.map Uri
    
    /// `true` if the request is for history restoration after a miss in the local history cache
    member this.HxHistoryRestoreRequest with get () = hdr this "HX-History-Restore-Request" |> Option.map bool.Parse
    
    /// The user response to an `hx-prompt`
    member this.HxPrompt with get () = hdr this "HX-Prompt"

    /// `true` if the request came from HTMX
    member this.HxRequest with get () = hdr this "HX-Request" |> Option.map bool.Parse

    /// The `id` of the target element if it exists
    member this.HxTarget with get () = hdr this "HX-Target"

    /// The `id` of the triggered element if it exists
    member this.HxTrigger with get () = hdr this "HX-Trigger"

    /// The `name` of the triggered element if it exists
    member this.HxTriggerName with get () = hdr this "HX-Trigger-Name"


/// Extensions for the request object
type HttpRequest with

    /// Whether this request was initiated from htmx
    member this.IsHtmx with get () = this.Headers.HxRequest |> Option.defaultValue false

    /// Whether this request is an htmx history-miss refresh request
    member this.IsHtmxRefresh with get () =
        this.IsHtmx && (this.Headers.HxHistoryRestoreRequest |> Option.defaultValue false)


/// HTTP handlers for setting output headers
[<AutoOpen>]
module Handlers =

    /// Convert a boolean to lowercase `true` or `false`
    let private toLowerBool (trueOrFalse : bool) =
        (string trueOrFalse).ToLowerInvariant ()

    /// Serialize a list of key/value pairs to JSON (very rudimentary)
    let private toJson (evts : (string * string) list) =
        evts
        |> List.map (fun evt -> sprintf "\"%s\": \"%s\"" (fst evt) ((snd evt).Replace ("\"", "\\\"")))
        |> String.concat ", "
        |> sprintf "{ %s }"

    /// Pushes a new url into the history stack
    let withHxPushUrl : string -> HttpHandler =
        setHttpHeader "HX-Push-Url"

    /// Explicitly do not push a new URL into the history stack
    let withHxNoPushUrl : HttpHandler =
        toLowerBool false |> withHxPushUrl
      
    /// Pushes a new url into the history stack
    [<Obsolete "Use withHxPushUrl; HX-Push was replaced by HX-Push-Url in v1.8.0">]
    let withHxPush = withHxPushUrl
    
    /// Explicitly do not push a new URL into the history stack
    [<Obsolete "Use withHxNoPushUrl; HX-Push was replaced by HX-Push-Url in v1.8.0">]
    let withHxNoPush = withHxNoPushUrl
      
    /// Can be used to do a client-side redirect to a new location
    let withHxRedirect : string -> HttpHandler =
        setHttpHeader "HX-Redirect"

    /// If set to `true` the client side will do a a full refresh of the page
    let withHxRefresh : bool -> HttpHandler =
        toLowerBool >> setHttpHeader "HX-Refresh"

    /// Replaces the current URL in the history stack
    let withHxReplaceUrl : string -> HttpHandler =
        setHttpHeader "HX-Replace-Url"

    /// Explicitly do not replace the current URL in the history stack
    let withHxNoReplaceUrl : HttpHandler =
        toLowerBool false |> withHxReplaceUrl
    
    /// Override which portion of the response will be swapped into the target document
    let withHxReselect : string -> HttpHandler =
        setHttpHeader "HX-Reselect"
    
    /// Override the `hx-swap` attribute from the initiating element
    let withHxReswap : string -> HttpHandler =
        setHttpHeader "HX-Reswap"

    /// Allows you to override the `hx-target` attribute
    let withHxRetarget : string -> HttpHandler =
        setHttpHeader "HX-Retarget"

    /// Allows you to trigger a single client side event
    let withHxTrigger : string -> HttpHandler =
        setHttpHeader "HX-Trigger"

    /// Allows you to trigger multiple client side events
    let withHxTriggerMany evts : HttpHandler =
        toJson evts |> setHttpHeader "HX-Trigger"

    /// Allows you to trigger a single client side event after changes have settled
    let withHxTriggerAfterSettle : string -> HttpHandler =
        setHttpHeader "HX-Trigger-After-Settle"

    /// Allows you to trigger multiple client side events after changes have settled
    let withHxTriggerManyAfterSettle evts : HttpHandler =
        toJson evts |> setHttpHeader "HX-Trigger-After-Settle"

    /// Allows you to trigger a single client side event after DOM swapping occurs
    let withHxTriggerAfterSwap : string -> HttpHandler =
        setHttpHeader "HX-Trigger-After-Swap"

    /// Allows you to trigger multiple client side events after DOM swapping occurs
    let withHxTriggerManyAfterSwap evts : HttpHandler =
        toJson evts |> setHttpHeader "HX-Trigger-After-Swap"
