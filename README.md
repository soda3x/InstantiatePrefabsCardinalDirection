# InstantiatePrefabsCardinalDirection

Simple script for instantiating Prefabs facing a cardinal direction

Supports 8-way cardinal directions (N, NW, W, SW, S, SE, E, NE)

## Some Assumptions

* Positive Z-axis values are heading North and Negative Z-axis values are heading South
* For rotation, Y = 0 is North, Y = 180 is South

For demonstration purposes, the `transform.position` of the spawned Prefab is randomised. A `SetTargetTransform` method is supplied for calling from outside the script to tell the script where to spawn the prefab.

Follow the comments in the `InstantiatePrefab` script, its clearly shown what to replace.

!["Screenshot"](https://github.com/soda3x/InstantiatePrefabsCardinalDirection/blob/59f4cca10d1358ad09a2a6a60872590e3d09ece5/screenshot.png)

## Licence

Just use it :)
