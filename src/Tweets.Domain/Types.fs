namespace Tweets.Domain.Types
open Tweets.Domain.Model

type FindTweets = string -> Async<Tweets option>

