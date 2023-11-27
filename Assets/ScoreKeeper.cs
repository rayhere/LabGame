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
    [SerializeField] TMP_Text elapsedTimeText;
    [SerializeField] TMP_Text remainingTimeText;

    [SerializeField] int level;
    [SerializeField] int scoreThresholdForThisLevel;

    public const int DEFAULT_POINTS = 1;
    //public const int SCORE_THRESHOLD = 10;
    public const int SCORE_THRESHOLD = 1;
    private bool loadNextScene = false;

    public float loadNextSceneTimer = .8f;
    public float ttime;
    private const float delay = .8f; // delay 0.8sec

    float elapsedTime;
    [SerializeField] float remainingTime;
    //public const float DEFAULT_remainingTime = 20;

    // Start is called before the first frame update
    void Start()
    {
        
        //level = SceneManager.GetActiveScene().buildIndex - 1;
        level = PersistentData.Instance.GetLevel();
        score = PersistentData.Instance.GetScore();
        remainingTime = PersistentData.Instance.GetRemainingTime();
        scoreThresholdForThisLevel = SCORE_THRESHOLD * level;
        DisplayName();
        DisplayScene();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (loadNextScene && loadNextSceneTimer < Time.time)
        {
            // function Update() 
            // {
            //     time = Time.timeSinceLevelLoad;
            // }
            PersistentData.Instance.SetLevel(level+1);
            loadNextScene = false;
            LoadNextScene();
            Debug.Log("loadNextScene is true and timer < Time.time");
        }


        // elapsedTime += Time.deltaTime;
        // int minutes = Mathf.FloorToInt(elapsedTime / 60);
        // int seconds = Mathf.FloorToInt(elapsedTime % 60);
        // elapsedTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        remainingTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        // if remainging Time is Zero, GameOver
        if (remainingTime <= 0)
        {
            //remainingTime = DEFAULT_remainingTime;
            SceneManager.LoadScene("highscores");
            Time.timeScale = 1;
        }

    }

    public void AddPoints(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);

        // reward
        float newRemaingingTime = remainingTime + GameMod.Modifier.GetBonusTime();
        PersistentData.Instance.SetRemainingTime(newRemaingingTime);
        
        DisplayScore();

        if(score >= scoreThresholdForThisLevel)
        {
            //SceneManager.LoadScene(level + 2); //level is already 1 less than the index (e.g. 1 instead of 2)
            //https://discussions.unity.com/t/unity-5-3-how-to-load-current-level/154601/4
            // int scene = SceneManager.GetActiveScene().buildIndex;
            // SceneManager.LoadScene(scene, LoadSceneMode.Single);
            // Time.timeScale = 1;

            loadNextSceneTimer = delay + Time.time;
            loadNextScene = true;
            Debug.Log("loadNextScene is true");
            Debug.Log("loadNextSceneTimer is "+loadNextSceneTimer);
            Debug.Log("Time.time is "+Time.time);
        }


    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

        //starttime - 

    }

    private void DisplayName()
    {
        nameText.SetText("Hi, " + PersistentData.Instance.GetName() + "!");
    }

    private void DisplayScene()
    {
        sceneText.SetText("Level: " + level);
    }

    private void DisplayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("level1");

        //int scene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
