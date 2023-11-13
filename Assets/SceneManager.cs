using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("instruction");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
        //https://forum.unity.com/threads/animation-doesnt-play-after-loading-the-scene.1000402/
        //Animation doesn't play after loading the scene!
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
