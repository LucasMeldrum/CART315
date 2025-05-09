# Process Journal
## Tiny Game | 01.23.25
Welcome to my design journal… I don’t really know what 
I’ll be writing here and how but I am writing this 
before creating my first tiny game on Jan 17th. I want 
to put a lot of effort into this class and come out 
with stuff I am happy with and learn lots and lots.

Okay so before actually making the game I have many 
thoughts and ideas. I haven’t looked at the engines yet 
however I want to make a fun quick game that is a 
little challenging platformer type game. Not really 
sure what I am going to do but going to jump right into 
it now.

Back now from making it that was lots of fun. I made 5 
levels that are “pretty difficult” and it’s just a 
simple start at one point get to the end point. I used 
a tool called PocketPlatformer and it was very good. I 
wanted to make a game that was challenging and quick. I 
was very confused at first then it started to flow and 
next I know I was making level after level. I tried to 
use most of the components in the tool (sprites, 
mechanics, etc.) because I thought it would be cool to 
use everything. I also added optional coins on each 
level because I like that aspect of most games its 
interesting to me since it isn’t mandatory and adds a 
challenge to every level.

Here is the game: [Tiny Game Project](../Projects/TinyPlatformer.html).

Here are the 
levels if you 
want to take a look before playing (they 
are pretty simple start at red get to green):


![Level 1](Media/Level%201.png) 

![Level 2](Media/Level%202.png)

![Level 3](Media/Level%203.png)

![Level 4](Media/Level%204.png)

![Level 5](Media/Level%205.png)

I had lots of fun doing this and kinda accomplished what I wanted to. I’m very excited to continue and use Unity and make something with more depth and on my own. The tool was very simple and easy to use and just allowed me to do the platformer I wanted.

After playtesting played some fun games and my favorite was the puzzle game by Ryan very simple and easy to pick up. Very good implementation. My game was a hit however it was just people trying to beat it because it was really difficult so it became a mini challenge for everyone.


## Explosion/Stacker Game | 01.29.25
Starting off I want to make a game where something gets 
stacked and the whole point is to stack a tower as high 
as possible. I keep thinking of a game where you're 
stacking burger toppings and condiments and trying to 
make the burger as tall as possible without making it 
tip over. So that's what I'll try. Lets go!

Okay so I changed my thought process completely. I was 
playing around with collisions and the physics behind 
Unity. So I found a way to make objects static and 
dynamic based on an inputs or collision. So what I did 
was made it so when the platform touches any of the 
balls they go static and get stuck to the platform. I then 
created a box around so if they went passed they get 
destroyed.

I then was wondering how to make it interesting so I 
looked up how to affect a force onto objects. I then 
attached that to the platform and add a key input so on 
space bar they would get affected. When I added this 
they would just become elongated and still don't move 
because they were still stuck to the platform.

To beat this I made it no longer "stick" but just freeze 
on spot. Basically just removed the collision box on 
them and just had it pause. However, the circles still 
bounce between each other which I liked. I also wanted it 
to be relaxing/look cool, so I changed the colors as they 
dropped by just randomizing which ones are selected in 
an array.

It's more of an experience and not a game, but I think it 
came out nicely where you just let the balls generate 
and then bounce them around. I added movement in the up 
and down direction so you can go freeze them and have 
control to where they bounce. Furthermore, I added a box 
that they collide off of.

So a proper explanation of what I did was:

1. Tried to make a game where objects stacked on each 
   other and goal is to make it as high as possible
2. Found a way to make the objects "stuck" when 
   collision occured
3. Instead of stacking objects, played around with a 
   "force" concept that is triggered with space bar
4. Added a box so all the circles would contain in the 
   play area and added WASD movement
5. Made it so any object touched by the platform gets 
   frozen then can be re-animated by the "force" 
   mechanic which causes a fun experience (I think). 

Here is what it looks like:

![Example](Media/ExplodeGame.png)

Here is the game: [ExplodeGame](../Projects/StackerGame)

Overall this was a fun experience and I had a great time 
figuring out what I could accomplish and make something 
fun. I'm glad I got to play around with collisions, the 
physics engine, and static/dynamic sprites. My thoughts 
if I had more time to continue this game would be to add 
a little "cup" that would collect the balls and score 
points if the player landed the balls inside. Would be 
cool if we could expand on these games!

I want to try EzGif for the games !reminder!

## PowerPong | 02.06.25

Note add power-ups so that it would be cool and GIFs

Okay coming out of class with no real idea of what I 
want to do. I think I want to put power-ups in the game 
that have different triggers. I want to make a solid 
three of them and make them generate randomly and be 
collected by the paddle not the ball since I do not know 
how to assign who would get it.

So main three power-ups:
1. Freeze: Freeze the opponent paddle. ~3s
2. BigPaddle: Turn your own paddle big so that it covers 
   more space. ~10s
3. FastBall: Increase the speed of the ball. ~3s

To implement these sounds I think I'll have to create 
three sprites set them as prefabs and generate them 
around the Scene so that OnColission they will trigger 
whatever they need to trigger. That's my thought process 
just create them and spawn them arround and once the 
paddle comes into contact... bam trigger whatever I want 
to accomplish. I am going to go test and I'll come back 
and write out what happened.

Okay! Done. I got to complete the game in one shot and 
it was not too bad at all. I'll go through each power-up 
and showcase what they do and how I managed to implement 
them.
#### 1. Freeze Power-up
For the freeze power-up I had some difficulty freezing 
the opponents paddle (not the one acquiring it). So what 
I did to get around this was to check which paddle (left 
or right) was coming into contact with the object then I 
changed the speed in the "opponent's" script to 0. I 
also had to store the paddle speed prior to this to set 
it back after the timer of 3 seconds was done.
<br>![Freeze](Media/Freeze.gif)
#### 2. BigPaddle Power-up
So I started by saving the original size before the 
power-up triggers so I could revert back once the it 
ended. Then what I pretty much did was increase the 
scale (in the y axis) by 1 whenever the paddle came into 
contact with it. Then after 10 seconds it reverts back 
to the original scale. Pretty simple and easy since it 
just affects the paddle that is touching the power-up.
<br>![BigPaddle](Media/BigPaddle.gif)
#### 3. FastBall Power-up
Fastball was the easiest of the three power-ups since 
all I really had to do was create a function on the ball 
script that increased the speed of the ball object and 
multiply it with the force. Also had to revert to the 
original speed and to do so I just divided it by the same 
amount applied.
<br>![FastBall](Media/Fastball.gif)

For all the power-ups I made them change the color of 
the paddles and gave them each their own color. 

Red = FastBall
<br>Blue = Freeze
<br>Green = BigPaddle

So thats pretty much it I got my power-ups added and 
they work pretty seamlessly. Generating them was pretty 
easy. I decided to put specific spawn areas for them in 
the corners and set it so it would random pick one of 
the spawn areas. 

## SomeBrickBreakerGame | 02.13.25

Up until now I haven't really played with sprites, 
animations or any visual aspects of the game at all. I 
think this time I am going to try and focus on doing 
that. So a menu screen, animation for the bricks 
breaking, sprite for the ball and paddle that look goofy 
maybe something more...

We'll see I don't have much time this week a lot going 
on but if I can learn a little about sprites that would 
be nice. I want to do sprites since all I've focused on 
until now is all game components and mechanics. Starting 
now.

Okay so I managed to add a function menu, some sprites 
to the ball and paddle, and an animation for the balls 
breaking. The animation part was a little tricky and had 
some road blocks and it came out a little wonky but it 
came out working so thats cool.

Here is the menu:
<br>![Menu](Media/MainMenu.gif)

Pretty simple just play and quit buttons but its 
functional and I did not know how to do this prior. I 
had to create buttons and background which was new. I 
also learnt how to switch scenes based on index so you 
can randomly pick scenes (if you need that maybe I'll 
try it in a later project). The hover aspect over the 
buttons is cool too and I learnt about importing fonts 
as well even though I did not implement it.

Next the animation.

This is what I made using libresprite (thanks Sam):
<br>![Animation](Media/Animation.gif)

After making this animation I thought it would look like 
how it is in libresprite but for some reason it did not. 
In Unity, it removed all the white and when there were 
gaps (the transparent parts on later frames) everything 
just disappeared. I think Unity does not let an object 
have empty space. I'm not sure. But the white being gone 
kinda upset me. Whatever...

Adding the animation took some time but in the end I got 
there. I had to create a folder of 12+ sprites so that 
the animation lasted 12 frames long and then played each 
sprite/frame. It was also cool learning about the 
animation controller which allows you to switch and do 
different things. For example, the bricks by default are 
in an "Idle" state and then once the "Break" triggers 
(this is when the ball collides with the brick) it then 
enters the "Animation" state and plays the animation I 
set it to. Very sweet and I'll definitely be using this in 
the future for other games.

Here's how it turned out in Unity with the extra sprites 
for the ball and paddle:
<br>![Gameplay](Media/Gameplay_Animation.gif)

Not terrible not great. I learnt a lot about sprites, 
animations and scenes this week which was nice. Happy 
with what I did, a little annoyed about the animation 
part but overall proud that I accomplished what I wanted 
to in the end (with some minor mistakes).

## 3DGame | 02.20.25

I really did not want to continue doing the brickbreaker 
game I don't know why. I wanted to try something new 
this week entirely. Been thinking about the games I 
usually play and what I like and it is mainly 3D shooter 
games so maybe I'll start on that (just something simple)
. So I thought of a camera that follows the player, a 
camera hovering over the player (so third-person) and 
maybe a shootable gun would be cool. So lets begin!

#### Player Controls
So starting with the controls... I did not know there 
was a "new" version of Unity input controls. Interesting 
so I gave it a chance and almost had it working but just 
could not get it to function properly. I had it all 
implemented properly it just would not see my move 
function in my script sooo maybe at a later time I'll 
try and fix it. I went with the classic inputs = 
movement and got it to work pretty seemlessly with a 
sphere on a little platform I made. NICE.

#### Camera 
Getting the camera to attach to the player was actually 
a lot easier than I thought. It now follows the player 
and never goes to far away which is cool. I had to play 
around with the angles a bunch to make something that I 
liked and didn't look to choppy. But basically I just 
set it to always look at my "player" model and it 
follows it!

#### Gun/Bullets
So doing this was a little harder because I needed not 
only the gun and bullets but also where the bullets came 
out from. Following a tutorial I was able to get it done 
but at first it would shoot out from the inside of the 
character because I had set the "end" of the gun inside 
the player model. Once I had set it out I kept playing 
around with its position until it looked like the player 
was shooting it out from the front. And it follows the 
player around as well so it moves as the player moves. 
It shoots these little capsules that also have physics 
so they roll for awhile until they get destroyed after a 
certain amount of time it's really funny. They also 
bounce of objects and stuff and I want to try and make 
it launch things in the future. But for now I was proud 
with what I accomplished. 

Here's a little demo:
<br>![Gameplay](Media/3D_Test.gif)

So as you can see the camera follows the "player" 
(sphere) around forward, back, left, right. And when you 
click you shoot out these little pills that bounce 
around and just launch forward. A little janky but I'm 
happy with it and I definitely want to keep working on 
it and maybe have incoming enemies that you have to 
launch away or something like that. It was not that 
difficult implementing everything since it was all 
pretty simple concepts and used a lot of the same 
physics, prefab and movement ideas we learnt doing 2D 
games but I'm glad I got a little 3D game going.

## Extra Credit | 03.06.25

My game of choice for a deeper analysis is the valve game Left 4 Dead 2. As a classic multiplayer zombie shooter this game seems simple at first but gets more complicated as you look at the nuances and detail that was put in the game by the developers. There are countless examples of this in the game, but I will focus on a few key aspects in this analysis.

To begin with, the game is played in a team of 4 in coop or two teams of 4 in versus. It is played as a linear game where the “survivor” team must go from point A to B while facing off zombies. In versus mode the “infected” team must work together to stop the opposing survivor team from making it to the safe room. At all points of this game teamwork is a central aspect. Despite the name Left 4 Dead, rushing ahead or going solo will get you killed since special infected can grab/pin you down and the only way to escape is to be freed by a teammate.

Now although at a glance it seems like a simple game, the developers make the game constantly dynamic and changing so it never gets stale. They do this by implementing what they call “The Director”. This director is a game modifier that changes how the map plays out, where zombies spawn, what items are found, and how difficult the level is. To put it simply; the better you are doing the harder the game gets. This makes the game always different each time you play it. The zombies never come from the same area, the maps never feel the same and even players (including myself) who have played the game extensively, don’t feel like that it gets repetitive.

As I mentioned before, the main component of the game is the coop aspect. I love how it is a central part of the game. Without it you get overwhelmed very quickly and lose. Same with the “infected” team in the versus mode. If you don’t work as a team and coordinate attacks the survivors are going to run past without a scratch. It makes the game competitive and balanced since both teams get to play as survivors and infected in the same round to see who makes it the furthest.

Personally, I have more than a thousand hours in this game and have played it competitively against professionals and that is another aspect in which I enjoy. The mechanics: shooting, movement, teamplay, map knowledge, etc. are all down in an outstanding way and although this game is 16 years old it still outperforms many triple A games in its category.

I think the replayability and the coop aspect of the game are its strong suits and they are definitely things I want to borrow when making games in the future. Nowadays games get boring quick since they get repetitive and if I could I would want to create something that feels unique after each playthrough similarly to L4D2.

## Iterative Prototype Game | 03.06.25

Starting off with the in class activity to brainstorm game ideas:

TOWER DEFENCE BRAINSTORMING LIST

Towers, monsters
Defence, attack
Fence?
Gold, resources, managing people to work
defending the castle,
paths, pathing, walk, run, fly, dig?
Shooting, spells, summoning units
Necromancers, plants vs zombies, the disco guy
placing buildings
building types: magic, physical, unit summoning,
stick man tower defence
pvp tower defence where you summon units to fight each other
archers, miners, barbarians,
coop tower defence
BTD monkeys and balloons
pop
spell casting
I really like necromancy characters do this please
Back to towers: stone, wood, gold, materials
age games
Age of Empires so aging up
going from like cavemen -> renaissance -> modern idk
rogue like tower defence game?
how would that work
maybe your build phase is going through a dungeon in a certain amount of time making it back then having to build
if you don’t make it back like maze runner issue
you’re trapped really hard to survive
Maze?
maze tower defence game.
What are we defending?
A base
Castle?
defending organs
tower defence but its anatomy based
so fighting diseases with like red/white blood cells
gather water and sleep to build immune system lol
lowkey some good ideas here
maybe defending the hive
OH OH
I like the idea of reverse tower defence
so instead of defending you have to attack a “base” that either is generated or someone else built
Like PVZ when u play as the zombies is so cool

IDEAS
-	PVP tower defence where you summon units to fight against each other
-	Rogue like tower defence game
-	Zombie tower defence game where you are the zombies and have to beat premade base
-	Disease tower defence game
-	Hive game? Hive mind?
-	Necromancer summoning zombies to defend castle
-	Maze runner dungeon to gather resources then build eventually walls drop?

SPEED DATING
-	Make a room to defend treasure
-	Target/Archer game with phones one person is target one is bow

-	Using electricity and metal to shock things back to life
-	Western where you manipulate each other to either pulling the trigger too fast or playing with someone’s head
-	Cleaning a hedge maze for a king
-	Bee espionage “ESBEENAGE”
-	Gold horse amour

-	Stealth game to use loud sounds (turning on stuff) to mask what you’re doing
-	Begging game for smokes
-	SoundScape (city/buildings making sounds)
-	Using drugs as a resource to survive

CONSTRAINT
-	What if the game only took 1-2 minutes?

Okay so my goal here is to make a quick tower defence game (maybe even 1v1) where you are limited by time to 
gather resources to defend your base or attack the enemy base. Not sure how this will plan out but I will go with it.

I wasn't sure if I wanted the game to be 2D or 3D but I ended up going with 3D just to learn more and experiment with it. My goal was to get the 
character, grid and being able to place towers down. So just simple stuff where I could then build off of it and modify it how I wanted.

So using what I learnt from my previous 3D game I used the same player inputs and camera follow to make it. For the grid I used what I learnt during 
the brick 
breaker game and then modified it for 3D. For the tower placing I just made it so when spacebar is clicked a "Tower" appears where the player is 
but it has no interaction or anything quite yet. I am not sure where I want to go from here so before I commit to much to one idea I want to just 
think about my game and what I want to do...

Here is what it looks like so far:
<br>![Gameplay](Media/DemoGrid.gif)

Simple enough so far and it can go in a lot of directions. At the moment i am thinking of a game where you have to defend something on the grid so 
like a house and place blocks to delay/attack whatever is coming at you... Not sure right now but i'm happy with this start!

## Tower Defence #2 | 03.13.25

This is the continuation of the Iterative Game Prototype from last week. Before starting I want to focus on the actual prototyping process instead 
of just implementing and testing around. So I will establish a problem, solution and the risks that come with it.

Problem: Come up with a new kind of tower defence game.

Solution: Fast paced, simple, tower stacking/building defence game.

Risks: 
<br>How are the towers going to stack? 
<br>How will it be fast paced?
<br>How will the camera and player interact with different levels in 3D?

So initially with these intentions I wanted to make the towers stack and also add a camera switch for top down view. What I came up with is towers 
that stack on top of each other to a max of 5 (with limited towers per level). I also added to my camera from last week to add a top down view. 

Here is what it looked like:
<br>![TowerPlace+Camera](Media/TowerPlace.gif)

By clicking Q or E you can switch between angled view and top down view to view your towers. I also allowed the towers to stack and implemented 
their attacks as well (will be shown later). I want the tower defense to be unique by stacking different types of towers to defend. Next I needed 
to implement the enemies moving/pathing between red and green, the towers shooting and all the main components of the tower defence game before I 
continue with my problem statement.

Done in class I added the pathing for the enemies. After that I was able to add the shooting from the towers (similar to my 3D game done 
previously in class). Easy to implement.

Here is what it looks like:
<br>![Enemy Move](Media/EnemyMove.gif)
<br>![TowerShooting](Media/TowerKill.gif)

So they will path around the towers and get shot at. I can also increase/decrease their speed and increase their health. They take 1 health when 
reaching the green from the player. I can change the 
damage, range, stack height, and speed of the towers as well. So room to modify/balance. I want to focus primarily on the towers aspect of the 
game and how that can be the central component so the game is unique. 

My goal now that the tower defence components are implemented is to focus on my problem and solution and keep adding to that main aspect of the 
game. I am definitely happy with what I have now however. Great week!

## Tower Defence #3 | 03.13.25

Okay starting this week I kinda felt stuck. I feel like I never polished out how my game was going to be fast-paced and what the final product 
might look like. So for this week I want to go backwards a little. I have a lot of ideas I just want to write them out and confirm what my final 
game could look like and how all the pieces will fall together. 

Thinking about time... Speed... Fast-Paced. Looking at a clock for each wave. A setup period that then leads to the wave period. I think I want to 
focus on extending the enemies time it takes to reach the green rather than killing them like most tower defence games. So what I am thinking is 
the towers won't do damage unless it is a tower on top of 4 other blocks. To distinct this I want the gradient of the blocks to increase as they 
go up and the top tower to be fully red. So no normal towers 1-4 will shoot the enemies and then the 5th one can. This will make the focus more 
centralized on delaying the enemy to the point rather than killing them.

Next. If the enemies don't die how do you win. Wave timer. Let's say a wave is 30 seconds long. And the goal of the wave is to delay the enemies 
for 30 seconds and you win. So instead of having to defeat the wave just delay them. I like this idea since its unique and gives the player a rush 
idea. Another aspect I want to implement is a setup/collecting phase before the wave begins where the player has to collect resources and place 
towers in this time. To place the towers it would require lets say 1 resource (whatever that might be) and they will be scattered around the map. 
To make it also on theme of this rush mechanic there will also be a countdown going. 

The game 60 seconds is what I am thinking of. In that game the player must gather items for their bunker and they have 60 seconds before a nuke is 
dropped and they die. If they do not make it within the 60 seconds / dont gather enough resources they will either lose on the spot or won't 
survive long due to the lack or resources. I want the same concept here. The player will have to manage the collecting time of their resources as 
well as the placement time before the wave starts. If they want more towers they can spend more time collecting resources however they'll have 
less time to think about placement and delaying the enemy ti win.

I like these ideas and it gives me an end goal for the game. So thats cool however I do not have much time this week to implement these ideas. 
Will have to be during class time and the next week but I am happy with more of an ending of where this game will go so that makes me happy. I 
also have so many ideas about sound and making the player feel STRESSED when playing by using sound to make the game become more and more intense 
but I don't want to bore whoever is reading this with an essay right now so I will hopefully get the sound ideas out in a later week!

Also heres what the tower looks with the color: 
<br>![TowerColor](Media/TowerColor.png)

Okay 1-1 notes:

Game starts.
Resource gather phase.
Build phase.
Wave starts + resource gather phase starts while wave is going.
Build phase.
Wave starts + resource gather phase starts while wave is going.
Etc.

Player never is doing nothing.
Sound while timer is going
Fast-Paced

## Tower Defence #4 | 03.27.25

This week I implemented bunch of features nearing the final game. It is coming along nicely. Things I implemented this week:
1. Resources
2. Resource & Build Phase
3. Enemy Phase
4. UI for time/towers/health

#### Resources
Initially the resources just spanwed every second or so and in the grid itself. I made a prefab and made it so when in contact with the player, 
the player would receive 2 more max towers that they could place. I then spawned the resources above the ground but it honestly looked better 
stuck in the ground since it became a half circle so I kept it. Not much more to say here other than after the resrouce/build phase ends all of 
the ones on the grid disappear from the map. 

<br>![Resource](Media/Resource.png)

#### Resource & Build Phase
This took most of my time this week. Getting the player collecting and building in one phase and then not being able to do either in the next. I 
also wanted a timer associated with that and since I have never really worked with Unity's time I had to get accustomed to it. Also was having 
many issues spawning the grid and having the resources spawn at the same time so had to fix that as well. Overall got it completed but took me 
some time. For now players have 60s to collect resources and build starting with 25 towers (+2 / resource as well).

#### Enemy Phase
Creating this phase was pretty simple after learning how to do it in the resource & build phase. I used the same concept as the other phase just 
gave the enemies less time to reach the "target point" (currently at 15s). I imagine this number could start higher for early waves and decrease 
as the wave numbers increase. Also for now the player has 10 health and only 5 enemies spawn for each wave but I will have to figure out a 
solution to balancing the game once it is polished and tested.

#### UI for time/towers/health
Finally since I had all these mechanics of health, # of towers, and especially the time mechanic for each phase I thought it was a good time to 
implement just a simple UI to track these values especially for testing purposes. Was pretty simple to do but took some time understanding how to 
have UI elements that were associated with variables.

<br>![UI](Media/UI.png)

I am pretty happy where things are at right now. For my final week I want to add a proper game loop (so wave after wave until you lose), a menu, 
sound for the phases, instructions for the game and sprties if I can get there. Just want to polish it off and make it playable. Oh and a LOSE 
screen. I want to make it one of those games where you see the highest wave you can get to is. It will become more difficult with time since 
you'll have less time to survive during the enemy phase and as time goes on you're towers will start dying.

## Tower Defence #5 | 04.03.25

Big changes this week. Realized it was not the final week and decided to make the game work properly and fix everything, add a proper game loop 
and a goal. So fixed all the phases, timers and winning/losing. Also spent a lot of time fixing an issue where players can just block off the 
target point so that the enemies could never reach it. ALSO, added a main menu, and a lose screen so that the game is fully playable. Goal is to 
just reach the highest wave at the moment. Last week definitely going to focus on just polishing stuff and adding those sound effects I was 
talking about.

Not much to note but here are the changes done this week (UI):

#### Main Menu
Simple main menu with start, controls, how to play and quit:
<br>![MainMenu](Media/MainMenu.png)
<br>![MainMenu](Media/HowToPlay.png)
<br>![MainMenu](Media/Controls.png)

GameOver screen when the player reaches 0 life left.
<br>![GameOver](Media/GameOver.png)

Although it seems like not much was done, the game is done. It loops perfectly and has no issues when playing. The waves and phases start and end 
appropriately and it gets more difficult as time goes on. For now I commented out all the code for collapsing the towers at the end of each wave 
since it is actually a lot harder to implement than I originally thought due to the way I have towers set up at the moment. However if I have time 
for it I'll try to implement it for the final version.

For now next week will just be polishing, adding sounds and sprites and just finalizing the game!

## Tower Defence FINAL #6 | 04.06.25

Final Week! GAME IS DONE. A bunch was added this week. Music for the waves, sprites for the enemies, towers, and player (although they look goofy 
first time really trying this). Text overlay and just simplification of the game. First time doing most of these and did not really have much time 
but it looks finished and I am very happy with what I've accomplished. More details on this project and my thought process and how the prototyping 
went after this weeks showcase. Also might update more of the game next week but only if I have time since finals are now.

So this week heres what I added. I started originally with some text overlay showing which phase you are on for the first 2s of that phase and 
added new fonts/color to the text on the screen to spice it up a little. It was pretty simple to implement for the overlay just had to set it to 
active / not active when the phases change. I also added a black background to the game just to make the text clearer and the board space obvious. 
I then added music for the build phase and music during the wave phase (heartbeat). They faze in and out and the heartbeat speeds up according to 
the duration of the wave which is super cool. I am not sure how to show music/sound on github so. you'll have to take a look yourself.

Next I added sprites to the towers, player and enemy. They are a little goofy and definitely was just playing around with them but I'm glad I got 
to learn and experience them. I will link where I got the sprites from below at the end of the document. Here are the two final phases:

<br>![BuildPhase](Media/BuildPhase.png)

<br>![WavePhase](Media/WavePhase.png)

The player is the slime (green) and the enemies are the UFO (black) the towers still change and turn red as they increase. I like how everything 
looks and the simple aspect of the game. I also think the sprites are a little too much and keeping it simple makes it look better so maybe just 
changing the model a little. For now I will leave it in how it is since it shows my progression but might change it later to better fit my 
finalized version. 

Anyways thats the game! It works, its playable, but its heavily unbalanced. I always have a difficult time balancing games since I overestimate 
what players do / how they think. I've been playin boardgames and video games since I was like 4 years old so I have become accustomed to beating 
games and finding the most optimized playstyles. For this game it is very easy if you know what you are doing. If not it is complicated and takes 
time to learn/master so I will leave it as is.

This experience was amazing and I am so glad to see the progression of my game in this way. I love where it started and re-iterating after each 
week to improve on my prototype was fun. I am glad I started with an idea and was able to actually accomplish something that is playable and 
(somewhat) fun. I think the idea is there but if I could redo it maybe switch how to game works and make it very very focused on the timer and 
optimization. Maybe remove the grid idk. But overall I feel accomplished and satisfied with what I created. Honestly wish I could just focus on 
creating a game and didn't feel rushed do to school, work and life. But I guess that is how it always is. This was a wonderful experience and I am 
glad I got to execute it fully so thank you and thanks for whoever followed along this journey.

Link to the final game: [Rush Defence](CART315/RushDefence.app)

Sprites, Fonts and Sounds Used - Links

Player Model:
<br>https://www.cgtrader.com/items/4784201/download-page

WavePhase + BuildPhase Music/Sound:
<br>https://pixabay.com/sound-effects/search/chill%20game%20music/

Text Font:
<br>https://www.1001fonts.com/search.html?search=EPIC

Towers/Enemy Models;
<br>https://kenney.nl/assets/category:3D?sort=update
