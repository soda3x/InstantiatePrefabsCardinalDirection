# InstantiatePrefabsCardinalDirection

Simple script for instantiating Prefabs facing a cardinal direction

Supports 8-way cardinal directions (N, NW, W, SW, S, SE, E, NE)

## Some Assumptions

* Positive Z-axis values are heading North and Negative Z-axis values are heading South
* For rotation, Y = 0 is North, Y = 180 is South

For demonstration purposes, the `transform.position` of the spawned Prefab is randomised. A `SetTargetTransform` method is supplied for calling from outside the script to tell the script where to spawn the prefab and the demonstration code should be removed.

Follow the comments in the `InstantiatePrefab` script, its clearly shown what to remove.

!["Screenshot"](https://github.com/soda3x/InstantiatePrefabsCardinalDirection/blob/1c38eef8495a05e66080356378f5171d8c242454/screenshot.png)

## Licence

Just use it :)
