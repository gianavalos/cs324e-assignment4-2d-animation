# Assignment 4: 2D Animation



## Project Description



### Team Members



#### Gian Avalos UT EID: gfa298



#### Jinsoo Cho UT EID: jc94928



#### Blake Stanley UT EID: bks2356



* #### Gian: Project and Tiger class
* #### Jinsoo: Bird class
* #### Blake: Monkey class





### Implemented Functionalities

##### 

##### Each animal was composed of multiple sprite parts (PNG images)to enable individual limb movement. The Load Content section loads all textures involved, handling all instances. Update and Draw calls on each instance. All sprites have an origin point set, for which all respective sprite parts will follow at an even speed to coordinate the animation.

##### 

##### The root-level animation uses a Matrix passed into SpriteBatch.Begin. All sprite parts for each animal compose the second-level animation through rotation, position, and scale parameters.



##### Each sprite has its own similar counterpart but is differentiable through size, tint and velocity. The tiger class represents an animated tiger that moves from left to right across the screen composed of the body, legs, and tail. Each sprite part is drawn at a local offset relative to the root transform matrix. Leg rotation oscillates using a sine function connected to the walk speed, with the opposite legs animated to simulate a walk. 



##### The Monkey class animates a climbing monkey composed of five sprites: a body, two arms, and two legs. The root matrix uses Matrix.CreateScale and Matrix.CreateTranslation passed into SpriteBatch.Begin. The monkey climbs up and down the screen, reversing direction once it reaches the top and bottom bounds. A mirrored flag flips the sway and facing directions to differentiate the two instances, which also vary by tint, scale, and climbing speed.



##### The bird class creates the animation for a flying bird that flies from left to right across the screen. This animal contains three sprite parts: a body and two wings. The root matrix combines Matrix.CreateScale, Matrix.CreateRotationZ, and Matrix.CreateTranslation passed into SpriteBatch.Begin. A tilt and vertical bob are applied to the translation. The bird reverses path at the screen edges. Both wings flap using a sine function, while the body bobs and banks using synchronized sine and cosine functions. Both instances are differentiated by tint, scale, and fly speed.





### Extra Credit: Continuous sine/cosine-based motion



##### The tiger's leg and tail rotations use sine functions at different frequencies, giving each part its own independent rhythm.



##### The Monkey's arm rotation, leg rotation, and horizontal sway each use sine functions producing three simultaneous oscillations at their own pace.



##### The Bird's vertical bobbing uses sine while banking uses cosine at the same frequency, keeping both motions separate imitating flight.





### Challenges Faced



##### Correctly positioning the sprite parts relative to the origin was complicated. Offsets required careful repeated tuning to align limbs to their natural positions. The alternative limb movements for opposing sides were all challenging, this aspect was to build a realistic animation where both limbs do not move in equal directions simultaneously. For the monkey, the implementation of a mirrored system to differentiate sway direction and flip the sprite were tricky.



### Files Included

* #### A4\_2DAnimation/ - MonoGame project folder
* ##### Game1.cs - Main game logic
* ##### Content/Bird - Bird Sprite PNGs
* ##### Content/Tiger - Tiger Sprite PNGs
* ##### Content/Monkey - Monkey Sprite PNGs
* ##### README.txt - Project running instructions
* ##### assignment4\_description.txt - Project description





