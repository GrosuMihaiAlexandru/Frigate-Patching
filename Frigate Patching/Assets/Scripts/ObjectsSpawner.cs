using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public Transform player;

    public List<GameObject> prefabs;

    public Vector2 spawnPos;
    public Vector2 nextSpawnPos;

    private int currentLevel = -1;

    [SerializeField]
    private float levelLength = 18f;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        spawnPos = new Vector2(18, 0);
        nextSpawnPos = new Vector2(spawnPos.x + levelLength, spawnPos.y);

        Instantiate(prefabs[SelectRandomPrefab(prefabs.Count - 1)], spawnPos, Quaternion.identity);
        Instantiate(prefabs[SelectRandomPrefab(prefabs.Count - 1)], nextSpawnPos, Quaternion.identity);
    }

    void Update()
    {
        if (player.position.x == 0)
        {

        }
    }

    public int SelectRandomPrefab(int maxLevel)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int r = Random.Range(0, maxLevel + 1);
        while (r == currentLevel)
        {
            r = Random.Range(0, maxLevel + 1);
        }
        currentLevel = r;
        return r;
    }
}
