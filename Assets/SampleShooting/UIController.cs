using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;  //シーン操作

public class UIController : MonoBehaviour
{
    //public GameObject EndBackground;    //ブラック画面オブジェクト格納
    [SerializeField] GameObject EndPanel;   //エンド画面のポップ

    public int score = 0;
    public int Life = 3;
    GameObject scoreText;
    GameObject gameOverText;
    GameObject LifePointText;
    GameObject RecordScoreText;
    GameObject NewText;



    //隕石が画面下のラインを超えたときにゲームオーバと判定する
    public void GameOver()
    {
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        //Instantiate(EndBackground);     //ブラック画面表示
        EndPanel.SetActive(true);       //エンド画面のポップ表示
        
        RecordScore();      //スコア保存

    }

    //スコアがカンストした場合ゲームクリアにする
    public void GameClear()
    {
        this.gameOverText.GetComponent<Text>().text = "GameClear!";
        //Instantiate(EndBackground);     //ブラック画面表示
        EndPanel.SetActive(true);       //エンド画面のポップ表示

        RecordScore();      //スコア保存

    }

    //ボタンでホーム画面遷移
    public void ChangeScene()
    {
        SceneManager.LoadScene("Title_Start");
    }

    //スコアの記録
    public void RecordScore()
    {
        // 保存値を取得
        int RecordScore = PlayerPrefs.GetInt("score");  //獲得スコア
        int hscore = PlayerPrefs.GetInt("hscore");      //ハイスコア
        int Twohscore = PlayerPrefs.GetInt("2hscore");  //2スコア
        int Threehscore = PlayerPrefs.GetInt("3hscore");    //3スコア


        if (RecordScore >= hscore)
        {
            //ハイスコア保存
            PlayerPrefs.SetInt("hscore", score);
            PlayerPrefs.SetInt("2hscore", hscore);  //2スコア更新

            //スコア更新
            this.NewText.GetComponent<Text>().text = "New Record";


        } 
        else if (RecordScore >= Twohscore)
        {
            //2スコア保存
            PlayerPrefs.SetInt("2hscore", score);
            PlayerPrefs.SetInt("3hscore", Twohscore);   //3スコア更新

        } 
        else if (RecordScore >= Threehscore)
        {
            //3スコア保存
            PlayerPrefs.SetInt("3hscore", score);
            
        }

        //Debug.Log("ハイスコア：" + hscore);
        //Debug.Log("2ハイスコア：" + Twohscore);
        //Debug.Log("3ハイスコア：" + Threehscore);

        this.RecordScoreText.GetComponent<Text>().text = "Score: " + RecordScore.ToString("D4");

    }

    //Add関数は弾と隕石が衝突したときに呼び出される関数で、この中でスコアの更新を行って
    public void AddScore()
    {
        this.score += 10;
    }

    // 隕石と衝突したら残機が減る
    public void SubLife()
    {
        this.Life -= 1;
    }

    // 隕石と衝突したら残機が減る
    public void AddLife()
    {
        this.Life += 1;
    }

    // Start is called before the first frame update
    //Start関数の中でシーンビューに配置したUIのText（Scoreテキスト）を検索し、メンバ変数に保存する
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
        this.gameOverText = GameObject.Find("GameOver");
        this.LifePointText = GameObject.Find("LifePoint");
        this.RecordScoreText = GameObject.Find("RecordScore");
        this.NewText = GameObject.Find("NewText");

        //残機確認用
        //Debug.Log(Life);

    }

    // Update is called once per frame
    //Update関数内でTextにスコアを代入する
    void Update()
    {
        if (this.gameOverText.GetComponent<Text>().text == "")
        {
            Debug.Log("ゲーム継続中");
            scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");
            LifePointText.GetComponent<Text>().text = "Life:" + Life.ToString("D2");
        }
        else
        {
            Debug.Log("ゲーム終了");
            scoreText.GetComponent<Text>().text = "";
            LifePointText.GetComponent<Text>().text = "";
        }

        

        // int型のスコア値を保存する
        PlayerPrefs.SetInt("score", score);


    }

    
}
