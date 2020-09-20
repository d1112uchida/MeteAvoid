using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;     //Google広告表示用

public class GoogleAds : MonoBehaviour
{

    private InterstitialAd interstitial;


    bool is_close_interstitial = false;
    private int reShowCount;

    void Awake()
    {
        reShowCount = 0;

        RequestInterstitial();
    }

    // Start is called before the first frame update
    void Start()
    {
        //RequestInterstitial();
    }

    public void RequestInterstitial()
    {

        //広告ID
        string adUnitId = "ca-app-pub-6626712205509052/9954230735";
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";    //テスト用
//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
//#else
//        string adUnitId = "unexpected_platform";
//#endif


        if (is_close_interstitial == true)
        {
            interstitial.Destroy();
        }

        // InterstitialAdを初期化します。
        this.interstitial = new InterstitialAd(adUnitId);

        // 空の広告リクエストを作成します。(ランタイムの情報(ターゲティング情報など)を保持しておく)
        AdRequest request = new AdRequest.Builder().Build();

        // リクエストでインタースティシャルを読み込みます。
        this.interstitial.LoadAd(request);

        is_close_interstitial = false;
    }

    public void Advertis()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            reShowCount = 0;
        } else
        {

            if (reShowCount < 10)
            {
                Invoke("InterstitialShow", 0.1f);
                reShowCount++;
            }
            else
            {
                reShowCount = 0;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
