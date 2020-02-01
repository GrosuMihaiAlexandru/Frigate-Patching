using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public string scene; 
    //To quit the game
   public void ExitGame()
    {
        Application.Quit();
    }

    //To load the game
    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
