using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject dragonPrefab;

    private Transform mainCamera;

    public Vector2 spawnPos = new Vector2(0f, 7f);
    // Start is called before the first frame update

    void Awake()
    {
        mainCamera = Camera.main.transform;
    }

    void Start()
    {
        StartCoroutine(SpawnDragon());
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
