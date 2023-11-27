using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    //[SerializeField] GameObject controller;
    //[SerializeField] AudioSource audio;
    //[SerializeField] int popped;
    [SerializeField] public GameObject thisBalloon;

    [SerializeField] public GameObject gameController; 

    [SerializeField] Animator animator;

    [SerializeField] AudioSource audio;

    
    const int UNPOPPED = 0;
    const int POPPED = 1;
    public float timer = .5f;
    public bool canDestory = false;
    public float ttime;
    public Vector3 maxScale;
    public bool collisionTriggered = false;
    public float swingForce;
    public float swingTime;

    private int goLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        //if (controller == null)
        //{
        //    controller = GameObject.FindGameObjectWithTag("GameController");
        //}
        //if (audio == null)
        //{
        //    audio = GetComponent<AudioSource>();
        //}

        //if (animator == null)
        //    animator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        animator.SetInteger("popped", UNPOPPED);

        maxScale = new Vector3 (thisBalloon.transform.localScale.x * 2, thisBalloon.transform.localScale.y * 2, thisBalloon.transform.localScale.z * 2);

        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }

        swingForce = Random.Range(10f, 20f);
        swingTime = .5f;

        
    }

    // Update is called once per frame
    void Update()
    {
        ttime = Time.time;
        if (canDestory && timer < Time.time)
        {
            //Spawner.Instance.SetNumBalloon(1);

            //Self Explosion
            gameController.GetComponent<Spawner>().SetNumBalloon(1);
            Destroy(gameObject);
            
        }
        else if (!canDestory)
        {
            BalloonMovement();
            if (maxScale.x > thisBalloon.transform.localScale.x)
            {
                BalloonScale();
            }
            else
            {
                //target not collision Triggered, go explosion
                canDestory = true;
                animator.SetInteger("popped", POPPED);
                //2. play sound effect
                AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                timer += Time.time;
            }
        }
        
        //swingTime += Time.time;
        // Debug.Log("swingTime" + swingTime);
        // Debug.Log("Time.deltaTime" + Time.time);
        // if (swingTime <= Time.time)
        // {
        //     Debug.Log("swingTime" + swingTime);
        //     //change left or right
        //     if (goLeft == 0)
        //     {
        //         thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(swingForce * (-5), 0));
        //         goLeft += 1;
        //         swingTime = 1+Time.time;
        //     }
        //     else if (goLeft == 1)
        //     {
        //         thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(swingForce * (10), 0));
        //         goLeft += 1;
        //         swingTime = 1+Time.time;
        //     }
        //     else if (goLeft == 2)
        //     {
        //         thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(swingForce * (-10), 0));
        //         //goLeft += 1;
        //         goLeft = 1;
        //         swingTime = 1+Time.time;
        //     }
        //     else
        //     {
        //         // goLeft = 0;
        //         // swingTime = 1+Time.time;
        //     }
            
        // }
        BalloonMovement();
        // if (maxScale.x > thisBalloon.transform.localScale.x)
        // {
        //     BalloonScale();
        // }
        // else
        // {
        //     canDestory = true;
        //     animator.SetInteger("popped", POPPED);
        //     timer += Time.time;
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
            //If the GameObject has the same tag as specified, output this message in the console
            if (!canDestory)
            {
                animator.SetInteger("popped", POPPED);
                Debug.Log("Popped: " + POPPED);

                Debug.Log("timer: " + timer);
                Debug.Log("deltaTime: " + Time.deltaTime);
                Debug.Log("Time.time: " + Time.time);
            
                timer += Time.time;

                Debug.Log("new timer: " + timer);

                //2. play sound effect
                AudioSource.PlayClipAtPoint(audio.clip, transform.position);

                //audio.Play() -- this will work but won't work if coin gets destroyed before audio is played.

                canDestory = true;
                //collisionTriggered = true;

                // increase score
                //gameController.GetComponent<ScoreKeeper>().AddPoints();
                int rounded_f = (int)(thisBalloon.transform.localScale.x +0.5f);
                gameController.GetComponent<ScoreKeeper>().AddPoints(4 - rounded_f);
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

    void BalloonMovement()
    {
        
        thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(0, Random.Range(.001f, .01f)));
        //thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2( 0, .001f));
        // Vector3 position = new Vector3(Random.Range(xMin1, xMax1),Random.Range(yMin1,yMax1), 190);
        //     if (position.y < 1.2 && position.x < -7)
        //         position.x +=1;
        //     if (position.y < 1.2 && position.x > 7)
        //         position.x -=1;
        //thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(swingForce, 0));

        if (swingTime <= Time.time)
        {
            Debug.Log("swingTime" + swingTime);
            //change left or right
            if (goLeft == 0)
            {
                thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(swingForce * (-5), 0));
                goLeft += 1;
                swingTime = 1+Time.time;
            }
            else if (goLeft == 1)
            {
                thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(swingForce * (10), 0));
                goLeft += 1;
                swingTime = 1+Time.time;
            }
            else if (goLeft == 2)
            {
                thisBalloon.GetComponent<Rigidbody>().AddForce(new Vector2(swingForce * (-10), 0));
                //goLeft += 1;
                goLeft = 1;
                swingTime = 1+Time.time;
            }
            else
            {
                // goLeft = 0;
                // swingTime = 1+Time.time;
            }
            
        }
    }

    void BalloonScale()
    {
        thisBalloon.transform.localScale += new Vector3 (0.001f, 0.001f, 0.001f);
    }
}
