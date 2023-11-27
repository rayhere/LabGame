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
}
