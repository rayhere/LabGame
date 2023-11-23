using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsFunctions : MonoBehaviour
{
    [SerializeField] GameObject[] settingMenu;
    [SerializeField] GameObject[] mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        settingMenu = GameObject.FindGameObjectsWithTag("ShowInSettingMenu");
        mainMenu = GameObject.FindGameObjectsWithTag("ShowInMainMenu");

        MainMenuMode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        //Time.timeScale = 1.0f;
        MainMenuMode();
    }

    public void GoToSettingMenu()
    {
        //Time.timeScale = 0.0f;
        SettingMenuMode();
    }

    void SettingMenuMode()
    {
        foreach (GameObject go in settingMenu)
            go.SetActive(true);

        foreach (GameObject go in mainMenu)
            go.SetActive(false);
    }

    void MainMenuMode()
    {
        foreach (GameObject go in settingMenu)
            go.SetActive(false);

        foreach (GameObject go in mainMenu)
            go.SetActive(true);
    }
}
