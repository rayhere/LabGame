using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveHighScores : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    const string NAME_KEY = "TopScoreName";
    const string SCORE_KEY = "TopScore";
    const int NUM_HIGH_SCORES = 5;

    [SerializeField] TMP_Text[] nameTexts;
    [SerializeField] TMP_Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();

        //playerScore = playerScore + Random.Range(11,21);

        SaveScore();
        ViewScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveScore()
    {
        for (int i = 1; i <=  NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;


            //first check if there is a high scoring player
            //PlayerPrefs store 3 type of data (Float, Int, String)
            //1st try to see if TopScore1 has key
            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                //if TopScore1 has key
                //, compare the value of key currentScore (TopScore + i)
                //, with playerScore

                /* in middle */
                //then check if player's score is greater than existing high score
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);


                if (playerScore > currentScore)
                {
                    //swap all the key to next level, start from this level
                    swap(i);

                    //set current value to current key
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);
                    PlayerPrefs.SetString(currentNameKey, playerName);

                    return;
                }
                
            }
            //if 1st try TopScore1 is null, set value to current Key TopScore1
            else
            {
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                PlayerPrefs.SetString(currentNameKey, playerName);
                return;
            }
        }

    }

    void swap(int j)
    {
        //checked it HasKey
        string currentNameKey = NAME_KEY + j;
        string currentScoreKey = SCORE_KEY + j;

        //save the value of the current key
        string currentName = PlayerPrefs.GetString(currentNameKey);
        int currentScore = PlayerPrefs.GetInt(currentScoreKey);

        //if need to do next value of Key
        for (int i = j+1; i <=  NUM_HIGH_SCORES; i++)
        {
            //i is next Key
            string nextNameKey = NAME_KEY + i;
            string nextScoreKey = SCORE_KEY + i;

            //1. save value of next key i 
            string tempName = PlayerPrefs.GetString(nextNameKey);
            int tempScore = PlayerPrefs.GetInt(nextScoreKey);
            
            //2. make currentKey to next key i
            currentNameKey = NAME_KEY + i;
            currentScoreKey = SCORE_KEY + i;

            //3. set value of current Key to next Key
            PlayerPrefs.SetString(currentNameKey, currentName);
            PlayerPrefs.SetInt(currentScoreKey, currentScore);

            //4. replace currentName with temp value from Step 1
            currentName = tempName;
            currentScore = tempScore;
        }
    }

    public void ViewScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].SetText(PlayerPrefs.GetString(NAME_KEY+(i+1)));
            scoreTexts[i].SetText(PlayerPrefs.GetInt(SCORE_KEY+(i+1)).ToString());
        }

    }
}
