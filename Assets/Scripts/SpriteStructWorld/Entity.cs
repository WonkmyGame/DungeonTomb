using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public SpriteRenderer sr;

    public Animator anim;

    public bool isUpandDowenMove = false;
    /// <summary>
    /// 当玩家捡起该实体的时候
    /// </summary>
    public virtual void OnPlayerPickUp() { }

    public virtual void Start()
    {
        if(isUpandDowenMove)
        {
            OnUp();
        }
    }

    private void OnUp()
    {
        transform.DOLocalMoveY(transform.localPosition.y + 0.5f, 1).OnComplete(OnDown).SetEase(Ease.Linear);
    }
    private void OnDown() {
        transform.DOLocalMoveY(transform.localPosition.y - 0.5f, 1).OnComplete(OnUp).SetEase(Ease.Linear);
    }
}
