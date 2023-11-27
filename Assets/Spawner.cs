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

    public float ttime;
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

        ravenTimeCycle = ravenTimeCycle /PersistentData.Instance.GetLevel();
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

        // int xMin2 = -9;
        // int xMax2 = 13;
        // int yMin2 = 2;
        // int yMax2 = 6;

        for (int i = 0; i < NUM_Balloon; i++)
        {
            Vector3 position = new Vector3(Random.Range(xMin1, xMax1),Random.Range(yMin1,yMax1), 10);
            if (position.y < 1.2 && position.x < -7)
                position.x +=1;
            if (position.y < 1.2 && position.x > 7)
                position.x -=1;

            Instantiate(balloon, position, Quaternion.identity);
        }
        NUM_Balloon = 0;

        // for (int i = NUM_COINS/2; i < NUM_COINS; i++)
        // {
        //     Vector2 position = new Vector2(Random.Range(xMin2, xMax2),Random.Range(yMin2,yMax2));
        //     Instantiate(balloon, position, Quaternion.identity);
        // }

    }

    void ravenSpawn()
    {
        int xMin1 = -16;
        int yMin1 = 0;
        int xMax1 = 17;
        int yMax1 = 4;
        int xPos = 0;

        int xRandom = Random.Range(-1,1);
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
