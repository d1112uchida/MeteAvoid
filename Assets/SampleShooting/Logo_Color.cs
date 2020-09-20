using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //シーン操作

public class Logo_Color : MonoBehaviour
{

    GameObject LogoText;
    float RGB;

    // Start is called before the first frame update
    void Start()
    {
        this.LogoText = GameObject.Find("LogoText");

        this.RGB = 0;

        // Textコンポーネントを取得
        Text text = this.LogoText.GetComponent<Text>();
        // 色を指定
        text.color = new Color(RGB / 255f, RGB / 255f, RGB / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        Text text = this.LogoText.GetComponent<Text>();

        this.RGB += 2;
        text.color = new Color(RGB / 255f, RGB / 255f, RGB / 255f);

        if (RGB >= 255)
        {
            Invoke("ChangeScene", 2f);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Title_Start");
    }
}
