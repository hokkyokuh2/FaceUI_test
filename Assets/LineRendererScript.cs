using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LineRendererScript : MonoBehaviour {

	public Transform trans1;
	public Transform trans2;
    public GameObject touch_button;
    NICO_touches_the_button nICO_Touches_The_Button;
    LineRenderer render1;
    LineRenderer render2;
    LineRenderer render3;
    LineRenderer render4;
    LineRenderer render5;
    LineRenderer render6;
    LineRenderer render7;
    LineRenderer render8;

    // Use this for initialization
    void Start()
	{
        nICO_Touches_The_Button = touch_button.GetComponent<NICO_touches_the_button>();
        trans1.position = new Vector3(1, 1, 3);
        trans2.position = new Vector3(-2, 3, 2);

        StreamWriter sw1 = new StreamWriter(@"C:/Users/王　卓毅/Desktop/Resources/orbit12-P.csv", true);
        trans1.position = new Vector3(1, 2, 3);
        trans2.position = new Vector3(0, 1, 3);
        render8 = GetComponent<LineRenderer>();
        render8.positionCount = 42;
        render8.SetPosition(0, trans1.position);
        for (int i = 1; i <= 40; i++)
        {
            Vector3 pos = new Vector3(0 + Mathf.Cos(3 * Mathf.PI * i / 84), 2 + Mathf.Sin(3 * Mathf.PI * i / 84), 3);
            render8.SetPosition(i, pos);
            sw1.WriteLine(pos.x + "," + pos.y + "," + pos.z);
        }
        render8.SetPosition(41, trans2.position);
        sw1.Close();

    }

	// Update is called once per frame
	void Update()
	{
        enabled = false;
	}

	 public void Drawing(int n) {
		switch (n) {
               
            case 0:
				trans1.position=new Vector3(-2,1,3);
				trans2.position = new Vector3(2, 1, 3);
				 render1 = GetComponent<LineRenderer>();
				render1.positionCount = 2;
				render1.SetPosition(0, trans1.position);
				render1.SetPosition(1, trans2.position);
                nICO_Touches_The_Button.timeOut = 30.0f;

                break;

			case 1:
				trans1.position = new Vector3(1, 1, 2);
				trans2.position = new Vector3(-1, 3, 4);
				 render2 = GetComponent<LineRenderer>();
				render2.positionCount = 2;
				render2.SetPosition(0, trans1.position);
				render2.SetPosition(1, trans2.position);
			
				break;

			case 2:
				trans1.position = new Vector3(-2, 3, 3);
				trans2.position = new Vector3(1, 1, 3);
				 render3 = GetComponent<LineRenderer>();
				render3.positionCount = 3;
				render3.SetPosition(0, trans1.position);
                render3.SetPosition(1, new Vector3(-2, 1, 3));
				render3.SetPosition(2, trans2.position);
				
				break;

            case 3:
                trans1.position = new Vector3(-2, 1, 2);
                trans2.position = new Vector3(2, 1, 2);
              render4 = GetComponent<LineRenderer>();
                render4.positionCount = 3;
                render4.SetPosition(0, trans1.position);
                render4.SetPosition(1, new Vector3(0, 1, 4));
                render4.SetPosition(2, trans2.position);
              
                break;

            case 4:

               StreamWriter sw = new StreamWriter(@"C:/Users/王　卓毅/Desktop\orbitLog/orbit10.csv", true);
                trans1.position = new Vector3(-2, 3, 4);
                trans2.position = new Vector3(2, 3, 4);
               render5 = GetComponent<LineRenderer>();
                render5.positionCount = 42;
                render5.SetPosition(0, trans1.position);
                for (int i = 1; i <= 40; i++)
                {
                    Vector3 pos = new Vector3(-2 + 0.1f * i, 0.5f * Mathf.Pow(0.1f * i - 2.0f, 2) + 1, 4);
                    render5.SetPosition(i, pos);
                    sw.WriteLine(pos.x + "," + pos.y + "," + pos.z);

                }
                render5.SetPosition(41, trans2.position);
                sw.Close();
               
                break;

            case 5:
                trans1.position = new Vector3(2, 3, 2);
                trans2.position = new Vector3(-2, 1, 2);
                render6 = GetComponent<LineRenderer>();
                render6.positionCount = 5;
                render6.SetPosition(0, trans1.position);
                render6.SetPosition(1, new Vector3(2, 3, 4));
                render6.SetPosition(2, new Vector3(2, 1, 4));
                render6.SetPosition(3, new Vector3(-2, 1, 4));
                render6.SetPosition(4, trans2.position);
              
                break;

            case 6:
                trans1.position = new Vector3(-2, 1, 2);
                trans2.position = new Vector3(2, 3, 2);
               render7 = GetComponent<LineRenderer>();
                render7.positionCount = 4;
                render7.SetPosition(0, trans1.position);
                render7.SetPosition(1, new Vector3(0, 3, 4));
                render7.SetPosition(2, new Vector3(2, 1, 2));
                render7.SetPosition(3, trans2.position);
              
                break;

            case 7:
               StreamWriter sw1 = new StreamWriter(@"C:/Users/王　卓毅/Desktop\orbitLog/orbit20.csv", true);
                trans1.position = new Vector3(1, 2, 1);
                trans2.position = new Vector3(-1, 2, 4);
                render8 = GetComponent<LineRenderer>();
                render8.positionCount = 42;
                render8.SetPosition(0, trans1.position);
                for (int i = 1; i <= 40; i++)
                {
                    Vector3 pos = Vector3.Slerp(trans1.position, trans2.position, (float)i / 41f);
                    render8.SetPosition(i, pos);
                    sw1.WriteLine(pos.x+","+ pos.y+","+ pos.z);
                }
                render8.SetPosition(41, trans2.position);
                sw1.Close();
              
                break;

            case 8:
                nICO_Touches_The_Button.timer = false;
                trans1.position = new Vector3(0, 1, -3);
                trans2.position = new Vector3(0, 2, -3);
                break;

            case 9:
            
                trans1.position = new Vector3(0, 1, 3);
                trans2.position = new Vector3(0, 2, -3);
                LineRenderer render9 = GetComponent<LineRenderer>();
                render9.positionCount = 1;
                render9.SetPosition(0, trans1.position);
                break;

            default:
                break;


        }
	}

	
}
