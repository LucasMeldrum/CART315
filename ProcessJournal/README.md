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
make the burger as tall as possible. So that's what I'll 
try. Lets go!

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
attatched that to the platform and add a key input so on 
space bar they would get affected. When I added this 
they would just become elongated and still don't move 
because they are stuck to the platform.

To beat this I made it no longer "stick" but just freeze 
on spot. Basically just removed the collision box on 
them and just had it pause. However the circles still 
bounce between each other. I also wanted it to be 
relaxing/look cool so I changed the colors as they 
dropped by just randomizing which ones are selected in 
an array.

It's more of an experience and not a game but I think it 
came out nicely where you just let the balls generate 
and then bounce them arround. I added movement in the up 
and down direction so you can go freeze them and have 
control to where they bounce. Furthermore, I added a box 
that they collide off of.

Here is what it looks like:

![Example](Media/ExplodeGame.png)

Here is the game: [ExplodeGame](../Projects/StackerGame)

Overall this was a fun experience and I had a great time 
figuring out what I could accomplish and make something fun.
