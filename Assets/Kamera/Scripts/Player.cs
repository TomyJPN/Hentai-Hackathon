using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject ARcamera;
    [SerializeField]
    private Weapon[] weapon = new Weapon[3];
    private Weapon equipment;
    public bool IsEquip { get; private set; }

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWeapon();
    }

    private void CheckWeapon()
    {
        foreach (var item in weapon)
        {
            if (item.RenderWeapon)
            {
                if (equipment == null)
                {
                    equipment = item;
                    break;
                }
            }
            if (equipment != null)
            {
                IsEquip = false;
                equipment = null;
            }
        }
    }

    public void OnShot()
    {
        if (equipment == null)
        {
            Debug.Log("equipment is null");
            return;
        }
        RaycastHit hit;
        if (Physics.SphereCast(ARcamera.transform.position, equipment.raysize, ARcamera.transform.forward, out hit, Mathf.Infinity))
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

    public int GetScore()
    {
        return score;
    }
}
