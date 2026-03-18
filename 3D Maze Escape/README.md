# 3D Maze Escape

## Overview
A third-person 3D maze game developed in Unity. The objective is to navigate the maze, avoid traps, push a physics-based key to the exit door, and escape.

## In-game Screenshots
<img width="466" height="300" alt="img1" src="https://github.com/user-attachments/assets/9294a54e-09b5-480f-a449-6e46145ee38d" />
<img width="466" height="300" alt="img2" src="https://github.com/user-attachments/assets/97b5f182-8bbc-4841-bb97-f2011a7340a9" />

## Maze Map
<img width="600" height="300" alt="maze map" src="https://github.com/user-attachments/assets/36036758-906c-4ebc-8dd2-ec640e2652a8" />

## Assets Used
* **Third Person Character Controller** ([store link](https://assetstore.unity.com/packages/essentials/starter-assets-thirdperson-urp-196526)): Utilized for the player character and the patrolling guard models, and animations.
* **Environment Asset** ([store link](https://assetstore.unity.com/packages/3d/environments/dungeons/tileable-maze-and-dungeon-blocks-259878)): Utilized for the maze floor and wall prefabs.
<img width="200" height="180" alt="thirdperson" src="https://github.com/user-attachments/assets/83f3bb0d-e809-41cd-8de3-fb8c398d2ce6" />
<img width="200" height="180" alt="environment" src="https://github.com/user-attachments/assets/bc971ef8-c121-41f4-8c14-b55e8532644f" />

## Models Used
* **Knight D Pellegrini** ([Mixamo](https://www.mixamo.com)): A third-person character. It is configured to push standard Rigidbody objects.
* **Castle Guard** ([Mixamo](https://www.mixamo.com)): An AI entity that constantly patrols back and forth between two fixed points along a straight path.
<img width="151" height="300" alt="player" src="https://github.com/user-attachments/assets/970fc879-1859-4ff2-8334-625c0e4a34a4" />
<img width="151" height="300" alt="guard" src="https://github.com/user-attachments/assets/c17ef4bc-478a-475e-bc44-e675a16ad49a" />

## Game Objects
* **Key (Cube)**: A standard cube with a Rigidbody and gravity enabled. It is affected by physics and forces applied by the player character.
* **Door**: A specific wall segment blocking the exit path. It acts as a trigger for the end-game sequence.
* **Lasers**: Red cylinder obstacles that periodically blink on and off (2-second intervals). When active, they act as deadly triggers.

## Controls
* **W, A, S, D**: Move the player.
* **Shift**: Sprint.
* **Mouse**: Control camera direction.
* **M**: Toggle background music (Play/Pause).

## Conditions
* **Win Condition**: The player must physically push the Key (cube) through the maze until it collides with the Door. This collision triggers the "You Win" screen.
* **Lose Condition**: If the player's collider touches an active Laser or the patrolling Guard, the player dies instantly. This triggers the "Game Over" screen.
