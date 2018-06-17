#r @"packages/FAKE/tools/FakeLib.dll"

open Fake.Core
open Fake.IO
open Fake.DotNet
open Fake.Testing
open Fake.Core.TargetOperators
open System.IO
open System

let buildDir = "./build"
let testDir = "./test"
let reportDir = "./output"
let outputDir = "./output"

let version = if BuildServer.isLocalBuild then "1.0.0" else BuildServer.buildVersion

Target.create "Clean" (fun _ -> 
      Shell.cleanDirs [buildDir; testDir; reportDir; outputDir]
)

Target.create "BuildSolution" (fun _ ->
    MSBuild.runWithDefaults "Build" ["./ArticleApi.Service.sln"]
    |> Trace.logItems "AppBuild-Output: "
)

Target.create "CreateNuGet" (fun _ ->
    Paket.pack (fun p -> 
        { p with 
            ToolPath = ".paket/paket.exe" 
            Version = version
            OutputPath = outputDir })
)

Target.create "Default"  (fun _ ->
  Trace.trace "Default"
)

"Clean"
    ==> "BuildSolution"
    ==> "Default"
    ==> "CreateNuGet"

Target.runOrDefault "Default"