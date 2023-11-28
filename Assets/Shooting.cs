using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class Shooting : MonoBehaviour
{
    [Header("Rope Settings")]
    //TransPoint from 3D Object
    [SerializeField] private Transform TransPoint1;
    [SerializeField] private Transform TransPoint2;

    [SerializeField] private Transform bulletSpawnPoint; // bulletSpawnPoint

    [SerializeField] private GameObject BallPrefab;

    [SerializeField] private int rubberPower;

    [SerializeField] Vector3 centerPos;

    private LineRenderer _lineRenderer;
    private Transform _newBall;
    private Camera mainCamLocal;
    private bool shootingFire = false;
    private int rPower = 0;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        rubberPower = rPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (_newBall && Input.GetKeyDown(KeyCode.E))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            centerPos = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z -1f);
            Vector3 pos = new Vector3
                (Input.mousePosition.x, Input.mousePosition.y, -10f);

            _newBall.position = new Vector3(worldPosition.x, worldPosition.y +.1f, worldPosition.z - 1f);

            _lineRenderer.SetPosition(1, centerPos);
            Debug.Log("rpower increased");
        }

        //generate new ball
        if (Input.GetMouseButtonDown(0) && _newBall == null) 
        {
            _newBall = Instantiate(bulletSpawnPoint, Vector3.zero, Quaternion.identity);

            if(_newBall) 
            {
                //add 3rd Point in the Middle..
                if (_lineRenderer.positionCount < 3) 
                    _lineRenderer.positionCount = 3;

                Vector3 newPos = _newBall.position;
                newPos.z = -9f;
                newPos.y += .2f;
                //newPos.y = -.2f;

                _lineRenderer.SetPosition(1, newPos);
            }
        }
        if (Input.GetMouseButton(0) && _newBall)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            
            centerPos = new Vector3 (worldPosition.x, worldPosition.y, worldPosition.z + 5f);
            Vector3 pos = new Vector3
                (Input.mousePosition.x, Input.mousePosition.y, -10f);

            _newBall.position = new Vector3(worldPosition.x, worldPosition.y +.2f, -5.8f);

            _lineRenderer.SetPosition(1, centerPos);
            Debug.Log("clicked");
        }
        else if (Input.GetMouseButtonUp(0)) //Release Mouse or Touch
        {
            shootingFire = true;
            Debug.Log("released");
        }

        if (TransPoint1 && TransPoint2)
        {
            _lineRenderer.SetPosition(0, TransPoint1.position);
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, TransPoint2.position) ;
        }
    }

    //can be called potentially many times per frame -- best for physics
    void FixedUpdate()
    {
        if (shootingFire)
        {
            Vector3 newPos = _newBall.position;

            _lineRenderer.SetPosition(1, newPos);

            _newBall.GetComponent<Rigidbody>().isKinematic = false;
            _newBall.GetComponent<Rigidbody>().AddForce(_newBall.forward * 1000);
            
            //_newBall.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * 10;

            float titledUpAngle = (TransPoint1.position.y + TransPoint2.position.y) / 2;
            float Angle2 = _lineRenderer.GetPosition(1).y;

            //_newBall.GetComponent<Rigidbody>().AddForce(_newBall.up * Mathf.Abs(titledUpAngle) * 100);

            _newBall.GetComponent<Rigidbody>().AddForce(new Vector2(0, Mathf.Abs(titledUpAngle) * 500f));
            //_newBall.GetComponent<Rigidbody>().AddForce(new Vector2(_lineRenderer.GetPosition(1) * 500f, 0));
            Debug.Log("titledUpAngle: " + titledUpAngle);
            FindObjectOfType<Bullet>().UpdateAngle(Angle2);
            FindObjectOfType<Bullet>().UpdateAngle(Angle2);
            _newBall = null;
            shootingFire = false;

            //https://stackoverflow.com/questions/61081193/linerenderer-how-to-delete-any-point
            //_lineRenderer.SetPositions(points);
            //_lineRenderer.SetPositions.Arra
            //var pointsList = new List<Vector3>(pointsArray);
            //pointsList.RemoveAt(1);
            //pointsArray = pointsList.ToArray();

            _lineRenderer.positionCount = 0;
        }
    }

    void UpdateLineRenderer()
    {
        //LineRenderer lineRenderer = GetComponent<LineRenderer>();
        //int newPositionCount = lineRenderer.positionCount - 1;
        //Vector3[] newPositions = new Vector3[newPositionCount];

        //for (int i = 0; i < newPositionCount; i++)
        //{
        //    newPositions *= lineRenderer.GetPosition[i + 1];
        //}
        //lineRenderer.SetPositions(newPositions);
    }
}
