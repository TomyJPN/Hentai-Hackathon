using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    public static int score;
    public static float shotCount, hitCount;
    [SerializeField]
    private Text scoreText, timeText;
    [SerializeField]
    private GameManeger gameManeger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreView();
    }

    void ScoreView()
    {
        scoreText.text = score.ToString();
        if (gameManeger.GameState == State.isgame)
        {
            timeText.text = gameManeger.GetTimeCount().ToString() + "s";
        }
    }

    public static void ResetScore()
    {
        score = 0;
        shotCount = 0;
        hitCount = 0;
    }
}
