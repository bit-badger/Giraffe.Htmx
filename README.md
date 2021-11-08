# Giraffe.Htmx

[Giraffe](https://giraffe.wiki) is a library that sits atop ASP.NET Core, and enables developers to create applications in a functional style (vs. the C# / object-oriented style of the base library). The Giraffe View Engine enables production of HTML views in a strongly-typed and fully-integrated-with-source fashion.

[htmx](https://htmx.org) is a library that embraces the idea of HTML as a programming language, where any element can fire off a request, and portions of the page can be swapped out dynamically. It does all these with a tiny, dependency-free JavaScript library.

htmx uses attributes and HTTP headers to attain its interactivity; the libraries here contain extensions to both Giraffe and Giraffe View Engine to enable strongly-typed development of htmx applications.

## Installation

`Giraffe.Htmx` provides extensions that facilitate using htmx on the server side, primarily reading and setting headers. `Giraffe.ViewEngine.Htmx` provides attributes and helpers to produce views that utilize htmx. Both can be installed from NuGet via standard methods.

| Server Side | View Engine |
|---|---|
|[![Nuget](https://img.shields.io/nuget/v/Giraffe.Htmx?style=plastic)](https://www.nuget.org/packages/Giraffe.Htmx/)|[![Nuget](https://img.shields.io/nuget/v/Giraffe.ViewEngine.Htmx?style=plastic)](https://www.nuget.org/packages/Giraffe.ViewEngine.Htmx/)|

## Server Side (`Giraffe.Htmx`)

In addition to the regular HTTP request payloads, htmx sets [one or more headers](https://htmx.org/docs/#request_headers) along with the request. Once `Giraffe.Htmx` is opened, these are available as properties on `HttpContext.Request.Headers`. These consist of the header name, translated to a .NET name (ex. `HX-Current-URL` becomes `HxCurrentUrl`), and a strongly-typed property based on the expected value of that header. Additionally, they are all exposed as `Option`s, as they may or may not be present for any given request.

A server may want to respond to a request that originated from htmx differently than a regular request. One way htmx can provide the same feel as a Single Page Application (SPA) is by swapping out the `body` content (or an element within it) instead of reloading the entire page. In this case, the developer can provide a partial layout to be used for these responses, while returning the full page for regular requests. The `IsHtmx` property makes this easy...

```fsharp
  // "partial" and "full" are handlers that return the contents;
  // "view" can be whatever your view engine needs for the body of the page
  let result view : HttpHandler =
    fun next ctx ->
      match ctx.Request.IsHtmx && not ctx.Request.IsHtmxRefresh with
      | true -> partial view
      | false -> full view
```

htmx also utilizes [response headers](https://htmx.org/docs/#response_headers) to affect client-side behavior. For each of these, this library provides `HttpHandler`s that can be chained along with the response. As an example, if the server returns a redirect response (301, 302, 303, 307), the `XMLHttpRequest` handler on the client will follow the redirection before htmx can do anything with it. To redirect to a new page, you would return an OK (200) response with an `HX-Redirect` header set in the response.

```fsharp
  let theHandler : HttpHandler =
    fun next ctx ->
      // some interesting stuff
      withHxRedirect "/the-new-url" >=> Successful.OK
```

Of note is that the `HX-Trigger` headers can take either one or more events. For a single event with no parameters, use `withHxTrigger`; for a single event with parameters, or multiple events, use `withHxTriggerMany`. Both these have `AfterSettle` and `AfterSwap` versions as well.

## View Engine (`Giraffe.ViewEngine.Htmx`)

As htmx uses [attributes](https://htmx.org/docs/#attributes) to extend HTML, the primary part of this library defines attributes that can be used within Giraffe views. Simply open `Giraffe.ViewEngine.Htmx`, and these attributes, along with support modules, will be visible.

As an example, creating a `div` that loads data once the HTML is rendered:

```fsharp
  let autoload =
    div [ _hxGet "/lazy-load-data"; _hxTrigger "load" ] [ str "Loading..." ]
```

_(As `hx-boost="true"` is the usual desire for boosting, `_hxBoost` implies true. To disable it for an element, use `_hxNoBoost` instead.)_

Some attributes have known values, such as `hx-trigger` and `hx-swap`; for these, there are modules with those values. For example, `HxTrigger.Load` could be used in the example above, to ensure that the known values are spelled correctly. `hx-trigger` can also take modifiers, such as an action that only responds to `Ctrl`+click. The `HxTrigger` module has a `Filter` submodule to assist with defining these actions.

```fsharp
  let shiftClick =
    p [ _hxGet = "/something"; _hxTrigger (HxTrigger.Filter.Shift HxTrigger.Click) ] [
      str "hold down Shift and click me"
      ]
```

## Feedback / Help

The author hangs out in the #htmx-general channel of the [htmx Discord server](https://htmx.org/discord) and the #web channel of the [F# Software Foundation's Slack server](https://fsharp.org/guides/slack/).

## Thanks
|[<img src="https://giraffe.wiki/giraffe.png" alt="Giraffe logo" width="200">](https://giraffe.wiki)|[<img src="https://bitbadger.solutions/htmx-black-transparent.svg" alt="htmx logo" width="200">](https://htmx.org)|[<img src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.png" alt="JetBrains Logo (Main)" width="200">](https://jb.gg/OpenSource)|
| :---: | :---: | :---: |
|for making ASP.NET Core functional|for making HTML cool again|for licensing their tools to this project|

