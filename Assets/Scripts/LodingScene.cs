using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LodingScene : MonoBehaviour {

    AsyncOperation async;
    public Slider m_pProgress;
    private int progress = 0;
    public Text lodingNum;

    //public SpriteRenderer spriterenderer;
    //public Sprite[] bgSprites;

    //public bool isTestMode=false;
    void Start()
    {
        //spriterenderer.sprite = bgSprites[Random.Range(0, bgSprites.Length)];
        StartCoroutine(LoadScenes());
    }
    IEnumerator LoadScenes()
    {
        int nDisPlayProgress = 0;
        //if (isTestMode)
        //{
            async = SceneManager.LoadSceneAsync("RugulikeGameMain");
        //}
        //else
        //{
        //    if (GameState.instance.gameState == GameStat.BACKMENU)
        //    {
        //        async = SceneManager.LoadSceneAsync("Menu");
        //    }
        //    if (GameState.instance.gameState == GameStat.GOTOMAIN)
        //    {
        //        async = SceneManager.LoadSceneAsync("SampleScene");
        //    }
        //}
        
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            progress = (int)async.progress * 100;
            while (nDisPlayProgress < progress)
            {
                ++nDisPlayProgress;
                m_pProgress.value = (float)nDisPlayProgress / 100;
                lodingNum.text = (m_pProgress.value*100).ToString() + "%";
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
        progress = 100;
        while (nDisPlayProgress < progress)
        {
            ++nDisPlayProgress;
            m_pProgress.value = (float)nDisPlayProgress / 100;
            lodingNum.text = (m_pProgress.value * 100).ToString() + "%";
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;

    }
}
