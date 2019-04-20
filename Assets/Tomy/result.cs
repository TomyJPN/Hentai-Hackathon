using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour {
  // Start is called before the first frame update
  public Text score1;
  public Text score2;
  public Text score3;

  void Start() {
    int score= 555; //スコア：あとでスコアを取得できるようにする
    int meityu = 99; //命中率(%)：後で取得
    int hentai = (int)(score*meityu*0.01); 
    score1.text = "スコア　・・・・・・　"+score.ToString();
    score2.text = "命中率　・・・・・・　" + meityu.ToString() + "%";
    score3.text = "変態性　" + hentai.ToString();
  }

  // Update is called once per frame
  void Update() {

  }

  public void goTitle() {
    SceneManager.LoadScene("TitleScene");
  }
}
