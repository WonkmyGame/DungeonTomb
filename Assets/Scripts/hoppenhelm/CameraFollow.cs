using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace hoppenhelm {


    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        private void FixedUpdate()
        {
            transform.DOMoveX(target.position.x, 0.5f);
        }

    }
}

