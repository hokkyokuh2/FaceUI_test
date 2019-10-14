using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NICO_touches_the_button : MonoBehaviour
{

    public GameObject sphere;
    public GameObject ColorChange;
    public GameObject LineRendererObject;
    public GameObject Ray;
    RayHit rayHit;
    LineRendererScript LineRendererScript;
    public bool timer = false;
    public float timeOut = 10.0f;
    private float timeElapsed=0.0f;
    int n = 0;


    // Start is called before the first frame update
    void Start()
    {
        StreamWriter sw = new StreamWriter(@"C:/Users/王　卓毅/Desktop\orbitLog/buttonScore.csv", true, System.Text.Encoding.GetEncoding("Shift_JIS"));
        sw.WriteLine("球,ボタン1,ボタン2,ボタン3,結果");
        sw.Close();
        LineRendererScript = LineRendererObject.GetComponent<LineRendererScript>();
        rayHit = Ray.GetComponent<RayHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer) {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= timeOut)
            {

                LineRendererScript.Drawing(n);
                rayHit.OrbitGoal();
                n++;
                timeElapsed = 0.0f;
                rayHit.drawingTrigger = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "button") {
            if (!timer) {
                timer = true;
            }
            StreamWriter sw = new StreamWriter(@"C:/Users/王　卓毅/Desktop\orbitLog/buttonScore.csv", true, System.Text.Encoding.GetEncoding("Shift_JIS"));
            if (other.GetComponent<Renderer>().material.color == sphere.GetComponent<Renderer>().material.color)
            {
                sw.Write("〇\r\n");
            }
            else {
                sw.Write("×\r\n");
            }
            sw.Close();
            colorchange colorchange = ColorChange.GetComponent<colorchange>();
            colorchange.Change();

        }
    }
}