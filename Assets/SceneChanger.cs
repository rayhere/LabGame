using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
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

    public void StartGame()
    {
        SceneManager.LoadScene("level1");
        //https://forum.unity.com/threads/animation-doesnt-play-after-loading-the-scene.1000402/
        //Animation doesn't play after loading the scene!
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        PersistentData.Instance.SetLevel(0);
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1;       
        //ScriptName sn = gameObject.GetComponent<ScriptName>()
        //ScriptName sn = gameObject.GetComponent<ScriptName>(PersistentData);

        //PersistentData.Instance.DestroyPersistentData();

        //https://forum.unity.com/threads/calling-function-from-other-scripts-c.57072/
        //myObject.GetComponent<MyScript>().MyFunction();
        //PersistentData.DestoryPersistentData; 
        //PersistentData.Instance.GetName();
    }

    public void HighScores()
    {
        SceneManager.LoadScene("highscores");
        Time.timeScale = 1;
    }
}
