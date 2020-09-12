using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSE : MonoBehaviour
{
    public AudioClip[] Sound;                   //音源配列
    private AudioSource Source;                 //オーディオソース
    public int SoundNum;                        //音源番号

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    public void AudioSESet(int SoundNum, float Vol)//サウンドエフェクト用関数(再生したい音源番号,ボリューム 0.0f～1.0f)
    {
        Source.PlayOneShot(Sound[SoundNum]);      //音源再生
        Source.volume = Vol;                      //ボリューム
    }
}
/*
　 実装方法
  このスクリプトは空objectにつけてください。

  AudioSEObj = GameObject.FindGameObjectWithTag("SEManager");//SEManager検索
  上記をStart設定し、音源を生成したい場所に
  AudioSEObj.GetComponent<AudioSE>().AudioSESet(1, 1.0f);
*/