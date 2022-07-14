/// Common definitions shared between attribute values and response headers
[<AutoOpen>]
module Giraffe.Htmx.Common

/// Valid values for the `hx-swap` attribute / `HX-Reswap` header (may be combined with swap/settle/scroll/show config)
[<RequireQualifiedAccess>]
module HxSwap =
    
    /// The default, replace the inner html of the target element
    let InnerHtml = "innerHTML"
    
    /// Replace the entire target element with the response
    let OuterHtml = "outerHTML"
    
    /// Insert the response before the target element
    let BeforeBegin = "beforebegin"
    
    /// Insert the response before the first child of the target element
    let AfterBegin = "afterbegin"
    
    /// Insert the response after the last child of the target element
    let BeforeEnd = "beforeend"
    
    /// Insert the response after the target element
    let AfterEnd = "afterend"
    
    /// Does not append content from response (out of band items will still be processed).
    let None = "none"
