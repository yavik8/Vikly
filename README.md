# Vikly
In the world where sharing of well formatted data has become a necessity and Our URL lengths have gotten longer.
That's where Shortnr and Sharebin will come into play as it's obvious by the naming scheme that

- **Shortnr** is going to be useful for making lengthy URLs shorter. 
- **Sharebin** will allow users to share text documents.


## Tech Stack Used :

- ### Backend - C# (.NET)
- ### Database - MsSQL , MongoDB

Note :
I chose MSSQL as a primary database for Smllr and ShareBin because I planned to add User Service and some dashboard like stuff for urls and sharebin docs generated by a user to this web application but because of some time constrains I have not been able to do it yet.


### System Design Diagram :
![Sys-Design](./ssyd.png)

## Models :

- #### Key Model
```
  key : String ,
  isBeingUsed : Boolean
```

- #### ShortnR Model
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
