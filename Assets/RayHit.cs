using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class RayHit : MonoBehaviour
{
    //Rayの基本設定用
    public GameObject dive_Camera; //(VR用カメラとして使用させてもらっています)
    public GameObject reticle; //表示したい画像をアタッチ
    public GameObject target;
    public GameObject Neck;
    public GameObject ClearWallPrefab;
    private GameObject ClearWall;
    NICO_touches_the_button nICO;
    new Renderer renderer;
    Vector3 defaultPos;
    Quaternion defaultRotation;
    Vector3 defaultNeckRotation;
    Vector3 defaultNeckPos;
    Vector3 defaulttergetPos;
    public float rayDistance;
    public bool trigger=false;
	public bool Nflag = false;
    public bool drawingTrigger=false;
    public int orbitNumber = 1;



  
    void Start()
    {


        //Rayの初期化設定

       
        defaultPos = reticle.transform.localPosition;
        defaultRotation = reticle.transform.localRotation;
        renderer = target.GetComponent<TrailRenderer>();
        renderer.enabled = false;

    }

    void Update()
    {

       
            if (!trigger)
            {
                FaceVector();
            }
            else if (Nflag)
            {
                NeckOrbit();
            }
            else
            {
                ObjectVector();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //顔面ベクトルのモード切替
                trigger = true;
                target.transform.position = reticle.transform.position;
                renderer.enabled = true;
                reticle.transform.position = new Vector3(100f, 100f, 100f);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Nflag = true;
               

            }
        
    }

    void FaceVector() {
      
        //Rayの射出(VR用にdive_Cameraを使用しているがRayを生成すれば何でもよい)
        Ray ray = new Ray(dive_Camera.transform.position, dive_Camera.transform.forward);
        RaycastHit hit;

        //Rayが当たっているときの処理
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            //Rayの可視化（デバッグ用）
            Debug.DrawLine(dive_Camera.transform.position, hit.point, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);


            //Rayの位置・動作を決める部分
           reticle.transform.rotation = Quaternion.Slerp(reticle.transform.rotation, Quaternion.LookRotation(hit.normal), Time.deltaTime * 10.0f);
		  //reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
            reticle.transform.position = hit.point + (hit.normal * 0.01f); //hitRayPosition は画像が当たった対象にめり込まない程度に設定する

            //略
        }
        //デフォルトのRayの位置
        else
        {
            reticle.transform.localPosition = new Vector3(0, 0, defaultPos.z);
            reticle.transform.localRotation = defaultRotation;
        }
        if (drawingTrigger) {
            if (hit.collider.tag == "target")
            {
                if (Nflag) {
                    ClearWall = Instantiate(ClearWallPrefab) as GameObject;
                    ClearWall.transform.position = new Vector3(0, 5, hit.collider.gameObject.transform.position.z);
                    defaultNeckPos = Neck.transform.position;
                }
                    //顔面ベクトルのモード切替
                    trigger = true;
                    target.transform.position = hit.collider.gameObject.transform.position;
                    reticle.transform.position = new Vector3(100f, 100f, 100f);
                    renderer.enabled = true;
                
            }
        }
    }

    void ObjectVector() {
        bool LogFlag = false;

        StreamWriter sw = new StreamWriter(@"C:/Users/王　卓毅/Desktop\orbitLog/orbit"+orbitNumber+".csv", true);


        if (Input.GetKey(KeyCode.UpArrow)) {
			target.transform.position += new Vector3(0, 0.03f, 0);
            LogFlag = true; 
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			target.transform.position += new Vector3(0, -0.03f, 0);
            LogFlag = true;
        }
		if (Input.GetKey(KeyCode.RightArrow))
		{
			target.transform.position += new Vector3(0.03f, 0, 0);
            LogFlag = true;
        }
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			target.transform.position += new Vector3(-0.03f, 0, 0);
            LogFlag = true;
        }
		if (Input.GetKey(KeyCode.Z))
		{
			target.transform.position += new Vector3(0, 0, 0.03f);
            LogFlag = true;
        }
		if (Input.GetKey(KeyCode.X))
		{
			target.transform.position += new Vector3(0, 0, -0.03f);
            LogFlag = true;
        }
        if (LogFlag) {
            sw.WriteLine(target.transform.position.x + ", " + target.transform.position.y + ", " + target.transform.position.z);
        }
        sw.Close();

        
    }

	void NeckOrbit() {
        //  float distance = Vector3.Magnitude(defaulttergetPos - dive_Camera.transform.position);
        //  target.transform.position = defaulttergetPos+ new Vector3(distance*Mathf.Cos(dive_Camera.transform.forward.y-defaultNeckRotation.y)
        //     , distance * Mathf.Cos(dive_Camera.transform.forward.x - defaultNeckRotation.x)+Vector3.Magnitude(Neck.transform.position-defaultNeckPos)
        //      , distance * Mathf.Sin(dive_Camera.transform.forward.y - defaultNeckRotation.y)+ distance * Mathf.Sin(dive_Camera.transform.forward.x - defaultNeckRotation.x));
        StreamWriter sw = new StreamWriter(@"C:/Users/王　卓毅/Desktop\orbitLog/orbit" + orbitNumber + ".csv", true);
        Ray ray = new Ray(dive_Camera.transform.position, dive_Camera.transform.forward);
        RaycastHit hit;
        //Rayが当たっているときの処理
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            //Rayの可視化（デバッグ用）
            Debug.DrawLine(dive_Camera.transform.position, hit.point, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);


            //Rayの位置・動作を決める部分
            //reticle.transform.rotation = Quaternion.Slerp(reticle.transform.rotation, Quaternion.LookRotation(hit.normal), Time.deltaTime * 10.0f);
            //reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
            target.transform.position = hit.point + (hit.normal * 0.01f); //hitRayPosition は画像が当たった対象にめり込まない程度に設定する
            ClearWall.transform.position += new Vector3(0, 0, 5*(Neck.transform.position.z - defaultNeckPos.z));
                sw.WriteLine(target.transform.position.x + ", " + target.transform.position.y + ", " + target.transform.position.z);
            
            sw.Close();
            //略
        }

    }


   public void OrbitGoal()
    {
            if (trigger)
            {
            if (Nflag) {
                Destroy(ClearWall);
            }
                trigger = false;
            renderer.GetComponent<TrailRenderer>().Clear();
            renderer.enabled = false;
                target.transform.position = new Vector3(100f, 100f, 100f);
            }
        
    }

}
