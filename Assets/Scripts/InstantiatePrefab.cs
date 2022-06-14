using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// InstantiatePrefab will:
// * Spawn a random prefab from a list of selected prefabs,
// * The spawn rate will be random between a min and max value,
// * The direction in which the prefab is facing can be selected and changed
// * If enabled, the spawned prefabs will de-spawn after x seconds after they are created
//
// * It is import to note that this script is written with the assumption 
// * that +Z values are heading north and -Z values are heading south
// * and Y = 0 = NORTH, therefore Y = 180 = SOUTH
//
public class InstantiatePrefab : MonoBehaviour
{

    public List<GameObject> prefabs;
    public double minSpawnRateSeconds;
    public double maxSpawnRateSeconds;
    public double initialDelaySeconds;
    private bool delayFinished;
    public Direction direction;
    private System.Random random;
    private Transform targetTransform;
    private float lastSeconds;
    public bool deleteSpawnedPrefabs;
    public int deleteDelaySeconds;
    private Dictionary<GameObject, System.DateTime> spawnedPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        spawnedPrefabs = new Dictionary<GameObject, System.DateTime>();

        // This will set the initial target transform to the parent object's transform
        // This is only done so that targetTransform is never null

        // The real transform should be set by calling SetTargetTransform
        // Just for example purposes, this script will set the transform to be somewhere
        // around the parents but random so theres some variation
        targetTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Allow for initial delay
        if (Time.time >= initialDelaySeconds)
        {
            if (Time.time - lastSeconds >= GetRandomValueBetweenRange(minSpawnRateSeconds, maxSpawnRateSeconds))
            {
                lastSeconds = Time.time;
                GameObject go = GetRandomPrefab();
                // Replace with a call to SetTargetTransform
                Vector3 newPosition = new Vector3();
                newPosition.x = (float)GetRandomValueBetweenRange(0.1, 5);
                newPosition.y = (float)GetRandomValueBetweenRange(0.2, 3);
                newPosition.z = (float)GetRandomValueBetweenRange(0.3, 5);
                // End Replace
                spawnedPrefabs.Add(GameObject.Instantiate(go, newPosition, GetDirectionAsQuaternion(direction)), System.DateTime.Now);
                Debug.Log("Spawned a " + go.name + " at position: " + newPosition + " facing: " + direction);
            }

            // Delete the spawned prefabs 'deleteDelaySeconds' seconds after they are spawned
            if (deleteSpawnedPrefabs)
            {
                foreach (KeyValuePair<GameObject, System.DateTime> pair in spawnedPrefabs)
                {
                    // Skip any destroyed prefabs, these will be null references now
                    if (pair.Key != null)
                    {
                        // If the creation time + the delete delay is either now or in the past, destroy the prefab
                        if (System.DateTime.Now >= pair.Value.Add(new System.TimeSpan(0, 0, deleteDelaySeconds)))
                        {
                            Debug.Log("Destroyed prefab " + pair.Key.name);
                            Destroy(pair.Key);
                        }
                    }
                }
            }
        }
    }

    // Generate a random value between the specified range
    double GetRandomValueBetweenRange(double min, double max)
    {
        return random.NextDouble() * (max - min) + min;
    }

    // Get a random prefab from the prefabs list to be spawned
    GameObject GetRandomPrefab()
    {
        // random.Next will return a value between 0 and the last index of the prefabs.Count 
        // (of which is non-inclusive, so any value between 0 and prefabs.Count - 1)
        return prefabs[random.Next(prefabs.Count)];
    }

    // Set the spawn position of the GameObject
    public void SetTargetTransform(Transform t)
    {
        targetTransform = t;
    }

    // Return a Quaternion representation of the selected cardinal direction
    Quaternion GetDirectionAsQuaternion(Direction d)
    {
        switch (d)
        {
            case Direction.NORTH:
                return Quaternion.Euler(0, 0, 0);
            case Direction.NORTH_EAST:
                return Quaternion.Euler(0, 45, 0);
            case Direction.EAST:
                return Quaternion.Euler(0, 90, 0);
            case Direction.SOUTH_EAST:
                return Quaternion.Euler(0, 135, 0);
            case Direction.SOUTH:
                return Quaternion.Euler(0, 180, 0);
            case Direction.SOUTH_WEST:
                return Quaternion.Euler(0, 225, 0);
            case Direction.WEST:
                return Quaternion.Euler(0, 270, 0);
            case Direction.NORTH_WEST:
                return Quaternion.Euler(0, 315, 0);

            default:
                // Should never reach here
                return Quaternion.Euler(0, 0, 0);
        }
    }
}
