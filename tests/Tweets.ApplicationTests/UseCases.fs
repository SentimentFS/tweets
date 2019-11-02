namespace Tweets.ApplicationTests
open System

module UseCase = 
    open Expecto
    open Tweets.Application.UseCase
    open Tweets.Application.Model
    open Tweets.Application
    open Tweets.Domain.Types
    open Tweets.Domain.Model
    open FSharp.Control.Tasks

    [<Tests>]
    let tests = 
        testList "UseCases" [
            testList "SearchTweets" [
                testCaseAsync "Search when tweets no exists" <| async {
                    let findTweets _ = async { return None }
                    let! subject = searchTweets findTweets "Test"
                    Expect.isError subject "subject should be error"
                    Expect.equal subject (Error(NoTweets("Test"))) ""
                }
                testCaseAsync "Search when tweets exists" <| async {
                    let findTweets _ = async { return Some([ { IdStr = "Test"
                                                               Text = ""
                                                               CreationDate = DateTime.UtcNow
                                                               Language = "PL"
                                                               Coordinates = None
                                                               User = ""
                                                               Sentiment = Some(VeryNegative) }] |> List.toSeq ) }
                    let! subject = searchTweets findTweets "Test"
                    Expect.isOk subject "subject should be ok"
                    let record = subject |> Result.map(fun v -> v |> Seq.head)
                    match record with
                    | Ok(tweet) -> 
                        Expect.equal tweet.IdStr "Test" ""
                }
            ]
        ]