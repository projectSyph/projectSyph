# projectSyph

### Description
projectSyph is an **open-source** turn-based game written in C# with support for 2 (1v1), 3 (everyone for themselves) or 4 (2v2) players and it is developed as the **first team project** for Telerik Academy Alpha.

### Story
Coming soon..

### Quick guide
When you start a **new game**, you have to enter your **username**, which will be used for the period of the game. There can be 2, 3 or 4 players. Each player starts with 8000 souls and the goal is to keep them for as long as you can.

You can have different **spawns**, each with their own **attack**, **health**, **armor**, **energy** and **souls**. Each creature requires 20 energy to attack. When its energy drops to **zero or below**, it loses 80% of its **current** health and **all** of its armor.

When your spawn attacks **three** things can happen:
- If its attack is **higher** than the opponent's, its attack is removed from the opponent's armor **first**, health **second** and player's souls **third**. If your spawn's oponent's health hits **zero**, it dies and your spawn takes its souls. If you attack another player you take **their** souls and add them to **your own**. 
    (**Example:** **Your** spawn has 350 attack and **its opponent** has 100 attack, 200 health and 100 armor, the opponent loses 100 armor and 200 health, and the player who owns it loses 50 souls, which are added to your souls).

- If your spawn's attack is equal to its opponent's, **both die**.

- If its attack is **lower** than the opponent's, it is the same logic as the first, only reversed.

The game ends when there is **only one player** (for 2 or 3 players) or **one team** (for 4 players) left standing.