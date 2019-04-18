using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    wait, start, isgame, end
}

public class GameManeger : MonoBehaviour
{
    public State GameState { get; private set; }
    float startTime = 3, gameTime = 60, count;
    bool isARView;//AR用の画像が移っているかの判定用のbool(いらないかも)
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.start);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState == State.wait)
        {
            //最初はwait、Stage表示後にStartへ
            ChangeState(State.start);
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

    bool TimeCount(ref float time)
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            return true;
        }
        return false;
    }

}
