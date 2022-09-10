using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadMap(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        //Debug.Log("AAAAAAAAAAAAAAAAA");
        Application.Quit();
    }
}
