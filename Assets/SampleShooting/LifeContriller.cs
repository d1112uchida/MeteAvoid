using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 残機情報取得の為に必要

public class LifeContriller : MonoBehaviour
{

    float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 停止ボタン情報取得
        bool is_Stop = GameObject.Find("StopButton").GetComponent<ButtonScript>().is_Stop;

        // ゲームオーバーとゲームクリアの文字取得
        string GameOverText = GameObject.Find("GameOver").GetComponent<Text>().text;

        // アイテムの停止処理
        if (is_Stop == true)
        {
            // ランダムに表示し-0.05f下に下がりずつ移動する
            transform.Translate(0, 0, 0, Space.World);
            is_Stop = false;

        }
        else
        {
            // ランダムに表示し-0.05f下に下がりずつ移動する
            transform.Translate(0, -0.05f, 0, Space.World);
            is_Stop = true;
        }

        
        // 画面外の停止処理
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }

        //ゲームが終了したら隕石を落さない
        if (GameOverText == "GameOver")
        {
            Destroy(gameObject);
        }
        if (GameOverText == "GameClear!")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Debug.Log(coll.gameObject.name);

        if (coll.gameObject.name == "rocket")
        {
            // 残機数を取得
            string LifeScore = GameObject.Find("LifePoint").GetComponent<Text>().text;

            //ライフ残数確認
            //Debug.Log(LifeScore.Substring(3,2));

            Destroy(gameObject);


            if (LifeScore.Substring(3, 2) != "99")
            {
                // 残機数を減らす処理
                GameObject.Find("Canvas").GetComponent<UIController>().AddLife();
            }

                
        }
    }

}
