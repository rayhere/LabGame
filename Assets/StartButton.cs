using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using TMPro;

public class StartButton : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        //this method for Start button in Main Menu
        string s = nameInput.text;
        Debug.Log("your name is: " + s);
        //store in persistent data
        PersistentData.Instance.SetName(s);
        PersistentData.Instance.SetLevel(1);
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("level1");
        Time.timeScale = 1;
    }
}
