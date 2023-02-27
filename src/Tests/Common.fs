module Common

open Expecto
open Giraffe.Htmx

/// Tests for the HxSwap module
let swap =
    testList "HxSwap" [
        test "InnerHtml is correct" {
            Expect.equal HxSwap.InnerHtml "innerHTML" "Inner HTML swap value incorrect"
        }
        test "OuterHtml is correct" {
            Expect.equal HxSwap.OuterHtml "outerHTML" "Outer HTML swap value incorrect"
        }
        test "BeforeBegin is correct" {
            Expect.equal HxSwap.BeforeBegin "beforebegin" "Before Begin swap value incorrect"
        }
        test "BeforeEnd is correct" {
            Expect.equal HxSwap.BeforeEnd "beforeend" "Before End swap value incorrect"
        }
        test "AfterBegin is correct" {
            Expect.equal HxSwap.AfterBegin "afterbegin" "After Begin swap value incorrect"
        }
        test "AfterEnd is correct" {
            Expect.equal HxSwap.AfterEnd "afterend" "After End swap value incorrect"
        }
        test "None is correct" {
            Expect.equal HxSwap.None "none" "None swap value incorrect"
        }
    ]

/// All tests for this module
let allTests = testList "Htmx.Common" [ swap ]
