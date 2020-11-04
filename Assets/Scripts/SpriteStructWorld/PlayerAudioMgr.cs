using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioMgr : MonoBehaviour
{
    public void PlayAttack1Audio()
    {
        AudioManager.audioManager.PlaySoundOneShot("attack1");
    }
    public void PlayAttack2Audio()
    {
        AudioManager.audioManager.PlaySoundOneShot("attack2");
    }
    public void PlayAttack3Audio()
    {
        AudioManager.audioManager.PlaySoundOneShot("attack3");
    }
    public void PlayAttack4Audio()
    {
        AudioManager.audioManager.PlaySoundOneShot("attack4");
    }
}
