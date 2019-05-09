# To Do List ![alt text](https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png "Logo Title Text 1")
#### A program that gathers both a word and sentence from a user, then checks how frequently the word appears in the sentence. , 05.09.2019


[ By _**Mariia Stashuk **_](https://www.linkedin.com/in/mariia-stashuk-66754816a/)
[ & _**Sabrina Mianne **_](https://www.linkedin.com/in/mariia-stashuk-66754816a/)

## Description

A program that gathers both a word and sentence from a user, then checks how frequently the word appears in the sentence. It should check for full word matches only. (For instance, if provided the word "cat" and sentence "I'm walking to the cathedral." the first three letters of the word cathedral would not be counted.)



## Setup/Installation Requirements

_To run this project,install it locally:_


* Download .NET Core 2.1.3 SDK and .NET Core Runtime 2.0.9 and install them. Download Mono and Install it.
* Clone this repository https://github.com/Marrri4ka/Word-Counter.git
* Open the project in your preferred text editor to modify the files.
* To run the program, navigate to WordCounter.Solution/WordCounter and use $dotnet build &&  $dotnet run
* Navigate to localhost:5000


## Word Counter Specifications

 List of specs from the simplest possible behavior to the most complex behavior:

| Behavior       | Input          | Output  |
| ------------- |:-------------:| -----:|
|User enter two same words      | "cat" "cat cat"   |2|
|User enter sentence of two different words | "cat" "cat dog"    |  1 |
| User enter sentence of three words, where tow words are the same   | "cat" "cat dog cat"   |   2 |
|User enter sentence with word 'meercat' | "cat" "I am a meercat" | 0 |
|User can use lower or upper case| "cat" This is Cat | 1 |
|User can enter sentence with different punctuation| "cat" This is Cat;not dog | 1 |
|User enter instead of word a number | "1" This is Cat;not dog | "please use only letters" |
|User forgot to enter a sentence  | "1"  | "please enter at least one word" |

## Description
![Alt text](/img/1.png)
![Alt text](/img/2.png)
![Alt text](/img1/3.png)


## Known Bugs

No bugs.

## Support and contact details

If you have any questions or problems, please contact Mariia (mariiapopovych@gmail.com) or Sabrina  (mariiapopovych@gmail.com)

## Technologies Used

* C#
* .NET


### License

*License under MIT*

[![MIT Licence](https://badges.frapsoft.com/os/mit/mit.svg?v=103)](https://opensource.org/licenses/mit-license.php)

Copyright (c) 2019 **_Mariia Stashuk_ & _Sabrina Mianne_ **
