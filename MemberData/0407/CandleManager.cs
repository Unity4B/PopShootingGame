using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    [SerializeField] GameObject CandlePrefab = null;
    [SerializeField] GameObject FirePrefab = null;
    GameObject Player;
    List<Vector3> candlePositions;  //炎配置用にロウソクの位置を記憶
    public int waveMax = 10; //最大ウェーブ数（10仮置き）
    /*public*/ int nowWave;  //現在のウェーブ数
    // Start is called before the first frame update
    void Start()
    {
        this.nowWave = 0; //0仮置き

        //Playerタグのオブジェクトを探す
        this.Player = GameObject.FindGameObjectWithTag("Player");

        //最大Wave数分ロウソクを生成
        this.candlePositions = new List<Vector3>();
        float angleDiff = 360.0f / waveMax;     //ロウソクごとの角度
        for (int c = 0; c < this.waveMax; c++)
        {
            //ロウソクを生成
            GameObject Candle;
            Candle = Instantiate(this.CandlePrefab);
            //プレイヤーの位置を中心にロウソクの生成位置を設定
            Vector3 candlePosition = Player.transform.position;
            //円状に設定
            float angle = (90.0f - angleDiff * c) * Mathf.Deg2Rad;
            candlePosition.x += 15.0f * Mathf.Cos(angle);
            candlePosition.y = 17;
            candlePosition.z += 15.0f * Mathf.Sin(angle);
            Candle.transform.position = candlePosition;
            Candle.name = this.CandlePrefab.name + (c + 1);
            //ロウソクの位置をList型配列に追加
            this.candlePositions.Add(candlePosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckWaveChange())
        {
            this.nowWave = GameManager.waveNowCnt;
            if (this.nowWave <= this.waveMax)    //ウェーブ数以上の回数は処理しない
            {
                Vector3 firePosition = candlePositions[nowWave - 1];
                firePosition.y += 5.0f;
                GameObject Fire;
                Fire = Instantiate(this.FirePrefab);
                Fire.transform.position = firePosition;
                Fire.name = this.FirePrefab.name + nowWave;
            }
        }
    }


    /// <summary>
    /// ウェーブが変わったかチェック
    /// 柄子
    /// </summary>
    /// <returns></returns>
    bool CheckWaveChange()
	{
        return GameManager.waveNowCnt != this.nowWave;
	}
}
