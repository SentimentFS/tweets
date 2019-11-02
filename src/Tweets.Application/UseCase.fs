namespace Tweets.Application
open Tweets.Application.Model
open Tweets.Domain.Types

module UseCase =
    let searchTweets (findTweets: FindTweets) (searchPhrase: string): AsyncResult<SearchedTweets, ApplicationError> =
        async {
            match! findTweets(searchPhrase) with
            | Some(tweets) ->
                return Error(NoTweets(searchPhrase))
            | None ->
                return Error(NoTweets(searchPhrase))
        }