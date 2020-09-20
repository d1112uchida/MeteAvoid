using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UITitleController : MonoBehaviour
{
    GameObject hscoreText;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        //保存スコア取得
        int hscore = PlayerPrefs.GetInt("hscore");          //ハイスコア取得
        int Twohscore = PlayerPrefs.GetInt("2hscore");      //2ハイスコア取得
        int Threehscore = PlayerPrefs.GetInt("3hscore");    //3ハイスコア取得

        this.hscoreText = GameObject.Find("hscore");

        if (hscore == 0)
        {
            PlayerPrefs.SetInt("hscore", 3500);
        }

        if (Twohscore == 0)
        {
            PlayerPrefs.SetInt("2hscore", 1500);
        }

        GameObject.Find("hscore").GetComponent<Text>().text = "High Score" + "\r\n" + hscore.ToString("D4");
        GameObject.Find("2hscore").GetComponent<Text>().text = "2 : " + Twohscore.ToString("D4");
        GameObject.Find("3hscore").GetComponent<Text>().text = "3 : " + Threehscore.ToString("D4");
    }
}
