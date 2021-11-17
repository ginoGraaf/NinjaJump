using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    #region Unity Editor Field
    [Header("Building")]
    [SerializeField] List<GameObject> walls; 
    [SerializeField] private Transform LastObjectPlaces;

    [Header("Wall placement")]
    [SerializeField] private float ySizeWall = 0;
    [SerializeField] private float spawnDistanceRangeCam;
    #endregion

    #region update
    void Update()
    {
        AddNewPiece();
    }
    #endregion

    #region priavte
    private void AddNewPiece()
    {

        //later I want this to be in a pool.
        if (Vector3.Distance(Camera.main.transform.position, LastObjectPlaces.transform.position) < spawnDistanceRangeCam)
        {
            GameObject obj = walls[Random.Range(0, walls.Count)].GetComponent<NormalWallView>().SpawnWall(new Vector3(LastObjectPlaces.position.x, LastObjectPlaces.position.y + ySizeWall, LastObjectPlaces.position.z));
         
            LastObjectPlaces = obj.transform;
        }
    }
    #endregion
}
