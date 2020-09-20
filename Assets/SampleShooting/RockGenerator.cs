using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // スコア情報取得に必要

public class RockGenerator : MonoBehaviour
{
    public GameObject rockPrefab;
    public GameObject LifePrefab;
    float RockNumber;
    float RockTime;

    // Start is called before the first frame update
    void Start()
    {
        //隕石を１秒に１回生成するために、InvokeRepeating関数を使用
        //InvokeRepeating関数は
        //第一引数は関数を
        //第二引数は発生する秒数ごとに
        //第三引数は発射物の発射秒数
        //実行してくれる結構便利な関数
        //InvokeRepeating("GenRock", 1f, 2f);

        // 隕石の発射する秒数の初期設定
        RockTime = 1f;


    }

    // Update is called once per frame
    void Update()
    {
        // 隕石の発射秒数取得
        float New_RockNumber = GameObject.Find("Limit").GetComponent<Limit_level>().RockNumber;
        
        // 隕石の発射する発生秒数取得
        float New_RockTime = GameObject.Find("Limit").GetComponent<Limit_level>().RockTime;

        // ゲームオーバーとゲームクリアの文字取得
        string GameOverText = GameObject.Find("GameOver").GetComponent<Text>().text;

        // 隕石の発射秒数が変更した場合、変更秒数に設定する
        if (RockNumber != New_RockNumber)
        {
            Debug.Log("変更個数:"+ RockNumber);

            // 秒数の最新化
            this.RockNumber = New_RockNumber;

            // メゾットをリセット
            CancelInvoke("GenRock");

            // 隕石の発射
            InvokeRepeating("GenRock", RockTime, RockNumber);

        }

        // 隕石の発射する秒数が変更した場合、変更乗数に設定する
        if (RockTime != New_RockTime)
        {
            Debug.Log("変更秒数:" + RockNumber);

            // 秒数の最新化
            this.RockTime = New_RockTime;

            // メゾットをリセット
            CancelInvoke("GenRock");

            // 隕石の発射
            InvokeRepeating("GenRock", RockTime, RockNumber);
        }

        //ゲームが終了したら隕石を落さない
        if (GameOverText == "GameOver")
        {
            CancelInvoke("GenRock");
        }
        if (GameOverText == "GameClear!")
        {
            CancelInvoke("GenRock");
        }
    }

    //GenRock関数を呼び出し、その中でランダムな位置に隕石を生成する
    public void GenRock ()
    {
        Instantiate(rockPrefab, new Vector3(-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
    }

    //ランダムでライフ回復アイテムを生成    
    public void GenLife()
    {
        Instantiate(LifePrefab, new Vector3(-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
    }
}
