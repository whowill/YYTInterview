Interview Question:
Crane Machine Sample Game
The goal of this test is to recreate an arcade claw game or UFO catcher using the Unity Engine.
Claw machine example videos:
  https://www.youtube.com/watch?v=_x5ldKCEq7o
  https://www.youtube.com/watch?v=IQqXccex9tU
The claw is at the top of the screen and the bottom of the screen has prize objects the player
can grab with the claw. The player wins if the claw grabs a prize object from the bottom of the
screen and the claw is holding one or more prize objects when it returns to the top of the screen

Controlling the Claw
  - Pressing up, down, left or right arrow keys on the keyboard changes the position of the
  claw.
  - Pressing the space button drops the open claw down towards the prize objects.
Claw States
  - Open State
  - This is the default claw state
  - The claw can respond to player input.
  - The claw remains in this state until it collides with a prize object
  - Closed State
  - The claw transitions from Open State to Closed State when it collides with a prize
    object or the bottom of the screen
  - Add an animation delay for the claw to close and grab an object
  - After the claw is fully closed transition into rising state
  - The claw does not respond to player input in this state
  - Rising State
  - The claw transitions from Closed State to Rising State after the claw fully closes.
  - The claw rises up to the top of the screen.
  - When the claw rises to the top of the screen transition back to Open State
  - The claw does not respond to player input in this state

Players press the up, down, left, and right arrow keys on the keyboard to move a claw

Bonus points
  - Use physics to manage the actions to give a sense of realistic gameplay.
  - Allow players to pick up one or more prize items depending on the size of prize items
  - Add input support for a controller or mouse
  - Add a reward screen and celebrate the player successfully winning an item
  - If you have additional ideas or development beyond the scope please explain them and
  let us know your thinking
