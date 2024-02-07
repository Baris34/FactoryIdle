using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    public Transform cam;
    public static CameraManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<CameraManager>(true);
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;        
    }

    public void madenCam()
    {
        CameraManager.Instance.cam.DORotate(new Vector3(45, -90, 0), 1.8f).OnUpdate(() =>
        {
            CameraManager.Instance.cam.DOMove(new Vector3(-5, 25, 5), 1.8f);
        });
    }
    public void fabrikaCam()
    {
        CameraManager.Instance.cam.DORotate(new Vector3(50, -15, -2), 1.8f).OnUpdate(() =>
        {
            CameraManager.Instance.cam.DOMove(new Vector3(5, 25, -19), 1.8f);
        });
    }


}
