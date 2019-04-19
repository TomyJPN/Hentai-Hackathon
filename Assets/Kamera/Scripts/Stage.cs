using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private Collider col;
    public bool RenderStage { get; private set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (col.enabled) { RenderStage = true; }
        else { RenderStage = false; }
        Debug.Log(RenderStage);
    }
}
