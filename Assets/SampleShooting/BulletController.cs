using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //explosionPrefab変数にPrefabの実体を代入
    public GameObject explosionPrefab;   //爆発エフェクトのPrefab

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Translate関数を使って弾を毎フレーム0.2fづつ上方向（y軸方向）に移動する
        transform.Translate(0, 0.2f*2, 0);

        //見えない場所で動かし続けるのはCPUの無駄使いなので、
        //画面の上端（y=5）をこえた場合にはDestroyメソッドを使って弾を破棄する
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }

    }

    //OnTriggerEnter2D関数の中でDestroy関数を使って隕石と弾のオブジェクトを破棄する
    void OnTriggerEnter2D(Collider2D coll)
    {

        //Debug.Log(coll.gameObject.name);

        //衝突物がロケット以外の場合、消滅させる
        if (coll.gameObject.name != "rocket")
        {


            // 衝突したときにスコアを更新する
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

            // 爆発エフェクトを生成する
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // 岩オブジェクトの消滅
            Destroy(coll.gameObject);
            // 球オブジェクトの消滅
            Destroy(gameObject);

        }
    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    Debug.Log(other.gameObject.tag);

    //    //if (other.gameObject.tag == "RockPrefab")
    //    //{
    //    //    Destroy(gameObject);
    //    //}
    //}
}
