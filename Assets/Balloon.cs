using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    //[SerializeField] GameObject controller;
    //[SerializeField] AudioSource audio;
    //[SerializeField] int popped;
    [SerializeField] public GameObject thisBalloon;

    [SerializeField] Animator animator;

    const int UNPOPPED = 0;
    const int POPPED = 1;
    private float timer = .5f;
    private bool canDestory = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (canDestory && timer < Time.time)
            Destroy(gameObject);
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

        animator.SetInteger("popped", POPPED);
        Debug.Log("Popped: " + POPPED);

        Debug.Log("timer: " + timer);
        Debug.Log("deltaTime: " + Time.deltaTime);
        Debug.Log("time: " + Time.time);
        
        timer += Time.time;

        Debug.Log("new timer: " + timer);

        canDestory = true;
    }
}
