using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public int backgroundZ = 190;
public class Spawner : MonoBehaviour
{
    public int NUM_Balloon = 1;
    [SerializeField] GameObject balloon;

    [SerializeField] GameObject raven;

    public static Spawner Instance;

    //public float ttime;
    public float ravenTimer = .5f; 
    private float ravenTimeCycle = .5f; //spawning cycle


    private float balloonTimer = 1f;
    private float balloonTimeCycle = 1f; //spawning cycle

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Spawner Start Run");
        Spawn();
        NUM_Balloon = 0;

        //raven spawn 
        ravenTimer += Time.time;
        ravenSpawn();

        //raven reSpawn time will be shorter, if level is higher
        int sceneLevel = PersistentData.Instance.GetLevel();
        if (sceneLevel > 0)
        {
            ravenTimeCycle = ravenTimeCycle /PersistentData.Instance.GetLevel();
        }
        else
        {
            ravenTimeCycle = 1f;
        }
        //ravenTimeCycle = ravenTimeCycle /10;
    }

    // Update is called once per frame
    void Update()
    {
        if (ravenTimer < Time.time)
        {
            ravenSpawn();
            ravenTimer = Time.time + ravenTimeCycle;
        }

        if (NUM_Balloon > 0 && balloonTimer < Time.time)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int xMin1 = -7;
        int yMin1 = 0;
        int xMax1 = 7;
        int yMax1 = 4;

        for (int i = 0; i < NUM_Balloon; i++)
        {
            Vector3 position = new Vector3(Random.Range(xMin1, xMax1),Random.Range(yMin1,yMax1), 10);
            if (position.y < 1.2 && position.x < -7)
                position.x +=1;
            if (position.y < 1.2 && position.x > 7)
                position.x -=1;
            Instantiate(balloon, position, Quaternion.identity);
        }
        // set to zero, so update() won't tigger
        NUM_Balloon = 0;
    }

    void ravenSpawn()
    {
        int yMin1 = 0;
        int yMax1 = 8; //top of screen
        int xPos = 0;

        double xRandom = Random.Range(-1,1);
        if (xRandom <= 0)
        {
            xPos = -16;
        }
        else
        {
            xPos = 17;
        }

        Vector3 position = new Vector3(xPos,Random.Range(yMin1,yMax1), 10);
        Instantiate(raven, position, Quaternion.identity);
    }

    public void SetNumBalloon(int b)
    {
        //Delay
        balloonTimer = Time.time + balloonTimeCycle;

        NUM_Balloon = b;
    }
}
