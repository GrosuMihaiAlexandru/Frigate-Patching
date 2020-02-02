using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject dragonPrefab;
    public GameObject pirateShipPrefab;

    private Transform mainCamera;

    public Vector2 spawnPos = new Vector2(0f, 7f);
    public Vector2 pirateSpawnPos = new Vector2(3f, 0f);
    // Start is called before the first frame update

    void Awake()
    {
        mainCamera = Camera.main.transform;
    }

    void Start()
    {
        StartCoroutine(SpawnDragon());
        StartCoroutine(SpawnPirateShip());
    }
    
    private IEnumerator SpawnPirateShip()
    {
        while (true)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            float waitTime = Random.Range(15, 30);
            yield return new WaitForSeconds(waitTime);

            int numberOfShips = Random.Range(1, 3);
            if (numberOfShips == 1)
            {
                float thisSpawnPos = Random.Range(-3.5f, 3.5f);
                Instantiate(pirateShipPrefab, new Vector2(mainCamera.position.x, mainCamera.position.y + thisSpawnPos) + pirateSpawnPos, Quaternion.identity);
            }
            else
            {
                float spawnOne = Random.Range(1f, 3.5f);
                float spawnTwo = Random.Range(-3.5f, -1);
                Instantiate(pirateShipPrefab, new Vector2(mainCamera.position.x, mainCamera.position.y + spawnOne) + pirateSpawnPos, Quaternion.identity);
                Instantiate(pirateShipPrefab, new Vector2(mainCamera.position.x, mainCamera.position.y + spawnTwo) + pirateSpawnPos, Quaternion.identity);
            }
        }
    }

    private IEnumerator SpawnDragon()
    {
        while (true)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            float waitTime = Random.Range(60, 180);
            yield return new WaitForSeconds(waitTime);
            Debug.Log(mainCamera.position);
            Instantiate(dragonPrefab, new Vector2(mainCamera.position.x, mainCamera.position.y) + spawnPos, Quaternion.identity);
        }
    }
}
