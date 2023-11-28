using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody RgbBullet;
    //[SerializeField] private Rigidbody Trail;
    [SerializeField] public int NumOfBounces = 3;
    [SerializeField] public GameObject thisBullet;
    //[SerializeField] public GameObject Trail;
    [SerializeField] public bool shooted;
    //[SerializeField] public float timer;
    private Vector3 lastVelocity;
    //private float curSpeed;
    //private Vector3 direction;
    //private int curBounces = 0;
    //private Vector3 scaleChange, positionChange;

    TrailRenderer Trail;

    private float timer = 3f;

    public float life = 3;
    public float targetSpeed;
    public float speed;
    public float speedDV;  // "damp velocity"

    private Vector3 scaleChange, positionChange;
    

    private void Awake()
    {
        //Destroy(gameObject, life);
        //scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        //positionChange = new Vector3(0.0f, -0.005f, 0.0f);

        scaleChange = new Vector3(-0.001f, -0.001f, -0.001f);
    }


    // Start is called before the first frame update
    void Start()
    {
        //https://forum.unity.com/threads/changing-trail-renderer-variables-through-script.156206/
        Trail = gameObject.GetComponent<TrailRenderer>();
        if (Trail == null)
        {
            Debug.Log("Trail does not found");
        }
        else{
            Debug.Log("Trail is found");
        }
    }
    //Update is executed each frame;
    void Update()
    {
        if (shooted)
        {
            //https://docs.unity3d.com/ScriptReference/Transform-localScale.html
            //change bullet scale
            UpdateScale();

            if (timer < Time.time)
                Destroy(gameObject);
        }
            
    }
    //FixedUpdate is executed at a specific rate defined in the editor;
    //and LateUpdate is executed after all the Update functions have been called.
    // Update is called once per frame
    void LateUpdate()
    {
        lastVelocity = RgbBullet.velocity;
        //lastVelocity = thisBullet.velocity;

        //speed = Mathf.SmoothDamp(speed, targetSpeed, ref speedDV, 0.5f);

        // Move the object forward along its z axis 1 unit/second.
        //transform.Translate(Vector3.forward * Time.deltaTime);

        //https://docs.unity3d.com/ScriptReference/Transform.Translate.html
        //if (transform.localPosition.z < 10 )
            // Move the object upward in world space 1 unit/second.
            //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        //if (transform.localPosition.z > 10)
            // Move the object upward in world space 1 unit/second.
            //transform.Translate(Vector3.down * Time.deltaTime, Space.World);

        //https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html
        
        //speed = Mathf.SmoothDamp(speed, targetSpeed, ref speedDV, 0.5f);
        //RgbBullet.velocity = new Vector3(0, speed, 0);



        //targetSpeed = 0;
        //speed = RgbBullet.position.
        //speed = Mathf.SmoothDamp(speed, targetSpeed, ref speedDV, 0.5f);

        //RgbBullet.position.Set(speed);
        //if (RgbBullet.transform.position.z != lastVelocity) { }
        //RgbBullet.transform.localScale -= scaleChange;

        // Move upwards when the sphere hits the floor or downwards
        // when the sphere scale extends 1.0f.
        //if (RgbBullet.transform.localScale.y < 0.1f || RgbBullet.transform.localScale.y > 1.0f)
        //{
        //    scaleChange = -scaleChange;
        //    positionChange = -positionChange;
        //}

        //pos = this.gameObject.transform.GetChild(0);
        //float xscale = pos.position.z;
        //transform.localScale = new Vector3(1f + xscale, 1f, 1f);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (curBounces >= NumOfBounces) return;

    //    curSpeed = lastVelocity.magnitude;
    //    direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

    //    RgbBullet.velocity = direction * Mathf.Max(curSpeed, 0);
    //    curBounces++;
    //}

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);

    }

    public void UpdateAngle(float angle)
    {
        Debug.Log("Bullet angle: "+ angle);
    }

    public void UpdateShooted(bool shooted)
    {
        this.shooted = shooted;
        timer += Time.time;
    }

    public void UpdateScale()
    {
        //RgbBullet
        if (RgbBullet.transform.localScale.x > 0 || RgbBullet.transform.localScale.y > 0)
        {
            RgbBullet.transform.localScale += scaleChange;
        }
    }
}
