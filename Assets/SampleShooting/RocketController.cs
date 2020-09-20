using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 残機情報取得の為に必要

public class RocketController : MonoBehaviour
{
    float Rocket;

    public GameObject explosionPrefab;   //爆発エフェクトのPrefab

    //bulletPrefabの枠あける
    public GameObject bulletPrefab;

    //オブジェクトの位置の設定
    //private Vector2 targetpos;

    int player_Move = 1;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトのスタート位置取得
        //targetpos = transform.position;

        Rocket = 0.07f;

    }

    // Update is called once per frame
    void Update()
    {
        // 自動で左右移動
        //transform.position = new Vector2(Mathf.Sin(Time.time) * 1.0f + targetpos.x, targetpos.y);

        //Input.GetKey関数を使って引数に指定したキーが押されているかを調べる
        //Translate関数を使ってロケットの位置を移動させる
        //Translate関数は現在の位置から引数に与えたぶんだけ移動させる関数
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(-0.1f, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(0.1f, 0, 0);
        //}

        // 停止ボタン情報取得
        bool is_Stop = GameObject.Find("StopButton").GetComponent<ButtonScript>().is_Stop;

        // ロケットの停止処理
        if (is_Stop == true)
        {
            Rocket = 0;
            //mButton.Text = "STOP";
            //Debug.Log("is_stop");
            is_Stop = false;

        }
        else
        {
            //transform.Translate(-Rocket, 0, 0);
            Rocket = 0.07f;
            //mButton.Text = "RESUME";
            //Debug.Log("is_resume");
            is_Stop = true;
        }

        if (player_Move == 1)
        {
            transform.Translate(-Rocket, 0, 0);
            //player_Move = 3;
        }
        else if (player_Move == 2)
        {
            transform.Translate(Rocket, 0, 0);

        }
        else if (player_Move == 3)
        {
            transform.Translate(Rocket, 0, 0);

        }
        else if (player_Move == 4)
        {
            transform.Translate(-Rocket, 0, 0);
        }
        //else if (player_Move == 5)
        //{
        //    transform.Translate(0, 0, 0);
        //}
        //else if (player_Move == 6)
        //{
        //    transform.Translate(-Rocket, 0, 0);
        //}

        //PlayControl();

        //GetKeyDown関数を使ってスペースキーが押されたことを検知する
        //GetKeyDown関数はGetKey関数と違って、キーが押下された時に一度だけtrueになる関数
        //if (Input.GetKeyDown(KeyCode.Space))  //スペースキー判定
        if (Input.GetMouseButtonDown(0))    //画面タップ判定
        {
            // プレイヤーの移動方向変更フラグ
            if (player_Move == 1)
            {
                player_Move = 3;

            } else if (player_Move == 2)
            {
                player_Move = 4;

            } else if (player_Move == 3)
            {
                player_Move = 1;

            } else if (player_Move == 4)
            {
                player_Move = 2;
            }


            //弾のPrefabからインスタンスを作るために、Instantiate関数を使用
            //Instantiate関数は、
            //第一引数にPrefab、
            //第二引数にインスタンスを生成する位置、
            //第三引数にはインスタンスの回転角を指定
            //ここではRocketControllerの中でtransform.positionと書いているので、ロケットの位置に弾を生成する
            //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        
    }

    //OnTriggerEnter2D関数の中でDestroy関数を使って隕石とロケットのオブジェクトを破棄する
    void OnTriggerEnter2D(Collider2D coll)
    {

        //Debug.Log(coll.gameObject.name);

        if (coll.gameObject.name == "RockPrefab(Clone)")
        {

            // 残機数を取得
            //string LifeScore = GameObject.Find("LifePoint").GetComponent<Text>().text;
            int Life = GameObject.Find("Canvas").GetComponent<UIController>().Life;

            //ライフ残数確認
            //Debug.Log(LifeScore.Substring(3,2));

            // 残機が1の場合、ロケットを消滅させる
            // 残機が1でない場合、残機を1減らす
            //if (LifeScore.Substring(3, 2) == "01")
            if (Life == 1)
            {

                // 爆発エフェクトを生成する
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                // 隕石を消滅
                Destroy(coll.gameObject);


                // ロケットを消滅
                Destroy(gameObject);

                // GameOver関数を呼び出し、残機が無くなった場合ゲームオーバーにする
                GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

                //GameObject.Find("GameObject").GetComponent<GoogleAds>().Advertis();

            }

            // 残機数を減らす処理
            GameObject.Find("Canvas").GetComponent<UIController>().SubLife();

            // 爆発エフェクトを生成する
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // 隕石を消滅
            Destroy(coll.gameObject);

        }

        if (coll.gameObject.name == "floor_right")
        {
            player_Move = 1;

        } else if (coll.gameObject.name == "floor_left")
        {
            player_Move = 2;
        }

    }

    //void PlayControl()
    //{
    //    if (player_Move == 1)
    //    {
    //        transform.Translate(-Rocket, 0, 0);
    //        //player_Move = 3;
    //    }
    //    else if (player_Move == 2)
    //    {
    //        transform.Translate(Rocket, 0, 0);

    //    }
    //    else if (player_Move == 3)
    //    {
    //        transform.Translate(Rocket, 0, 0);

    //    }
    //    else if (player_Move == 4)
    //    {
    //        transform.Translate(-Rocket, 0, 0);
    //    }
    //}
}
