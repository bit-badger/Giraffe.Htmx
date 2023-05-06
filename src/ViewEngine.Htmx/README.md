## Giraffe.ViewEngine.Htmx

This package enables [htmx](https://htmx.org) support within the [Giraffe](https://giraffe.wiki) view engine.

**htmx version: 1.9.2**

### Setup

1. Install the package.
2. Prior to using the attribute or support modules, `open Giraffe.ViewEngine.Htmx`.

### Use

Following Giraffe View Engine's lead, there are a set of attribute functions for htmx; for many of the attributes, there are also helper modules to assist with typing the values. The example below utilizes both:

```fsharp
  let autoload =
    div [ _hxGet "/this/data"; _hxTrigger HxTrigger.Load ] [ str "Loading..." ]
```

Support modules include:
- `HxEncoding`
- `HxHeaders`
- `HxParams`
- `HxRequest`
- `HxSwap` (requires `open Giraffe.Htmx`)
- `HxTrigger`
- `HxVals`

There are two `XmlNode`s that will load the htmx script from unpkg; `Htmx.Script.minified` loads the minified version, and `Htmx.Script.unminified` loads the unminified version (useful for debugging).

This also supports [fragment rendering](https://bitbadger.solutions/blog/2022/fragment-rendering-in-giraffe-view-engine.html), providing the flexibility to render an entire template, or only a portion of it (based on the element's `id` attribute).

### Learn

htmx's attributes and these attribute functions map one-to-one. There are two exceptions:
- `_hxBoost` implies `true`; use `_hxNoBoost` to set it to `false`.
- `_hxSwapWithTransition` renders the standard `hx-swap` attribute and appends `transition:true` to the specified swap value.

The htmx `hx-on` attribute supports multiple events if they are separated with a newline (`\n`) character. The value provided to this attribute will be attribute-escaped, but in testing, it was interpreted correctly.

The support modules contain named properties for known values (as illustrated with `HxTrigger.Load` above). A few of the modules are more than collections of names, though:
- `HxRequest` has a `Configure` function, which takes a list of strings; the other functions in the module allow for configuring the request.

```fsharp
  HxRequest.Configure [ HxRequest.Timeout 500 ] |> _hxRequest 
```
- `HxTrigger` is _(by far)_ the most complex of these modules. Most uses won't need that complexity; however, complex triggers can be defined by piping into or composing with other functions. For example, to define an event that responds to a shift-click anywhere on the document, with a delay of 3 seconds before firing:

```fsharp
  HxTrigger.Click
  |> HxTrigger.Filter.Shift
  |> HxTrigger.FromDocument
  |> HxTrigger.Delay "3s"
  |> _hxTrigger
  
  // or
  
  (HxTrigger.Filter.Shift >> HxTrigger.FromDocument >> HxTrigger.Delay "3s") HxTrigger.Click
  |> _hxTrigger
```
