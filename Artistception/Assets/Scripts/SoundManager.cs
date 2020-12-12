using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]  public AudioSource[] AS;  // 0 bgm 1 bgs 2 se
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBGM(AudioClip _clip)
    {
        AS[0].clip = _clip;
        AS[0].Play();


    }  public void PlayBGS(AudioClip _clip,bool _loop)
    {
        AS[1].clip = _clip;
        AS[1].loop = _loop;
        AS[1].Play();


    }  public void PlaySE(AudioClip _clip, float _pitch)
    {
        ChangePitch(2, _pitch);
        AS[2].PlayOneShot(_clip,5f);


    }public void PlaySE(AudioClip _clip, float _pitch, float volume)
    {
        ChangePitch(2, _pitch);
        AS[2].PlayOneShot(_clip,volume);


    }
    public void ChangePitch(int num, float _pitch) {
        AS[num].pitch = _pitch;
    }
   
}
