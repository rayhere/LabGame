using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raven : MonoBehaviour
{
    [SerializeField] GameObject raven;
    [SerializeField] AudioSource audio;

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

    }

    void OnTriggerEnter(Collider collision)
    {
        //Detecting Collisions with a certain tag

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyBullet")
        {
            //destory the MyBullet
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("MyBullet collision detected");
        }
        else
        {
            Debug.Log("collision detected");
        }
    }
}
