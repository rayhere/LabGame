using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    public static PersistentData Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Debug.Log("PersistentData.sc Don't Destory On Load");
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroy(gameObject)");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // if (playerName == null)
        //     playerName = "unknown";
        if (playerScore <= 0)
            playerScore = 0;
        // if (playerScore.HasValue)
        //     playerScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string n)
    {
        playerName = n;
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }
}
