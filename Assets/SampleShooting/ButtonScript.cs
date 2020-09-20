using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //シーン操作

public class ButtonScript : MonoBehaviour
{
    //public dfButton mButton;
    public bool is_Stop = false;

    public float PlayerStop = 0;

    [SerializeField] GameObject PausePanel;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        
        if (is_Stop == false)
        {
            Time.timeScale = 0.0f;
            PlayerStop = 0;
            Debug.Log("is_resume");
            is_Stop = true;
            PauseSet();
        }

    }

    public void PauseSet()
    {
        PausePanel.SetActive(true);

    }

    public void PlayButton()
    {
        Debug.Log("起動");
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        PlayerStop = 1;
        Debug.Log("is_stop");
        is_Stop = false;
    }

    public void TitleButton()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        PlayerStop = 1;
        Debug.Log("is_stop");
        is_Stop = false;
        SceneManager.LoadScene("Title_Start");
    }

}
