using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    wait, start, isgame, end
}

public class GameManeger : MonoBehaviour
{
    public State GameState { get; private set; }
    float startTime = 3, gameTime = 10, count;
    [SerializeField]
    private Stage stage;
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.wait);
        ScoreManeger.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState == State.wait)
        {
            Debug.Log(stage.RenderStage);
            Debug.Log(player.IsEquip);
            //最初はwait、Stage表示後にStartへ
            if (stage.RenderStage && player.IsEquip)
            {
                count = startTime;
                ChangeState(State.start);
            }
        }
        if (GameState == State.start)
        {
            StartCount();
            Debug.Log(count);
        }
        if (GameState == State.isgame)
        {
            GameTimeCount();
        }
        if (GameState == State.end)
        {
            SceneManager.LoadScene("Result");
        }
    }

    void ChangeState(State s)
    {
        GameState = s;
    }

    void StartCount()
    {
        if (TimeCount(ref count))
        {
            ChangeState(State.isgame);
            count = gameTime;
        }
    }

    void GameTimeCount()
    {
        if (TimeCount(ref count))
        {
            ChangeState(State.end);
            count = startTime;
        }
    }

    public int GetTimeCount()
    {
        return (int)count;
    }

    bool TimeCount(ref float time)
    {
        time -= Time.deltaTime;
        Debug.Log(time);
        if (time <= 0)
        {
            return true;
        }
        return false;
    }

}
