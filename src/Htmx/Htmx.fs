module Giraffe.Htmx

open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Primitives
open System

/// Determine if the given header is present
let private hdr (headers : IHeaderDictionary) hdr =
  match headers.[hdr] with it when it = StringValues.Empty -> None | it -> Some it.[0]

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

  /// Always `true`
  member this.HxRequest with get () = hdr this "HX-Request" |> Option.map bool.Parse

  /// The `id` of the target element if it exists
  member this.HxTarget with get () = hdr this "HX-Target"

  /// The `id` of the triggered element if it exists
  member this.HxTrigger with get () = hdr this "HX-Trigger"

  /// The `name` of the triggered element if it exists
  member this.HxTriggerName with get () = hdr this "HX-Trigger-Name"


/// Extensions for the request object
type HttpRequest with

  /// Whether this request was initiated from HTMX
  member this.IsHtmx with get () = this.Headers.HxRequest |> Option.defaultValue false

  /// Whether this request is an HTMX history-miss refresh request
  member this.IsHtmxRefresh with get () =
    this.IsHtmx && (this.Headers.HxHistoryRestoreRequest |> Option.defaultValue false)


/// HTTP handlers for setting output headers
[<AutoOpen>]
module Handlers =
  
  /// Serialize an object to JSON (supports triggering multiple events)
  let private toJson (it : obj) =
    match it with
    | :? string as x -> x
    | _ -> "" // TODO: serialize object
    |> StringValues

  /// Pushes a new url into the history stack
  let withHxPush (push : bool) : HttpHandler =
    fun next ctx -> task {
      ctx.Response.Headers.["HX-Push"] <- push |> (string >> StringValues)
      return! next ctx
      }
  
  /// Can be used to do a client-side redirect to a new location
  let withHxRedirect (url : string) : HttpHandler =
    fun next ctx -> task {
      ctx.Response.Headers.["HX-Redirect"] <- StringValues url
      return! next ctx
      }
  
  /// If set to `true` the client side will do a a full refresh of the page
  let withHxRefresh (refresh : bool) : HttpHandler =
    fun next ctx -> task {
      ctx.Response.Headers.["HX-Redirect"] <- refresh |> (string >> StringValues)
      return! next ctx
      }

  /// Allows you to trigger client side events
  /// 
  /// _(strings will be passed verbatim; objects will be JSON-encoded)_
  let withHxTrigger (trig : obj) : HttpHandler =
    fun next ctx -> task {
      ctx.Response.Headers.["HX-Trigger"] <- toJson trig
      return! next ctx
      }
    
  /// Allows you to trigger client side events after changes have settled
  /// 
  /// _(strings will be passed verbatim; objects will be JSON-encoded)_
  let withHxTriggerAfterSettle (trig : obj) : HttpHandler =
    fun next ctx -> task {
      ctx.Response.Headers.["HX-Trigger-After-Settle"] <- toJson trig
      return! next ctx
      }
    
  /// Allows you to trigger client side events after DOM swapping occurs
  /// 
  /// _(strings will be passed verbatim; objects will be JSON-encoded)_
  let withHxTriggerAfterSwap (trig : obj) : HttpHandler =
    fun next ctx -> task {
      ctx.Response.Headers.["HX-Trigger-After-Swap"] <- toJson trig
      return! next ctx
      }
