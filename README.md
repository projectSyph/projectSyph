       
# project Syph

					
> Project Syph is an open-source turn-based game written in C# with support for 2 (1v1),  3 (everyone for themselves) or 4 (2v2) players. It is developed as the first  team project for Telerik Academy Alpha. 

## State -> Under Development (branch work)

## About
When you start a new game, you have to enter your 
username, which will be used for the period of 
the game.  There can be 2, 3 or 4 players. 
Each player starts with 8000 souls and the goal
 is to keep them for as long as you can.

You can have different spawns, each with their 
own attack, health, armor, energy and souls. 
Each creature requires 20 energy to attack. 
When its energy drops to zero or below, it 
loses 80% of its current health  and all of 
its armor.

When your spawn attacks three things can happen:
- If its attack is higher than the opponent's, 
its attack is removed from the opponent's armor 
first, health second and player's souls third. 
If your spawn's oponent's health hits zero, 
it dies and your spawn takes its souls. 
If you attack another player you take their 
souls and add them to your own. 
    (Example: Your spawn has 350 attack and its
 opponent has 100 attack, 200 health and 100 armor, 
the opponent loses 100 armor and 200 health, 
and the player who owns it loses 50 souls, 
which are added to your souls).

- If your spawn's attack is equal to its 
			opponent's, both die.

- If its attack is lower than the opponent's, 
it is the same logic as the first, only reversed.

The game ends when there is 
	only one player (for 2 or 3 players) or 
	one team (for 4 players) left standing.

## Project Requirements

A console turn based game with support for 2 (1v1), 3 (each for themselves) or 4 (2v2) players.
The program begins with a choice for a new game, options menu, credits (where we will put our names and githubs), a guide menu (we will explain how to play the game there) and exit.
Players enter their names when they choose new game.
    
Every player has an inventory (3 seniors, 7 regulars, 5 juniors) and souls (they begin with 8000). You can trade your souls to spawn creatures (we must think of a few kinds, put suggestions in the new file) /* or cause different disasters (windstorms, plagues, etc.) to happen (they will still require souls, and sometimes even sacrifices) */.

To spawn a creature you will need x souls and each will get 40% health, 20% armour, 20% damage, 20% souls (e.g. if you have spent 1000 souls for a creature it will have 400 health, 200 armor, 200 damage, 200 souls). Each kind of monster will have different damage.

When a creature attacks 3 things can happen: 

- if its damage is higher than the opponent’s, its damage is removed from its opponent’s armor first, and health second (e.g. your monster has 250 damage, opponent has 100 damage 200 health, 100 armor; your monster damages and your opponent loses 100  armor and 150 health).
- if its damage is equal to the opponent’s, both die.
- if its damage is less than the opponent, same thing as the first, only reversed

The game ends when there is only one player (for 2 and 3 players) or only one team (for 4 players) left standing.
You will be able to save the log of the battle in a .txt file in the Windows Documents directory.


## General Requirements

Please define and implement the following object-oriented assets in your project:

At least 5 interfaces (with one or more implementations)
At least 15 classes (implementing the application logic)
At least 3 abstract classes (with inheritors)
At least 1 custom exception class (with usage in your code)
At least 3 levels of depth in inheritance

At least 1 polymorphism usage

At least 1 structure

At least 1 enumeration

At least 1 event (with subscribers)
At least 1 design pattern (e.g. Composite, Singleton, Factory, Wrapper, Bridge, Command,  etc.)


You might read about design patterns in Wikipedia, Sourcemaking, DoFactory and others.


Additional Requirements


Follow the best practices for OO design: use data encapsulation, use exception handling properly, use delegates and events, use inheritance, abstraction and polymorphism properly, follow the principles of strong cohesion and loose coupling
Obligatory use Git to keep your source code and for team collaboration (you might use https://github.com/)
Provide a class diagram (to visualize all types)



Optional Requirements

If you have a chance, time and a suitable situation, you might add some of the following to your project:


Static members (fields, properties, constructor, etc.)
Constants, generic types, indexers, operators overloading
Lambda expressions and LINQ
Implementation of IEnumerable<T>, ICloneable, ToString() override
Namespaces (if your classes are too many)
User interface (UI) – console, desktop, web, mobile or as you like it the most



Non-Required Work


Completely finished project is not obligatory required. It will not be a big problem if your project is not completely finished or is not working greatly. This team work project is for educational purpose. Its main purpose it to experience object-oriented modeling and OOP in a real-world project and to get some experience in team working and team collaboration with Git.



Deliverables


The complete source code.
Brief documentation of your project in .md(markdown). It should provide the following information (in brief):


Team name and list of team members (with http://telerikacademy.com usernames)
Project purpose – what problem do you solve and how?
Class diagram of your types
The URL of your Git repository
Any other information (optionally)


Obligatory upload your projects in the Showcase system (http://best.telerikacademy.com/)
Optionally provide a PowerPoint presentation designed for the project defense



Public Project Defense

Each team will have to deliver a public defense of its work in front of the trainers and give a short presentation in front of the other students. You will have around 30 minutes for the following:


Demonstrate the application
Show the class diagram
Show the source code in the Git web-based source code browser.
Show the commits logs to confirm that each team member has contributed.



Give Feedback about Your Teammates

You will be invited to provide feedback about all your teammates, their attitude to this project, their technical skills, their team working skills, their contribution to the project, etc. The feedback is important part of the project evaluation so take it seriously and be honest.


