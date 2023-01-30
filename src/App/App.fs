module App

open Sutil
open Sutil.CoreElements

open type Feliz.length
open Fable.React.ReactDomBindings

let reactElement (reactEl : Fable.React.ReactElement ) =
    host <| fun el -> ReactDom.render(reactEl, el)

let view() =
    Html.div [
        Attr.style [
            Css.fontFamily "Arial, Helvetica, sans-serif"
            Css.textAlignCenter
            Css.marginTop (px 40)
            Css.fontSize (rem 3)
        ]
        Html.text "Hello World from Sutil"

        Html.div [
            Attr.style [  Css.height (vh 80) ]
            reactElement (ReactSandbox.ReactFlowDemo())
        ]
    ]

view() |> Program.mountElement "sutil-app"
