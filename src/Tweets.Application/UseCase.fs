namespace Tweets.Application
open Tweets.Application.Model

module UseCase =
    let searchTweets (searchPhrase: string) : AsyncResult<SearchedTweets, ApplicationError> =
        async {
            return Error(NoTweets(searchPhrase))
        }