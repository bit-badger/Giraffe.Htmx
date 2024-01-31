## Giraffe.Htmx

This package enables server-side support for [htmx](https://htmx.org) within [Giraffe](https://giraffe.wiki) and ASP.NET's `HttpContext`.

**htmx version: 2.0.0-alpha1**

_Note that htmx 2.0 is an ALPHA release. The [migration guide](https://v2-0v2-0.htmx.org/migration-guide-htmx-1/) does not currently specify any request or response header changes. This means that, as of this release, there are no required code changes in moving to this major version._

### Setup

1. Install the package (must use `--Prerelease` flag).
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
      withHxPushUrl "/some/new/url" >=> [other handlers]
```

The `HxSwap` module has constants to use for the `HX-Reswap` header. These may be extended with settle, show, and other qualifiers; see the htmx documentation for the `hx-swap` attribute for more information.

### Learn

The naming conventions of this library were selected to mirror those provided by htmx. The header properties become `Hx*` on the `ctx.Request.Headers` object, and the response handlers are `withHx*` based on the header being set. The only part that does not line up is `withHxTrigger*` and `withHxTriggerMany`; the former set work with a single string (to trigger a single event with no arguments), while the latter set supports both arguments and multiple events.