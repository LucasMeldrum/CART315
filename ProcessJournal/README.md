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
![Freeze](Media/Freeze.gif)
#### 2. BigPaddle Power-up
So I started by saving the original size before the 
power-up triggers so I could revert back once the it 
ended. Then what I pretty much did was increase the 
scale (in the y axis) by 1 whenever the paddle came into 
contact with it. Then after 10 seconds it reverts back 
to the original scale. Pretty simple and easy since it 
just affects the paddle that is touching the power-up.
![BigPaddle](Media/BigPaddle.gif)
#### 3. FastBall Power-up
Fastball was the easiest of the three power-ups since 
all I really had to do was create a function on the ball 
script that increased the speed of the ball object and 
multiply it with the force. Also had to revert to the 
original speed and to do so I just divided it by the same 
amount applied.
![FastBall](Media/Fastball.gif)

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

