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
    [SerializeField]
    private Stage stage;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.wait);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState == State.wait)
        {
            //最初はwait、Stage表示後にStartへ
            if (stage.RenderStage)
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
        Debug.Log(time);
        if (time <= 0)
        {
            return true;
        }
        return false;
    }

}
