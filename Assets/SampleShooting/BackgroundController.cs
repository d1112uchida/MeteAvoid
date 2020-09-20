using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    float Background;

    // Start is called before the first frame update
    void Start()
    {
        //Background = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        float New_Background = GameObject.Find("Limit").GetComponent<Limit_level>().Background;

        // 停止ボタン情報取得
        bool is_Stop = GameObject.Find("StopButton").GetComponent<ButtonScript>().is_Stop;

        // 隕石の停止処理
        if (is_Stop == true)
        {
            //毎フレーム背景を下方向に0.02ずつ移動
            //transform.Translate(0, -2f, 0);
            transform.Translate(0, 0, 0);
            is_Stop = false;

        }
        else
        {
            //毎フレーム背景を下方向に0.02ずつ移動
            //transform.Translate(0, -2f, 0);
            transform.Translate(0, -New_Background, 0);
            is_Stop = true;
        }

        
        
        //背景速度確認
        //Debug.Log(-Background);

        //スクロールしていき、背景画像の座標が一定値以上小さくなったときに、元の位置に戻す
        if (transform.position.y < -4.9f)
        {
            transform.position = new Vector3(0, 4.9f, 0);
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

}
