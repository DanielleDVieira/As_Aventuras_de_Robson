using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    SavedGame saved;

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

    // Recebe o valor selecionado (FACIL ou DIFCIL) do dropdown do menu
    public void ChooseDifficulty(int value_dropdown)
    {   
        saved = SavedGame.Load();
        saved.difficulty = value_dropdown;

        // Salva a dificuldade escolhida pelo usuario no arquivo inter-cenas (JSON)
        saved.Save();
    }
}
