using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScr : MonoBehaviour
{
    [SerializeField] GameObject[] menuMode;
    [SerializeField] GameObject[] playMode;
    [SerializeField] GameObject[] settingMode;
    [SerializeField] GameObject[] instructionMode;
    [SerializeField] GameObject[] highscoreMode;

    // Start is called before the first frame update
    void Start()
    {
        //find gameobject followed by tag in arraylist
        menuMode = GameObject.FindGameObjectsWithTag("ShowInMenuMode");
        playMode = GameObject.FindGameObjectsWithTag("ShowInPlayMode");
        settingMode = GameObject.FindGameObjectsWithTag("ShowInSettingMode");
        instructionMode = GameObject.FindGameObjectsWithTag("ShowInInstructionMode");
        highscoreMode = GameObject.FindGameObjectsWithTag("ShowInHighScoreMode");
        MenuMode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButton()
    {
        MenuMode();
    }

    public void PlayButton()
    {
        PlayMode();
    }
    
    public void SettingButton()
    {
        SettingMode();
    }

    public void InstructionButton()
    {
        InstructionMode();
    }

    public void HighScoreButton()
    {
        HighScoreMode();
    }

    public void MenuMode()
    {

        foreach (GameObject go in menuMode)
            go.SetActive(true);

        //foreach (GameObject go in playMode, settingMode, instructionMode)
        foreach (GameObject go in playMode)
            go.SetActive(false);
        foreach (GameObject go in settingMode)
            go.SetActive(false);
        foreach (GameObject go in instructionMode)
            go.SetActive(false);
        foreach (GameObject go in highscoreMode)
            go.SetActive(false);
    }

    public void PlayMode()
    {

        foreach (GameObject go in playMode)
            go.SetActive(true);

        //foreach (GameObject go in menuMode, settingMode, instructionMode)
        foreach (GameObject go in menuMode)
            go.SetActive(false);
        foreach (GameObject go in settingMode)
            go.SetActive(false);
        foreach (GameObject go in instructionMode)
            go.SetActive(false);
        foreach (GameObject go in highscoreMode)
            go.SetActive(false);
    }

    public void SettingMode()
    {

        foreach (GameObject go in settingMode)
            go.SetActive(true);

        //foreach (GameObject go in menuMode, playMode, instructionMode)
        foreach (GameObject go in menuMode)
            go.SetActive(false);
        foreach (GameObject go in playMode)
            go.SetActive(false);
        foreach (GameObject go in instructionMode)
            go.SetActive(false);
        foreach (GameObject go in highscoreMode)
            go.SetActive(false);
    }

    public void InstructionMode()
    {

        foreach (GameObject go in instructionMode)
            go.SetActive(true);

        //foreach (GameObject go in menuMode, playMode, settingMode)
        foreach (GameObject go in menuMode)
            go.SetActive(false);
        foreach (GameObject go in playMode)
            go.SetActive(false);
        foreach (GameObject go in settingMode)
            go.SetActive(false);
        foreach (GameObject go in highscoreMode)
            go.SetActive(false);
    }

    public void HighScoreMode()
    {

        foreach (GameObject go in highscoreMode)
            go.SetActive(true);

        //foreach (GameObject go in menuMode, playMode, settingMode)
        foreach (GameObject go in menuMode)
            go.SetActive(false);
        foreach (GameObject go in playMode)
            go.SetActive(false);
        foreach (GameObject go in settingMode)
            go.SetActive(false);
        foreach (GameObject go in instructionMode)
            go.SetActive(false);
    }
}
