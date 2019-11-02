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

type Tweet = { IdStr: string
               Text: string
               CreationDate: DateTime
               Language: string
               Coordinates: Coordinates option
               User: TwitterUser
               Sentiment: Emotion option }

type Tweets = Tweet seq