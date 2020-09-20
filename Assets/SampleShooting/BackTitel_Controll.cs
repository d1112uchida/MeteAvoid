using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;  //シーン操作
using UnityEngine.EventSystems;

public class BackTitel_Controll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    return;

        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("スタート画面タップ");
        //    Invoke("ChangeScene", 1.5f);
        //}
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
