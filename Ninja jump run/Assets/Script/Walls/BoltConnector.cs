using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltConnector : MonoBehaviour
{
    [Header("lineConnector")]
    [SerializeField] private Transform[] leftSide;
    [SerializeField] private Transform[] rightSide;
    [SerializeField] private Transform buildingTransform;
    [SerializeField] private LineRenderer line;

    [Header("BoltObject")]
    [SerializeField] private GameObject bolt;
    [SerializeField] private float boltSpeed = 3;
    [SerializeField] private float spawnBoltTimer=3;
    [SerializeField] private NormalWallView normalWall;
    private Vector3 leftsideVector;
    private Vector3 righttsideVector;
    private Vector3 boltEndPos;

    float timer = 0;
   
    void OnEnable()
    {
        normalWall.TurnOff = SetOff;
        ChoosetDots();
    }

    //testing
    private void Update()
    {
        if (!bolt.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (timer > spawnBoltTimer)
            {
                BoltSpawn();
                timer = 0;
            }
        }
        else
        {
            MoveBolt();
        }
    }

    private void ChoosetDots()
    {
        line.positionCount = 2;
        Random.InitState(System.DateTime.Now.Millisecond + 1);
        int rightSideNumber = Random.Range(0, 3);
        Random.InitState(System.DateTime.Now.Millisecond+2);
        int leftSideNumber = Random.Range(0, 3);

        leftsideVector = leftSide[leftSideNumber].position- buildingTransform.position;
        righttsideVector = rightSide[rightSideNumber].position-buildingTransform.position;
        ConnectDots(leftsideVector, righttsideVector);
    }
    private void ConnectDots(Vector3 leftSide, Vector3 rightSide)
    {
     
        //Debug.Log("StartPoint:" + leftsideVector + " EndPoint: " + rightSide);
        line.SetPosition(0, leftSide);
        line.SetPosition(1, rightSide);
     
    }
    private void BoltSpawn()
    {
        int spawnPos= Random.Range(0, 2);
   
        switch(spawnPos)
        {
            case 0:
                bolt.transform.position = leftsideVector + buildingTransform.position;
                boltEndPos = righttsideVector+ buildingTransform.position;
                break;
            case 1:
                bolt.transform.position = righttsideVector+ buildingTransform.position;
                boltEndPos = leftsideVector+ buildingTransform.position;
                break;
        }
        bolt.SetActive(true);
    }

    private void MoveBolt()
    {
        bolt.transform.position = Vector3.MoveTowards(bolt.transform.position, boltEndPos, Time.deltaTime * boltSpeed);
        if(Vector3.Distance(bolt.transform.position,boltEndPos)<=0.1f)
        {
            bolt.SetActive(false);
        }
    }

    public void SetOff()
    {
        bolt.SetActive(false);
    }
}
