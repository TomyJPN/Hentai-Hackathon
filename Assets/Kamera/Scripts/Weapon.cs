using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Collider col;
    public float raysize = 0.5f;//Rayのサイズ
    public bool RenderWeapon { get; private set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (col.enabled) { RenderWeapon = true; }
        else { RenderWeapon = false; }
        Debug.Log(RenderWeapon);
    }
}
