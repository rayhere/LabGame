using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{

    public static dontDestroy dD;

    void Awake()
    {
        if (dD == null)
        {
            DontDestroyOnLoad(this);
            Debug.Log("dD.sc Don't Destory On Load");
            dD = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroy(gameObject)");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
