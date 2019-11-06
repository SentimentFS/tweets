namespace Tweets.Application.Model
open System
open Tweets.Domain.Model

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
                       Longitude: Nullable<double>
                       Latitude: Nullable<double>
                       TwitterUser: string
                       Sentiment: Emotion } 
with
    static member MapFromTweet(tweet: Tweet) : SearchedTweet =
        { IdStr = tweet.Id
          Text = tweet.Text
          CreationDate = tweet.CreationDate
          Lang = tweet.Language
          Longitude = tweet.Coordinates |> Option.map(fun c -> c.Longitude) |> Option.toNullable
          Latitude = tweet.Coordinates |> Option.map(fun c -> c.Latitude) |> Option.toNullable
          TwitterUser = tweet.User
          Sentiment = Emotion.VeryNegative } 

type SearchedTweets = SearchedTweet seq

type ApplicationError =
    | NoTweets of searchText: string
    
type AsyncResult<'a, 'b> = Async<Result<'a, 'b>>