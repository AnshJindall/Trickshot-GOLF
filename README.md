# Trickshot GOLF! - Web3Task Game Developer Assignment

## Overview

This project was developed as part of the Web3Task Game Developer Intern technical assignment.

The objective was to create a responsive physics-based projectile game where the player launches a ball using drag input and successfully reaches the goal through different obstacle layouts.

Rather than creating only the minimum requirements, I expanded the mechanic into a small playable mini golf game featuring multiple handcrafted levels and polished feedback.

---

## Controls

### Mobile
- Touch and drag on the ball to aim.
- Release to launch.

### Desktop / WebGL
- Click and drag on the ball.
- Release to shoot.

---

## Gameplay

- Complete 5 handcrafted levels.
- Reach the hole before running out of lives.
- Each level starts with 5 lives.
- Falling into the kill zone costs one life and respawns the ball.
- The final level introduces a moving hole for additional difficulty.

---

## Implementation Approach

The project was built using Unity's 2D physics system.

The player drags from the ball to determine launch direction and force.

The drag distance is clamped to prevent excessive force, and the final velocity is applied directly to the Rigidbody2D.

Gameplay logic is separated into small scripts with individual responsibilities:

- BallController – Player input, aiming, launching and respawning.
- HoleTrigger – Win detection and level progression.
- GameManager – Lives system and level restart.
- KillZone – Detects failed shots.
- MovingHole – Controls the moving goal.
- AudioManager – Centralized audio playback.
- MenuManager – Menu navigation.

---

## Surface Interaction

Instead of scripting movement along surfaces, I relied on Unity's built-in Rigidbody2D physics and carefully designed colliders.

The gameplay is based on:

- Correct launch angle
- Appropriate launch force
- Natural collision response
- Controlled bouncing
- Momentum preservation

Different obstacle layouts encourage bank shots, pipe navigation and timing rather than scripted movement.

---

## Motion Feedback

Implemented feedback includes:

- Direction arrow while aiming
- Arrow scaling based on launch power
- Confetti particle effect on successful completion
- Sound effects for:
  - Launch
  - Losing a life
  - Completing a level
  - Victory
  - UI buttons
- Moving hole challenge on the final level

---

## Challenges Faced

Some challenges during development included:

- Designing drag controls that worked consistently on both desktop and mobile.
- Tuning launch force for predictable physics.
- Preventing multiple goal triggers.
- Implementing scene transitions while keeping the AudioManager persistent.
- Balancing difficulty across multiple levels.

---

## Improvements

Given more development time, I would like to implement:

- A trajectory preview system for more precise aiming.
- More unique and challenging level designs.
- A dedicated game over screen instead of immediately restarting the level.
- A level selection menu to replay completed stages.
- An in-game settings menu with audio volume controls.

---

## Built With

- Unity 6

---

## Author

Ansh Jindal