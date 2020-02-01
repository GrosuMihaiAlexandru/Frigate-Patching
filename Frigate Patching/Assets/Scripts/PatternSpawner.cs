using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{
    private Transform mainCamera;

    public List<GameObject> prefabs;

    private Vector2 oldPosition;
    private Vector2 currentPosition;
    private Vector2 nextPosition;

    private int currentLevel = -1;

    [SerializeField]
    private float levelLength = 18f;

    private GameObject oldLevel;
    private GameObject thisLevel;
    private GameObject nextLevel;

    private bool canDestroyLevel;

    void Awake()
    {
        mainCamera = FindObjectOfType<Camera>().transform;

    }

    void Start()
    {
        currentPosition = new Vector2(10, 0);
        nextPosition = new Vector2(currentPosition.x + levelLength, currentPosition.y);

        thisLevel = Instantiate(prefabs[SelectRandomPrefab(prefabs.Count - 1)], currentPosition, Quaternion.identity);
        nextLevel = Instantiate(prefabs[SelectRandomPrefab(prefabs.Count - 1)], nextPosition, Quaternion.identity);
    }

    void Update()
    {
        if (mainCamera.position.x - currentPosition.x >= 0)
        {
            oldLevel = thisLevel;
            oldPosition = currentPosition;
            thisLevel = nextLevel;

            currentPosition = nextPosition;
            nextPosition = currentPosition + new Vector2(levelLength, 0);
            nextLevel = Instantiate(prefabs[SelectRandomPrefab(prefabs.Count - 1)], nextPosition, Quaternion.identity);

            canDestroyLevel = true;
        }
        Debug.Log(mainCamera.transform.position.x + " " + currentPosition.x);
        if (canDestroyLevel && mainCamera.transform.position.x - currentPosition.x >= -1f)
        {
            Destroy(oldLevel);
            canDestroyLevel = false;
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
