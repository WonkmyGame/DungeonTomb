using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityChest : Entity
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="sword")
        {
            Debug.Log("是剑碰到了箱子");
            CameraShake.ShakeOnce(0.1f, 0.2f);
            OnPlayerPickUp();
        }
    }

    public override void OnPlayerPickUp()
    {
        anim.SetTrigger("breaked");
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
