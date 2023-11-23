using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public int backgroundZ = 190;
public class Spawner : MonoBehaviour
{
    const int NUM_COINS = 3;
    [SerializeField] GameObject balloon;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Spawner Start Run");
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
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

        for (int i = 0; i < NUM_COINS; i++)
        {
            Vector3 position = new Vector3(Random.Range(xMin1, xMax1),Random.Range(yMin1,yMax1), 10);
            if (position.y < 1.2 && position.x < -7)
                position.x +=1;
            if (position.y < 1.2 && position.x > 7)
                position.x -=1;

            Instantiate(balloon, position, Quaternion.identity);
        }


        // for (int i = NUM_COINS/2; i < NUM_COINS; i++)
        // {
        //     Vector2 position = new Vector2(Random.Range(xMin2, xMax2),Random.Range(yMin2,yMax2));
        //     Instantiate(balloon, position, Quaternion.identity);
        // }

    }
}
