using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class NPCManager : MonoBehaviour
{
    public Entity entity;

    private string[] dialogdic = new string[]
    {
        "嗨，你是新的冒险者吗？",
        "......",
        "997----998---999",
        "嗨，等等，你在数什么？还有，你是谁",
        "我是谁不重要，重要的是你是第1000个",
        "你打算就这样开始你的冒险？赤手空拳？",
        "拿上它，开始你的冒险吧！",
        "等等，你到底是谁？算了吧，先拿上这把剑开始探险吧！",
        "刚才那个人好像是从这里进去的",
        "脚步声..."
    };

    /// <summary>
    /// 是否已经完成对话
    /// </summary>
    private bool isFinishDialog;

    /// <summary>
    /// 开始对话
    /// </summary>
    private bool startDialog;

    private int index = 0;

    private void Start()
    {
        entity.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isFinishDialog)
        {
            
        }
        if(startDialog)
        {
            if (Input.GetMouseButtonDown(0))
            {
                index++;
                Debug.Log(dialogdic[index]);
            }
            if(index==7)
            {
                entity.gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
            }
            if(index>= dialogdic.Length)
            {
                startDialog = false;
                isFinishDialog = true;
                PlayerManager.instance.canCtrl = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            startDialog = true;
            PlayerManager.instance.canCtrl = false;
            PlayerManager.instance.mRig.velocity = Vector2.zero;
            PlayerManager.instance.playerState = PlayerState.idle;
            PlayerManager.instance.Anim.SetBool("run", false);
        }
    }


}
