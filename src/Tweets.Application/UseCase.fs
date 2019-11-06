namespace Tweets.Application
open Tweets.Application.Model
open Tweets.Domain.Types

module UseCase =
    let searchTweets (findTweets: FindTweets) (searchPhrase: string): AsyncResult<SearchedTweets, ApplicationError> =
        async {
            match! findTweets(searchPhrase) with
            | Some(tweets) ->
                return Ok(tweets |> Seq.map(SearchedTweet.MapFromTweet))
            | None ->
                return Error(NoTweets(searchPhrase))
        }