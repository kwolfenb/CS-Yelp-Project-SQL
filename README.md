# _Yelp Restaurants and Cuisines Project_

#### _C# application with SQL database that allows users to add restaurants in cuisine categories. 12.06.2018_

#### By _**Kenny Wolfenberger and Daniel Lira**_

## Description

_A C# application that is connected to a SQL database with tables for Restaurants and Cuisines. Users can add to the restaurant lists within cuisine categories. Restaurants contain name, address, phone number and cuisine type properties._

## Setup/Installation Requirements

* _Clone this repository: $ git clone https://github.com/kwolfenb/CS-Yelp-Project-SQL.git_
* _To edit the project, open the project in your preferred text editor._
* _To run the program, first navigate to the location of the Yelp file then run dotnet restore, dotnet build, and dotnet run._
* _When program is running open a web browser and go to localhost:5000 to view program._
* _To run the tests navigate to the Yelp.Tests folder and use these commands: $ dotnet restore and dotnet test._ 

## Support and contact details

* _Kenny Wolfenberger - kennywolfenberger@gmail.com_
* _Daniel Lira - devidra87@gmail.com_

### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| Program can take new user input for Cuisine types | "Japanese" | List: Japanese  |
| Program can take new user input for Restaurant types | "Bobo's Grill" | List: Bobo's Grill  |
| Program will relate restaurants with cuisine types based on cuisine ID | "Bobo's Grill" -> Japanese Cuisine | "Bobo's Grill" -> Japanese Cuisine |


## Technologies Used

* _C#_
* _.NET_
* _MSTests_
* _MVC_
* _Razor_
* _Mono_

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Kenny Wolfenberger, Daniel Lira_**

