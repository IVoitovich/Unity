using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour
{
    public void NewGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void EXIT()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}