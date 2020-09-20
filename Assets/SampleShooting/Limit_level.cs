using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // スコア情報取得に必要

public class Limit_level : MonoBehaviour
{


    public int ScorePoint_Limit;
    public int ScorePoint_Limit_RockNumber;
    public float Speed;
    public float old_Speed;
    public float RockNumber;
    public float RockTime;
    public float Background;

    int Life_Limit;

    // Start is called before the first frame update
    void Start()
    {
        ScorePoint_Limit = 500;  //初期スコアライン
        ScorePoint_Limit_RockNumber = 1000; //初期スコアライン個数速度

        Speed = 0.1f;   //初期早い速度
        old_Speed = 0.05f;  //初期遅い速度

        RockNumber = 0.6f;    //初期個数速度
        RockTime = 1f;  //初期発射速度
        
        Background = 0.03f; //初期背景速度

        Life_Limit = 100; //初期回復アイテム

    }

    // Update is called once per frame
    void Update()
    {
        //string Score = GameObject.Find("Score").GetComponent<Text>().text;
        float ScorePoint = GameObject.Find("Canvas").GetComponent<UIController>().score;    //スコア数取得
        //float ScorePoint = float.Parse(Score.Substring(6));

        Debug.Log("速さ：" + Speed + " 遅い：" + old_Speed + " 個数：" + RockNumber + " 秒数:" + RockTime + " 背景:" + Background + " ライフ:" + Life_Limit);

        //スコアラインに到達したら各速度を変更する
        if (ScorePoint == ScorePoint_Limit)
        {
            Debug.Log("値変更:"+ ScorePoint_Limit);
            this.ScorePoint_Limit += 500;   //スコアライン追加

            this.Speed += 0.01f;            //早い速度追加
            this.old_Speed += 0.01f;        //遅い速度追加

            this.Background += 0.01f;       //背景速度追加

        }

        //スコアが1000ずつ取ると隕石の個数速度を増やす
        if (ScorePoint == ScorePoint_Limit_RockNumber)
        {
            this.ScorePoint_Limit_RockNumber += 1000; //スコアライン個数速度追加
            //個数速度限界値の確認
            if (RockNumber > 0.3f)
            {
                    
                this.RockNumber -= 0.05f;    //個数速度減速


            }
            else if (RockTime > 0.2f)       //発射速度限界値の確認
            //if (RockTime > 0.2f)       //発射速度限界値の確認
            {
                this.RockTime -= 0.1f;      //発射速度減速
            }
        }
            

        // 回復アイテム出現
        if (ScorePoint == Life_Limit)
        {
            GameObject.Find("GameObject").GetComponent<RockGenerator>().GenLife();

            Life_Limit += 100;
        }

    }
}
