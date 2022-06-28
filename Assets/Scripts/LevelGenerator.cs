using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_DISTANCE = 50f;

    [SerializeField] private Transform startingPlatform;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform player;

    public int startingPlatforms = 5;

    private Vector3 lastSpawnedPosition;

    private void Awake()
    {
        lastSpawnedPosition = startingPlatform.position;

        for (int i = 0; i < startingPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, lastSpawnedPosition) < PLAYER_DISTANCE_SPAWN_DISTANCE)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        lastSpawnedPosition = SpawnPlatform(lastSpawnedPosition);
    }

    private Vector3 SpawnPlatform(Vector3 spawnPosition)
    {
        var position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(2.0f, 5.0f), 0);


        Transform spawnedPlatform = Instantiate(platform, spawnPosition + position, Quaternion.identity);
        return spawnedPlatform.position;
    }
}
