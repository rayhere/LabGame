using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raven : MonoBehaviour
{
    [SerializeField] GameObject raven;
    [SerializeField] AudioSource audio;

    //destroy timer
    //public float timer = 8f;
    //public bool canDestory = false;
    public float ttime;

    //public bool collisionTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        float wideAngle = Random.Range(-.2f,.2f);
        raven.GetComponent<Rigidbody>().AddForce(new Vector2(0, wideAngle * 10f));


        //raven fly speed
        float speed = Random.Range(0f, 500f);
        if (raven.transform.localPosition.x <=0)
        {
            raven.GetComponent<Rigidbody>().AddForce(new Vector2(200f + speed, 0));
        }
        else 
        {
            raven.GetComponent<Rigidbody>().AddForce(new Vector2((200f + speed)* -1, 0));
        }
        

        //raven fly sound
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

        //2. play sound effect
        //AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        audio.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        // ttime = Time.time;
        // if (timer < Time.time)
        // {
        //     Destroy(gameObject);
        // }
    }

    void OnTriggerEnter(Collider collision)
    {
        //what should happen now?
        //1. count the coins or increase score
        //2.  play sound effect
        //3. coin should disapper

        //1. increase score
        //controller.GetComponent<Scorekeeper>().AddPoints();

        //2. play sound effect
        //AudioSource.PlayClipAtPoint(audio.clip, transform.position);

        //audio.Play() -- this will work but won't work if coin gets destroyed before audio is played.

        //3. destroy coin
        //Destroy(gameObject);


        //Detecting Collisions with a certain tag

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyBullet")
        {
            //destory the MyBullet
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //If the GameObject has the same tag as specified, output this message in the console
            // if (!canDestory)
            {
                //animator.SetInteger("popped", POPPED);
                // Debug.Log("Popped: " + POPPED);

                // Debug.Log("timer: " + timer);
                // Debug.Log("deltaTime: " + Time.deltaTime);
                // Debug.Log("Time.time: " + Time.time);
            
                // timer += Time.time;

                // Debug.Log("new timer: " + timer);

                // //2. play sound effect
                // AudioSource.PlayClipAtPoint(audio.clip, transform.position);

                // //audio.Play() -- this will work but won't work if coin gets destroyed before audio is played.

                // canDestory = true;
                // //collisionTriggered = true;

                // // increase score
                // //gameController.GetComponent<ScoreKeeper>().AddPoints();
                // int rounded_f = (int)(thisBalloon.transform.localScale.x +0.5f);
                // gameController.GetComponent<ScoreKeeper>().AddPoints(4 - rounded_f);
            }
            Debug.Log("MyBullet collision detected");
        }
        else
        {
            // if (!canDestory)
            // {
            //     animator.SetInteger("popped", POPPED);
            //     Debug.Log("Popped: " + POPPED);

            //     Debug.Log("timer: " + timer);
            //     Debug.Log("deltaTime: " + Time.deltaTime);
            //     Debug.Log("Time.time: " + Time.time);
            
            //     timer += Time.time;

            //     Debug.Log("new timer: " + timer);

            //     canDestory = true;
            // }
            Debug.Log("collision detected");
        }

        // if (!canDestory)
        // {
        //     animator.SetInteger("popped", POPPED);
        //     Debug.Log("Popped: " + POPPED);

        //     Debug.Log("timer: " + timer);
        //     Debug.Log("deltaTime: " + Time.deltaTime);
        //     Debug.Log("Time.time: " + Time.time);
            
        //     timer += Time.time;

        //     Debug.Log("new timer: " + timer);

        //     canDestory = true;
        // }

        // animator.SetInteger("popped", POPPED);
        // Debug.Log("Popped: " + POPPED);

        // Debug.Log("timer: " + timer);
        // Debug.Log("deltaTime: " + Time.deltaTime);
        // Debug.Log("Time.time: " + Time.time);
        
        // timer += Time.time;

        // Debug.Log("new timer: " + timer);

        // canDestory = true;
    }
}
