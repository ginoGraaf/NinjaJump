using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class NormalWallView : MonoBehaviour
{
    [SerializeField] string NameWall;
    [SerializeField] List<GameObject> Coins;
    private float OutOfCameraField = 50;
    private GameObject wallObject;
    Action turnOff;

    public Action TurnOff { get => turnOff; set => turnOff = value; }

    private void Start()
    {
        if(wallObject==null)
        {
            wallObject = this.gameObject;
            transform.position = transform.position;
        }
    }
    public GameObject SpawnWall(Vector3 spawnPoint)
    {
        wallObject= ObjectPool.Instace.SpawnFromPool(NameWall, spawnPoint);
        transform.position = spawnPoint;
       
        return wallObject;
    }

    private void LateUpdate()
    {
        if(Vector3.Distance(transform.position,Camera.main.transform.position)> OutOfCameraField)
        {
            ActivatedCoins();
            ObjectPool.Instace.ReturnToPool(NameWall, wallObject);
            if(TurnOff!=null)
            {
                TurnOff();
                TurnOff = null;
            }
        }
    }

    private void ActivatedCoins()
    {
      
            for (int i = 0; i < Coins.Count; i++)
            {
                Debug.Log("SpawnCoins");
                Coins[i].SetActive(true);
            }
        
    }
}
