using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EZCameraShake;
public class Player : MonoBehaviour
{
    private LineRenderer line;
    private Transform cube1;
    private Transform cube2;
    private GameObject tempGameobject=null;
    RaycastHit raycastHit;
    public RippleCtrl rippleCtrl;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        cube1 = transform.Find("cube1");
        cube2 = transform.Find("cube2");
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, cube1.position);
        line.SetPosition(1, cube2.position);

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out raycastHit,20))
            {
                if (tempGameobject == null) {
                    tempGameobject = raycastHit.transform.gameObject;
                }
            }
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (screenPos.x < -3.3f || screenPos.x > 3.3f) return;
            if(tempGameobject!=null)
            {
                tempGameobject.transform.position = new Vector3(screenPos.x, screenPos.y, 0);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            tempGameobject =null;
        }
    }
}
