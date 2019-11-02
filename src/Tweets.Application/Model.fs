namespace Tweets.Application.Model
open System

type Emotion =
    | VeryNegative = -2
    | Negative = -1
    | Neutral = 0
    | Positive = 1
    | VeryPositive = 2
        
type SearchedTweet = { IdStr: string
                       Text: string
                       CreationDate: DateTime
                       Lang: string
                       Longitude: double
                       Latitude: double
                       TwitterUser: string
                       Sentiment: Emotion }

type SearchedTweets = SearchedTweet seq

type ApplicationError =
    | NoTweets of searchText: string
    
type AsyncResult<'a, 'b> = Async<Result<'a, 'b>>