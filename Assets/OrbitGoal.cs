using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OrbitGoal : MonoBehaviour
{

    public GameObject rayhit;
    public GameObject LineObject;
    LineRendererScript LineRenderScript;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderScript = LineObject.GetComponent<LineRendererScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

  
    private void OnTriggerEnter(Collider other)
    {
        RayHit script = rayhit.GetComponent<RayHit>();
        if (other.gameObject.tag == "goal")
        {
            script.OrbitGoal();
            LineRenderScript.Drawing(9);
            script.drawingTrigger = false;
        }
    }
}
