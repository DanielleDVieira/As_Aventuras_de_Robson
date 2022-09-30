using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    private bool Paused;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
        }
    }

    public void Continue()
    {
        TogglePause();
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    private void TogglePause()
    {
        Paused = !Paused;
        Time.timeScale = Paused ? 0 : 1;
        Menu.SetActive(Paused);
    }
}
