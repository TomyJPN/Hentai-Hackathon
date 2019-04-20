using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class next_scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //シーン遷移
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene ("SampleScene");
        }
    }
}
