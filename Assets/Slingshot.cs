using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Rope Settings")]
    //TransPoint from 3D Object
    [SerializeField] private Transform TransPoint1;
    [SerializeField] private Transform TransPoint2;
    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] private Transform bulletSpawnPoint; // bulletSpawnPoint

    [SerializeField] private GameObject BallPrefab;

    //[SerializeField] private int rubberPower;

    [SerializeField] Vector3 centerPos;

    //add shooting sound
    [SerializeField] AudioSource audio;

    //add firerate
    public float firerate = .5f;

    private float timeFire;
    private float nextTimeFire;
    //private bool timeForFire;

    private LineRenderer _lineRenderer;
    public GameObject _newBall;
    private Camera mainCamLocal;
    private bool shootingFire = false;
    //private int rPower = 0;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        //rubberPower = rPower;
        Debug.Log("rigid.position.x: " + rigid.position.x);
        Debug.Log("rigid.position.y: " + rigid.position.y);

        //add shooting sound
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

        // read firerate
        firerate = GameMod.Modifier.GetBonusFireRate();

        //timeForFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        //https://docs.unity3d.com/ScriptReference/Input-mousePosition.html
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (Input.GetMouseButton(0) && mousePos.x > rigid.position.x - 1.5 && mousePos.x < rigid.position.x + 1.5 && mousePos.y < rigid.position.y + 1.4 && mousePos.y > rigid.position.y -2)
        //{

        //firerate
        //every frame pass, increase timeFire
        timeFire += Time.deltaTime;
        //firerate: higher number faster
        nextTimeFire = 1 / firerate;
        
        //when timeFire is larger than firerate
        if (timeFire >= nextTimeFire)
        {
            //timeForFire = true;

            //generate new ball
            if (Input.GetMouseButtonDown(0) && _newBall == null)
            {
                _newBall = Instantiate(BallPrefab, Vector3.zero, Quaternion.identity);

                if (_newBall)
                {
                    //add 3rd Point in the Middle..
                    if (_lineRenderer.positionCount < 3)
                        _lineRenderer.positionCount = 3;

                    Vector3 newPos = _newBall.transform.position;
                    newPos.z = -9f;
                    newPos.y += .2f;
                    //newPos.y = -.2f;

                    _lineRenderer.SetPosition(1, newPos);
                }
            }
            if (Input.GetMouseButton(0) && _newBall)
            {
                //Vector3 newPos = _newBall.position;
                //newPos.z += .55f;
                //newPos.y += -.6f;

                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                centerPos = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z + 5f);
                //Vector3 pos = new Vector3
                //    (Input.mousePosition.x, Input.mousePosition.y, -10f);

                _newBall.transform.position = new Vector3(worldPosition.x, worldPosition.y + .2f, -5.8f);

                _lineRenderer.SetPosition(1, centerPos);
                //Debug.Log("clicked");
            }

            if (Input.GetMouseButton(0) && _newBall)
            {
            
            }
            else if (Input.GetMouseButtonUp(0) && _newBall) //Release Mouse or Touch
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mousePos.x > rigid.position.x - 1.5 && mousePos.x < rigid.position.x + 1.5 && mousePos.y < rigid.position.y + 1.4 && mousePos.y > rigid.position.y - 2)
                {
                    shootingFire = true;
                    Debug.Log("released");
                }
                else
                {
                    _lineRenderer.positionCount = 2;
                    Destroy(_newBall);
                    Debug.Log("reset _LineRenderer");
                }
            }
        }
        if (TransPoint1 && TransPoint2)
        {
            _lineRenderer.SetPosition(0, TransPoint1.position);
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, TransPoint2.position);
        }
    }

    //can be called potentially many times per frame -- best for physics
    void FixedUpdate()
    {
        if (shootingFire)
        {
            Debug.Log("shootingFire is true");
            Vector3 newPos = _newBall.transform.position;
            Debug.Log("newPos: " + newPos);

            _lineRenderer.SetPosition(1, newPos);

            _newBall.GetComponent<Rigidbody>().isKinematic = false;
            _newBall.GetComponent<Rigidbody>().AddForce(_newBall.transform.forward * 500);

            //_newBall.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * 10;

            float titledUpAngle2 = (TransPoint1.position.y + TransPoint2.position.y) / 2;
            float titledUpAngle = ((TransPoint1.position.y + TransPoint2.position.y) / 2);
            float Angle2 = _lineRenderer.GetPosition(1).y;
            float rubberCenterPosY = _lineRenderer.GetPosition(1).y;
            titledUpAngle += Mathf.Abs(rubberCenterPosY);
            // if (rubberCenterPosY <= 0)
            // {
            //     titledUpAngle += Mathf.Abs(rubberCenterPosY);
            // }
            // else
            // {
            //     titledUpAngle += Mathf.Abs(rubberCenterPosY);
            // }
            
            //_newBall.GetComponent<Rigidbody>().AddForce(_newBall.up * Mathf.Abs(titledUpAngle) * 100);

            //_newBall.GetComponent<Rigidbody>().AddForce(new Vector2(0, -(Angle2) * 200f));

            _newBall.GetComponent<Rigidbody>().AddForce(new Vector2(0, 500f + (titledUpAngle) * 200f));

            //left right
            float wideAngle = ((rigid.position.x - _lineRenderer.GetPosition(1).x));
            _newBall.GetComponent<Rigidbody>().AddForce(new Vector2( (wideAngle) * 400f, 0));
            Debug.Log("newPosx: " + newPos.x);
            Debug.Log("titledUpAngle2: " + titledUpAngle2);
            FindObjectOfType<Bullet>().UpdateAngle(Angle2);
            FindObjectOfType<Bullet>().UpdateShooted(true);
            _newBall = null;
            shootingFire = false;

            //2. play sound effect
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);


            //reset lineRender position
            _lineRenderer.positionCount = 2;

            //set timeFire and timeForFire
            timeFire = 0;
            //timeForFire = false;
        }

        //if (_newBall != null)
        //{
        //    Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamLocal.WorldToScreenPoint(_newBall.position).z);
        //    Vector3 worldPos = mainCamLocal.ScreenToWorldPoint(pos);
        //    _newBall.position = new Vector3(worldPos.x, worldPos.y , worldPos.z);
        //    Vector3 newPos = _newBall.position;
        //    newPos.z = 0f;
        //    //newPos.y = 0.5f;
        //    _lineRenderer.SetPosition(1, newPos);
        //}



    }
}
