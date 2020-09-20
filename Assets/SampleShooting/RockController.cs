using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // スコア情報取得に必要

public class RockController : MonoBehaviour
{

    float fallSpeed;
    float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //int ScorePoint_Limit = GameObject.Find("Limit").GetComponent<Limit_level>().ScorePoint_Limit;
        ///Debug.Log(ScorePoint_Limit);

        float Speed = GameObject.Find("Limit").GetComponent<Limit_level>().Speed;
        //Debug.Log(Speed);

        float old_Speed = GameObject.Find("Limit").GetComponent<Limit_level>().old_Speed;
        //Debug.Log(old_Speed);

        //Randomメソッドを使って落下速度が隕石ごとに変わるようにする
        // 下に落ちる速度
        // this.fallSpeed = 0.01f + 0.1f * Random.value;
        this.fallSpeed = old_Speed + Speed * Random.value;
        // 回転する速度
        this.rotSpeed = 5f + 3f * Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        string GameOverText = GameObject.Find("GameOver").GetComponent<Text>().text;
        string ScoreText = GameObject.Find("Score").GetComponent<Text>().text;
        
        int score = GameObject.Find("Canvas").GetComponent<UIController>().score;

        //Debug.Log("スコア:" + score);

        // 停止ボタン情報取得
        bool is_Stop = GameObject.Find("StopButton").GetComponent<ButtonScript>().is_Stop;

        // 隕石の停止処理
        if (is_Stop == true)
        {
            // オブジェクトが移動する方向
            transform.Translate(0, 0, 0, Space.World);

            // オブジェクトの回転方向
            transform.Rotate(0, 0, 0);
            is_Stop = false;

        }
        else
        {
            // オブジェクトが移動する方向
            transform.Translate(0, -fallSpeed, 0, Space.World);

            // オブジェクトの回転方向
            transform.Rotate(0, 0, rotSpeed);
            is_Stop = true;
        }

        //隕石が回転しながら落下するようにTranslate関数とRotate関数を使用

        //ゲームが終了したら隕石を落さない
        if (GameOverText == "GameOver")
        {
            Destroy(gameObject);
        }
        if (GameOverText == "GameClear!")
        {
            Destroy(gameObject);
        }


        // 画面下端を超えたかどうか判定する
        if (transform.position.y < -5.5f)
        {
            //GameOver関数を呼び出し、画面下端を超えたかどうか判定する
            //Console.WriteLine("GameOver");
            //GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //隕石が画面下端を超えた場合は、Destroyメソッドで自分自身のオブジェクトを破棄する
            Destroy(gameObject);

            // GameOverが表示したらスコアのカウントを停止
            if (GameOverText != "GameOver")
            {
                if (score != 9990)
                {
                    //スコアの加算
                    GameObject.Find("Canvas").GetComponent<UIController>().AddScore();
                }
                else
                {
                    //ゲームクリア
                    GameObject.Find("Canvas").GetComponent<UIController>().GameClear();
                }
            }
            

            


        }

    }
}
