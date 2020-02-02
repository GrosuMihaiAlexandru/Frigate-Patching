using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameSpeed;
    public float startingSpeed = 1.5f;

    public int coins;

    public int collectedCoins;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        collectedCoins = 0;
        StopCoroutine(IncreaseGameSpeed());
        gameSpeed = startingSpeed;
        StartCoroutine(IncreaseGameSpeed());
        Dragon.nextDragonSpeed = 2;
        Dragon.nextDragonFireBall = 2;
        Dragon.nextDragonHealth = 100;
    }

    public void GiveCoins(int value)
    {
        coins += value;
    }

    public void RemoveCoins(int value)
    {
        if (value > coins)
            coins = 0;
        else
            coins -= value;
    }

    public void CollectCoins(int value)
    {
        collectedCoins += value;
    }

    private IEnumerator IncreaseGameSpeed()
    {
        while(gameSpeed < 5f)
        {
            yield return new WaitForSeconds(5f);
            gameSpeed += 0.1f;
            
        }
    }
}
