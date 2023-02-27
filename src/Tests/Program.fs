open Expecto

let allTests = testList "Giraffe" [ Common.allTests; Htmx.allTests; ViewEngine.allTests ]

[<EntryPoint>]
let main args = runTestsWithArgs defaultConfig args allTests
