using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneMove : MonoBehaviour
{
    #region Unity Editor Field
    [SerializeField] float timeToRise = 0.5f;
    [SerializeField] private float distanceFromCamera = 0.5f;
    [SerializeField] private Transform player;
    [SerializeField] private PlayerControl playerControl;
    #endregion
    #region field
    private float timer = 0;
    private float speed = 1;
    private bool moveCam = false;
    Vector3 camPos;
    #endregion
    #region start
    //
    // Start is called before the first frame update
    void Start()
    {
        camPos = Camera.main.transform.position;
    }
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        if (!playerControl.IsDead && playerControl.FirstJump)
        {
            Rise();
            ResetDeadZone();
        }
    }
    #endregion
    #region private
    private void Rise()
    {
        timer += Time.deltaTime;
        if (timer > timeToRise)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
    }

    private void ResetDeadZone()
    {
        if (moveCam)
        {
            Vector3 orginPos = new Vector3(transform.position.x, Camera.main.transform.position.y- distanceFromCamera, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, orginPos, Time.deltaTime * (distanceFromCamera*2));
            timer = 0;
            if (transform.position.y- Camera.main.transform.position.y < distanceFromCamera-0.1f )
            {
                moveCam = false;
            }
            
        }

        if (camPos.y - transform.position.y >distanceFromCamera)
        {
            moveCam = true;
         
        }
       // Debug.Log(camPos.y - transform.position.y);
        camPos = Camera.main.transform.position;
    }
    #endregion
}
