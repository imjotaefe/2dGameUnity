using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_controller : MonoBehaviour
{
    void Start()
    {
        
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
