using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    [SerializeField]
    private GameObject equipment;
    [SerializeField]
    private GameObject[] weapon = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnShot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                //敵への攻撃、animation呼び出し
                Debug.Log("hit!");
            }
        }
    }
}
