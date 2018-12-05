# _Word Counter Project_

#### _Independent Project for C# week 1 and 2, 11.30.2018_

#### By _**Kenny Wolfenberger**_

## Description

_A C# application that takes both a word and a sentence from a user. It then checks how frequently the word appears in the sentence and returns this information to the user._

## Setup/Installation Requirements

* _Clone this repository: $ git clone https://github.com/kwolfenb/WordCounter.Solution.git_
* _To edit the project, open the project in your preferred text editor._
* _To run the program, first navigate to the location of the WordCounter file then run dotnet restore, dotnet build, and dotnet run._
* _When program is running open a web browser and go to localhost:5000 to view program._
* _To run the tests navigate to the WordCounter.Tests folder and use these commands: $ dotnet restore and dotnet test._ 

## Support and contact details

_Kenny Wolfenberger - kennywolfenberger@gmail.com_

### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| Program can identify user's inputted word | "tea" | Your word is: tea  |
| Program can identify user's inputted sentence | "I like coffee." | Your sentence is: I like coffee.  |
| Program can identify when the word is not in the sentence | "tea", "I like coffee." | Your word does not appear in your sentence |
| Program can identify when the word is in the sentence | "coffee", "I like coffee" | Your word appears in your sentence 1 time |
| Program counts the number of times the word is in the sentence | "car", "My car is faster than your car" | Your word appears in your sentence 2 times  | 
| Program counts words that are next to punctuation marks | "hungry", "Are you hungry?" | Your word appears in your sentence 1 time  |
| Program does not count words contained in other words | "read", "is everyone ready?" | Your word does not appear in your sentence |
| Program records history of games played | click: "Back to instructions and game history" | See "Previous game results" section |
| Program clears game history upon request | click: "Clear Game History" | "Previous game results" section is now empty |


## Technologies Used

* _C#_
* _.NET_
* _MSTests_
* _MVC_
* _Razor_
* _Mono_

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Kenny Wolfenberger_**

