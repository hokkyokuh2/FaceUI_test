using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class colorchange : MonoBehaviour
{

    public GameObject sphere;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Change()
    {
        StreamWriter sw = new StreamWriter(@"C:/Users/王　卓毅/Desktop\orbitLog/buttonScore.csv", true, System.Text.Encoding.GetEncoding("Shift_JIS"));
        float Srandom = Random.Range(0.0f, 6.0f);
        if (Srandom < 2.0f)
        {
            sphere.GetComponent<Renderer>().material.color = Color.red;
            sw.Write("赤,");
        }
        else if (Srandom >= 4.0f)
        {
            sphere.GetComponent<Renderer>().material.color = Color.green;
            sw.Write("緑,");
        }
        else {
            sphere.GetComponent<Renderer>().material.color = Color.blue;
            sw.Write("青,");
        }

        int Brandom = Random.Range(0,6);

        switch (Brandom) {
            case 0:
                button1.GetComponent<Renderer>().material.color = Color.red;
                button2.GetComponent<Renderer>().material.color = Color.blue;
                button3.GetComponent<Renderer>().material.color = Color.green;
                sw.Write("赤,青,緑,");
                break;

            case 1:
                button1.GetComponent<Renderer>().material.color = Color.red;
                button2.GetComponent<Renderer>().material.color = Color.green;
                button3.GetComponent<Renderer>().material.color = Color.blue;
                sw.Write("赤,緑,青,");
                break;

            case 2:
                button1.GetComponent<Renderer>().material.color = Color.blue;
                button2.GetComponent<Renderer>().material.color = Color.red;
                button3.GetComponent<Renderer>().material.color = Color.green;
                sw.Write("青,赤,緑,");
                break;

            case 3:
                button1.GetComponent<Renderer>().material.color = Color.blue;
                button2.GetComponent<Renderer>().material.color = Color.green;
                button3.GetComponent<Renderer>().material.color = Color.red;
                sw.Write("青,緑,赤,");
                break;

            case 4:
                button1.GetComponent<Renderer>().material.color = Color.green;
                button2.GetComponent<Renderer>().material.color = Color.red;
                button3.GetComponent<Renderer>().material.color = Color.blue;
                sw.Write("緑,赤,青,");
                break;

            case 5:
                button1.GetComponent<Renderer>().material.color = Color.green;
                button2.GetComponent<Renderer>().material.color = Color.blue;
                button3.GetComponent<Renderer>().material.color = Color.red;
                sw.Write("緑,青,赤,");
                break;

              
        }
        sw.Close();
    }
}
