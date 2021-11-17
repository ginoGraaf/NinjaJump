using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraOffSet;
    [SerializeField] private float smoothSpeed = 15f;
    
    private Transform camTransForm;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        camTransForm = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.y - camTransForm.position.y) > 0.1f)
        {
            Vector3 targetPosition = playerTransform.position + cameraOffSet;
        targetPosition = new Vector3(camTransForm.position.x, targetPosition.y, camTransForm.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        }
    }
}
