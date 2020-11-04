using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySword : Entity
{
    private Transform triggedTrans;
    public override void Start()
    {
        base.Start();
        OnHide();
    }
    private void OnHide()
    {
        sr.DOFade(0, 0.5f).OnComplete(OnShow);
    }

    private void OnShow(){
        sr.DOFade(1, 0.5f).OnComplete(OnHide);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag =="Player")
        {
            triggedTrans = collision.transform;
            OnPlayerPickUp();
            Destroy(gameObject, 0.1f);
        }
    }
    public override void OnPlayerPickUp()
    {
        triggedTrans.GetComponent<PlayerManager>().HaveSword = true;
    }
}
