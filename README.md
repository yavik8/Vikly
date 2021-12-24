# Vikly
In the world where sharing of well formatted data has become a necessity and Our URL lengths have gotten longer.
That's where Shortnr and Sharebin will come into play as it's obvious by the naming scheme that

- **Shortnr** is going to be useful for making lengthy URLs shorter. 
- **Sharebin** will allow users to share text documents.


## Tech Stack Used :

- ### Backend - C# (.NET)
- ### Database - MsSQL , MongoDB


### System Design Diagram :
![Sys-Design](./OtherStuff/SystemDesign.jpeg)

## Models :

- #### Key Model
```
  key : String ,
  isBeingUsed : Boolean
```

- #### SmllR Model
```
{
  shortenUrlPart : String ,
  mainUrl : String ,
  creationDate : Date, 
  numberOfClicks : int
}
```

- #### ShareBin Model
```
{
    shareBinKey : String ,
    shareBinTitle : String ,
    shareBinCode : String ,
    numberOfClicks : int
}
```
