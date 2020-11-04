using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace hoppenhelm {
    public class Player : MonoBehaviour
    {
        public float speed;

        public bool canJump = true;

        private SpriteRenderer sr;

        public LayerMask layerMask;

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (canJump)
                {
                    sr.flipX = true;
                    CheckFrontHavaWall(sr.flipX == true ? -1 : 1);
                    int xPos = Mathf.FloorToInt(transform.position.x - 1);
                    transform.DOJump(new Vector3(xPos, -0.62f, 0), speed, 1, 0.3f).OnComplete(OnAnimFinish);
                    canJump = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (canJump)
                {
                    sr.flipX = false;
                    CheckFrontHavaWall(sr.flipX == true ? -1 : 1);
                    int xPos = Mathf.FloorToInt(transform.position.x + 1);
                    transform.DOJump(new Vector3(xPos, -0.62f, 0), speed, 1, 0.3f).OnComplete(OnAnimFinish);
                    canJump = false;
                }
            }
            
        }

        private void OnAnimFinish()
        {
            canJump = true;
        }

        bool CheckFrontHavaWall(int dir) {


            bool state = Physics2D.Raycast(new Vector2(transform.position.x + (dir==1?-0.5f:0.5f), transform.position.y), new Vector2(dir, 0), 1,layerMask);
            Debug.DrawRay(new Vector2(transform.position.x + (dir == 1 ? -0.5f : 0.5f), transform.position.y), new Vector2(dir, 0), Color.green);
            return state;
        }
    }
}


