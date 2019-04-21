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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckWeapon();
    }

    private void CheckWeapon()
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            Debug.Log(weapon[i].RenderWeapon);
            if (weapon[i].RenderWeapon)
            {
                Debug.Log(i + "check");
                if (equipment == null)
                {
                    equipment = weapon[i];
                    IsEquip = true;
                    break;
                }
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
        ScoreManeger.shotCount++;
        equipment.PlayAnimation();
        RaycastHit hit;
        if (Physics.SphereCast(ARcamera.transform.position, equipment.raysize, ARcamera.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "target")
            {
                Debug.Log(hit.transform.gameObject);
                ScoreManeger.hitCount++;
                //敵への攻撃、animation呼び出し
                Transform hitTransform = hit.transform;
                while (hitTransform.parent.gameObject != null)
                {
                    if (hitTransform.parent.gameObject.GetComponent<target>())
                    {
                        hitTransform.parent.gameObject.GetComponent<target>().hitTarget(ref ScoreManeger.score);
                        Debug.Log("Score = " + ScoreManeger.score);
                        break;
                    }
                    else
                    {
                        hitTransform = hitTransform.parent;
                        Debug.Log("Next Parent");
                    }
                }
            }
        }
    }
}
