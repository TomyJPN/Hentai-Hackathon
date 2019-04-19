using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class angle_Detection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //横画面固定
        switch (Screen.orientation) {
            // 縦画面のとき
            case ScreenOrientation.Portrait:
            // 左回転して左向きの横画面にする
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            break;
            // 上下反転の縦画面のとき
            case ScreenOrientation.PortraitUpsideDown:
            // 右回転して左向きの横画面にする
            Screen.orientation = ScreenOrientation.LandscapeRight;
            break;
        }

        //シーン遷移
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene ("SampleScene");
        }
        //if(Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        
        //    }
        //}
    }
}
