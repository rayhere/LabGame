using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text sceneText;
    [SerializeField] TMP_Text scoreText;
    
    [SerializeField] int level;
    [SerializeField] int scoreThresholdForThisLevel;

    public const int DEFAULT_POINTS = 1;
    //public const int SCORE_THRESHOLD = 10;
    public const int SCORE_THRESHOLD = 1;
    private bool loadNextScene = false;

    public float timer = .8f;
    public float ttime;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex - 1;
        score = PersistentData.Instance.GetScore();
        scoreThresholdForThisLevel = SCORE_THRESHOLD * level;
        DisplayName();
        DisplayScene();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (loadNextScene && timer < Time.time)
        {
            LoadNextScene();
            Debug.Log("loadNextScene is true and timer < Time.time");
        }
        
    }

    public void AddPoints(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
        DisplayScore();

        if(score >= scoreThresholdForThisLevel)
        {
            //SceneManager.LoadScene(level + 2); //level is already 1 less than the index (e.g. 1 instead of 2)
            //https://discussions.unity.com/t/unity-5-3-how-to-load-current-level/154601/4
            // int scene = SceneManager.GetActiveScene().buildIndex;
            // SceneManager.LoadScene(scene, LoadSceneMode.Single);
            // Time.timeScale = 1;

            timer += Time.time;
            loadNextScene = true;
            Debug.Log("loadNextScene is true");
        }


    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

    }

    private void DisplayName()
    {
        nameText.SetText("Hi, " + PersistentData.Instance.GetName() + "!");
    }

    private void DisplayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    private void DisplayScene()
    {
        sceneText.SetText("Level: " + level);
    }

    private void LoadNextScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
