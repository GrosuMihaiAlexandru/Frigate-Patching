using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookForGameManager : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        GameManager.Instance.StartGame();
    }
}
