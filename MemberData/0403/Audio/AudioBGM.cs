using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGM : MonoBehaviour
{
    public AudioSource[] Source;                 //オーディオソース
    public int SoundNum;                        //音源番号

    void Start()
    {
        Source[SoundNum] = GetComponent<AudioSource>();
    }

    public void AudioBGMSet(int SoundNum, float Vol)//BGM再生用関数(再生したい音源番号,ボリューム 0.0f～1.0f)
    {
        Source[SoundNum].Play();      //音源再生
        Source[SoundNum].volume = Vol;                      //ボリューム
    }
    public void AudioBGMUnLoop()                    //BGMループ解除関数
    {
        Source[SoundNum].loop = Source[SoundNum].loop = false;
    }
}
/*
　 実装方法
  このスクリプトは空objectにつけてください。

  AudioBGMObj = GameObject.FindGameObjectWithTag("BGMManager");//BGMManager検索
  上記をStart設定し、音源を生成したい場所に
  AudioBGMObj.GetComponent<AudioBGM>().AudioBGMSet(1, 1.0f);
*/
