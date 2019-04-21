using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : MonoBehaviour
{
    public static int score, shotCount, hitCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ResetScore()
    {
        score = 0;
    }
}
