using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NewGame()
    {
        if (File.Exists(Application.persistentDataPath + "/Saved.json"))
        {
            File.Delete(Application.persistentDataPath + "/Saved.json");
        }

        loadScene("Fase");
    }

    public void Continue()
    {
        loadScene("Fase");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
