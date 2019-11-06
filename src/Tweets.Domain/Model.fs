namespace Tweets.Domain.Model
open System

type Emotion =
    | VeryNegative 
    | Negative 
    | Neutral 
    | Positive
    | VeryPositive

type Coordinates = { Longitude: double; Latitude: double }

type TwitterUser = string

type TweetId = string

type Sentiment = Emotion option 

type Tweet = { Id: TweetId
               Text: string
               CreationDate: DateTime
               Language: string
               Coordinates: Coordinates option
               User: TwitterUser
               Sentiment: Sentiment }

type Tweets = Tweet seq