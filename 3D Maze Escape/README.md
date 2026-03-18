# 3D Maze Escape

## Overview
A third-person 3D maze game developed in Unity. The objective is to navigate the maze, avoid traps, push a physics-based key to the exit door, and escape.

## Controls
* **W, A, S, D**: Move the player.
* **Shift**: Sprint.
* **Mouse**: Control camera direction.
* **M**: Toggle background music (Play/Pause).

## Game Objects & Mechanics
* **Player**: A third-person character controller. It acts as the user's avatar and is configured to push standard Rigidbody objects.
* **Key (Cube)**: A standard cube with a Rigidbody and gravity enabled. It is affected by physics and forces applied by the player character.
* **Door**: A specific wall segment blocking the exit path. It acts as a trigger for the end-game sequence.
* **Lasers**: Red cylinder obstacles that periodically blink on and off (2-second intervals). When active, they act as deadly triggers.
* **Guard**: An AI entity that constantly patrols back and forth between two fixed points (Point A and Point B) along a straight path.

## Rules & Conditions
* **Win Condition**: The player must physically push the Key (cube) through the maze until it collides with the Door. This collision opens the exit, freezes the game state, and triggers the "You Win" screen.
* **Lose Condition**: If the player's collider touches an active Laser or the patrolling Guard, the player dies instantly. This freezes the game state and triggers the "Game Over" screen.