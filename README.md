# InstantiatePrefabsCardinalDirection

Simple script for instantiating Prefabs facing a cardinal direction

Supports 8-way cardinal directions (N, NW, W, SW, S, SE, E, NE)

## Some Assumptions

* Positive Z-axis values are heading North and Negative Z-axis values are heading South
* For rotation, Y = 0 is North, Y = 180 is South

For demonstration purposes, the `transform.position` of the spawned Prefab is randomised. A `SetTargetTransform` method is supplied for calling from outside the script to tell the script where to spawn the prefab
Follow the comments in the `InstantiatePrefab` script, its clearly shown what to replace.

!["Screenshot"](https://github.com/soda3x/InstantiatePrefabsCardinalDirection/blob/74dcc2a8fb5e4c4584aa618a6007def099fbb92c/screenshot.png)

## Licence

Just use it :)
