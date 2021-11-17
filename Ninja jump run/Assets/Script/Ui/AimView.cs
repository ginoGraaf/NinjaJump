using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimView : MonoBehaviour
{
    [SerializeField] private Image aimImage;

    public void MoveAim(Vector3 lookatDir)
    {
        Vector3 screen = Camera.main.WorldToScreenPoint(lookatDir);
        screen = new Vector3(screen.x, screen.y, screen.z);
        aimImage.rectTransform.position = screen;
    }
}
