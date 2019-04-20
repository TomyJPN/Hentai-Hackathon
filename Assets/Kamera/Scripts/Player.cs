using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject ARcamera, equipment;
    [SerializeField]
    private GameObject[] weapon = new GameObject[3];

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnShot()
    {
        RaycastHit hit;
        if (Physics.Raycast(ARcamera.transform.position, ARcamera.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "target")
            {
                //敵への攻撃、animation呼び出し
                while (hit.transform.parent)
                {
                    if (hit.transform.parent.gameObject.GetComponent<target>())
                    {
                        hit.transform.parent.gameObject.GetComponent<target>().hitTarget(ref score);
                        break;
                    }
                    else
                    {
                        Debug.Log("Next Parent");
                    }
                }
                Debug.Log(score);
            }
        }
    }
}
