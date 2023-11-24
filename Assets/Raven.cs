using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raven : MonoBehaviour
{
    [SerializeField] GameObject raven;
    // Start is called before the first frame update
    void Start()
    {
        float wideAngle = Random.Range(-.2f,.2f);
        raven.GetComponent<Rigidbody>().AddForce(new Vector2(0, wideAngle * 10f));


        //raven fly speed
        float speed = Random.Range(0f, 500f);
        raven.GetComponent<Rigidbody>().AddForce(new Vector2(200f + speed, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
