## Giraffe.Htmx

This package enables server-side support for [htmx](https://htmx.org) within [Giraffe](https://giraffe.wiki) and ASP.NET's `HttpContext`.

**htmx version: 1.7.0**

### Setup

1. Install the package.
2. Prior to using the request header extension properties or the header-setting `HttpHandler`s, `open Giraffe.Htmx`.

### Use

To obtain a request header, using the `IHeaderDictionary` extension properties:

```fsharp
  let myHandler : HttpHander =
    fun next ctx ->
      match ctx.HxPrompt with
      | Some prompt -> ... // do something with the text the user provided
      | None -> ... // no text provided
```

To set a response header:

```fsharp
  let myHandler : HttpHander =
    fun next ctx ->
      // some meaningful work
      withHxPush "/some/new/url" >=> [other handlers]
```

### Learn

The naming conventions of this library were selected to mirror those provided by htmx. The header properties become `Hx*` on the `ctx.Request.Headers` object, and the response handlers are `withHx*` based on the header being set. The only part that does not line up is `withHxTrigger*` and `withHxTriggerMany`; the former set work with a single string (to trigger a single event with no arguments), while the latter set supports both arguments and multiple events.