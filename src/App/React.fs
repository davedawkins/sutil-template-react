module ReactSandbox

// See https://github.com/tforkmann/Feliz.ReactFlow for details on this example

open Feliz.ReactFlow
open Browser.Dom

open Feliz
[<ReactComponent>]
let Counter() =
    let (count, setCount) = React.useState(0)
    Html.div [
        prop.style [ style.padding 10 ]
        prop.children [
            ReactFlow.handle [
                handle.``type`` Target
                handle.position Top
            ]
            Html.button [
                prop.style [ style.marginRight 5 ]
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Increment"
            ]
            Html.text count
        ]
    ]

let ReactFlowDemo() =
    ReactFlow.flowChart [
            ReactFlow.nodeTypes {| test = Counter |}
            ReactFlow.elements [|
                ReactFlow.node [
                    node.id "1"
                    node.nodetype Input
                    node.data {| label = "Erdgas Einsatz" |}
                    node.style [
                        style.background "yellow"
                        Feliz.ReactFlow.style.color "#332"
                        Feliz.ReactFlow.style.border "1px solid #222138"
                        Feliz.ReactFlow.style.width 180
                    ]
                    node.position (50, 30)
                ]
                ReactFlow.node [
                    node.id "2"
                    node.nodetype Default
                    node.data {| label = "CityCube" |}
                    node.style [
                        Feliz.ReactFlow.style.background "#2e88c9"
                        Feliz.ReactFlow.style.color "white"
                        Feliz.ReactFlow.style.border "1px solid #222138"
                        Feliz.ReactFlow.style.width 180
                    ]
                    node.position (400, 30)
                ]
                ReactFlow.node [
                    node.id "3"
                    node.nodetype Output
                    node.data {| label = "Strom Absatz" |}
                    node.style [
                        style.background "lightblue"
                        Feliz.ReactFlow.style.color "#333"
                        Feliz.ReactFlow.style.border "1px solid #222138"
                        Feliz.ReactFlow.style.width 180
                    ]
                    node.position (300, 200)
                ]
                ReactFlow.node [
                    node.id "4"
                    node.nodetype Output
                    node.data {| label = "Wärme Absatz" |}
                    node.style [
                        Feliz.ReactFlow.style.background "red"
                        Feliz.ReactFlow.style.color "white"
                        Feliz.ReactFlow.style.border "1px solid #222138"
                        Feliz.ReactFlow.style.width 180
                    ]
                    node.position (500, 200)
                ]
                ReactFlow.node [
                    node.id "5"
                    node.nodetype (Custom "test")
                    node.data {| label = "Test" |}
                    node.position (50, 120)
                    node.style [
                        style.background "lightgreen"
                        Feliz.ReactFlow.style.border "1px solid black"
                        Feliz.ReactFlow.style.width 180
                    ]
                ]
                ReactFlow.edge [
                    edge.id "e1-2"
                    edge.source "1"
                    edge.target "2"
                    edge.animated false
                    edge.label "100 MWh"
                    edge.edgeType SmoothStep
                    edge.arrowHeadType ArrowClosed
                    edge.style [ style.stroke "blue" ]
                    edge.labelStyle [
                        labelStyle.fill "black"
                        labelStyle.fontWeight 700
                    ]
                ]
                ReactFlow.edge [
                    edge.id "e2-3"
                    edge.source "2"
                    edge.target "3"
                    edge.animated true
                    edge.label "50 MWh"
                    edge.edgeType SmoothStep
                    edge.arrowHeadType ArrowClosed
                    edge.style [ style.stroke "blue" ]
                    edge.labelStyle [
                        labelStyle.fill "blue"
                        labelStyle.fontWeight 700
                    ]
                ]
                ReactFlow.edge [
                    edge.id "e2-4"
                    edge.source "2"
                    edge.target "4"
                    edge.animated true
                    edge.label "55 MWh"
                    edge.edgeType SmoothStep
                    edge.arrowHeadType ArrowClosed
                    edge.style [ style.stroke "red" ]
                    edge.labelStyle [
                        labelStyle.fill "red"
                        labelStyle.fontWeight 700
                    ]
                ]
                ReactFlow.edge [
                    edge.id "e1-5"
                    edge.source "1"
                    edge.target "5"
                    edge.edgeType SmoothStep
                    edge.style [ style.stroke "black" ]
                ]
            |]
            ReactFlow.onElementClick
                (fun ev element ->
                    console.log ev
                    window.alert "You clicked me!")
            ReactFlow.onNodeDragStop
                (fun ev node ->
                    console.log ev
                    window.alert "You dragged me!")
            ReactFlow.onElementsRemove
                (fun elements ->
                    console.log elements
                    window.alert "You removed me!")
            ReactFlow.onConnect
                (fun ev ->
                    console.log ev
                    window.alert "You connected me!")
            ReactFlow.onConnectStart
                (fun ev nodeId ->
                    console.log ev
                    window.alert "You started to connect me!")
        ]