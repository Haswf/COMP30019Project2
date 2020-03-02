

## COMP30019 S2 Project2

#### Description

A navel battle game made in Unity 3D.

*![image-20200228115411833](/Users/hanxiao/Desktop/image-20200228115411833.png)** 

#### Project specification

Our game is called “***Sinking the Bismarck***”, because of the warships which players and enemies
control are *Bismarck* from Germany in WWII. And this title’s meaning is either player wins or
the AI wins, *Bismarck* will sink at end.

#### Technologies

Unity 3D (2019.1.8f1)  +  C#

#### Motivation

1. Unity 3D is an awesome engine to make immersive and realistic game. We want to make full use of Unity features provided. 
2. Nowadays, war games is getting more and more popular, since this kind of games can make people feel simulating and excited. So we finally decided to develop a shipping game that can provide players to drive the boat, shoot enemies and win the war. 
3. In our mind, creating a simulation game with Unity 3D is very meaningful, since the game will bring players an excellent game experience. The whole environment ,including the waves, sky and fog will make players feel like they are travelling the real ocean and experiencing a real war. Moreover, the details of the battleship models can also impress the players. 

In summary, we believe that developing a 3D battleship game can attract lots of people, and the visual effect of the game with Unity Engine will be very satisfactory. 

#### User Interface

##### Main Menu

This is our main menu, which will be presented to the player when they enter the game and
return from previous combat.

![image-20200228115815658](/Users/hanxiao/Desktop/image-20200228115815658.png)

PLAY button: for starting to play the game.
TUTORIAL button: this button leads players into the tutorial scene for learning how to play.
QUIT button:this button is obvious, which is closing the game.
OPTIONS button: this button leads players into the setting, which will be discussed in detail in
the next part.

##### Map Selection

In the Select Map interface, players can choose the daytime or twilight period. And they can set
number of the islands which they want to generate in the world.

![image-20200228120006601](/Users/hanxiao/Desktop/image-20200228120006601.png)



##### Battle Scene

In the battle scene, the speed and health of the warship will be displayed on the lower left corner
of the screen. And the experience of the player will also be shown under the speed. The compass
in the middle of the bottom is to show which direction the player is heading to, it will rotate itself
to the right direction.

![image-20200228120025895](/Users/hanxiao/Desktop/image-20200228120025895.png)



##### GameOver scene

![image-20200228120238005](/Users/hanxiao/Desktop/image-20200228120238005.png)

And when players game over, they could use their skill points which they gain from leveling-up
their warship. And if players gain enough skill points, they could press these three buttons to be
stronger for different attributes of the warship. And the Restart button’s function is leading
players go back to the battlefield.

#### 

#### Feedback 

As a complement to Cooperative evaluation, we invite users to fill a post-study questionnaire. We adapted Questionnaire for User Interaction Satisfaction(QUIS) developed by researchers in the Human-Computer Interaction Lab (HCIL) at the University of Maryland to create a comprehensive questionnaire for the game. This questionnaire aims at collecting feedback about gameplay, user interface, learning and usability. 

![image-20200228120608357](/Users/hanxiao/Desktop/image-20200228120608357.png)

![image-20200228120629868](/Users/hanxiao/Desktop/image-20200228120629868.png)

#### Run

1. Download or clone this repository.
2. Import `COMP30019Project2/Project2` directory into Unity Hub.
3. Open `Scenes/MainMenu.unity` in Unity Editor if it has been opened automatically.
4. Click Play. You should see the buttons. You can use tutorial to learn this game or run and play the game directly.

#### External Code and APIs **[All]**

Parabola of shell   https://www.youtube.com/watch?v=03GHtGyEHas

Crest   https://github.com/crest-ocean/crest

Buoyancy  https://www.youtube.com/watch?v=FtcdkfvrQv0

Shader   https://www.youtube.com/watch?v=nZZ6MDY3JOk;

fog shader https://youtu.be/0GVv5Qh48FU; https://pastebin.com/ytJ9039d

Boat Propulsion  https://www.habrador.com/tutorials/unity-boat-tutorial/6-propulsion/

Simple Heal https://assetstore.unity.com/packages/tools/gui/simple-health-bar-free-95420

#### Contributors

[Haswf](https://github.com/Haswf) (Shuyang Fan)

[hanx7](https://github.com/hanx7) (Xiao Han)

[tomtom99113](https://github.com/tomtom99113) (Shengzhao Yuan)

[839224346](https://github.com/hanx7/COMP30019Project2/commits?author=839224346) (Yi Wang)

