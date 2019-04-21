using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score1;
    public Text score2;
    public Text score3;

    void Start()
    {
        int score = ScoreManeger.score; //スコア：あとでスコアを取得できるようにする
        float meityu = (ScoreManeger.shotCount <= 0) ? 0 : ScoreManeger.hitCount / ScoreManeger.shotCount * 100; //命中率(%)：後で取得
        int hentai = (int)(score * meityu * 0.81 * 10000 / 877);
        score1.text = "スコア　・・・・・・　" + score.ToString();
        score2.text = "命中率　・・・・・・　" + ((int)meityu).ToString() + "%";
        score3.text = "変態性　" + hentai.ToString() + "\n" + ((meityu < 20) ? "ドM" : "ドS");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
