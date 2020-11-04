using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    void Awake()
    {
        instance = this;
    }
    public Transform target;

    public Vector3 offset;
    private Vector3 cur_velo;

    public float delayTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref cur_velo, delayTime);
        if (transform.position.x <= -18)
        {
            transform.position = new Vector3(-18, transform.position.y, -10);
        }
        if (transform.position.y < 1.56f) {
            transform.position = new Vector3(transform.position.x, 1.56f, -10);
        }
    }
}
