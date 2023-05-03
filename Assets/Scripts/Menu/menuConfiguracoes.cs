using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuConfiguracoes : MonoBehaviour
{
    public GameObject menuConfig;
    public GameObject menuPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMenuConfig() {
        menuConfig.SetActive(false);
        if (menuPause) {
            menuPause.SetActive(true);
        }
    }

    public void OpenMenuConfig() {
        if (menuPause) {
            menuPause.SetActive(false);
        }
        menuConfig.SetActive(true);
    }
}
