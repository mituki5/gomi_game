//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Throw : MonoBehaviour
//{
//    public float Power = 0;
//    public GameObject Trash_box;
//    public GameObject Player;
//    public bool landing = true;
//    public bool shot = true;
//    public bool canShot = false;
//    public bool tugi = true;

//    private kinds kindScript;
//    private ThrowingPower throwingPowerScript;


//    public void SetScript(GameObject trashBox, kinds kind, bool canShot)
//    {
//        Trash_box = trashBox;
//        kindScript = kind;
//        this.canShot = canShot;
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (!this.canShot) return;
//        if (Power < 100f)
//        {
//            if (Input.GetMouseButton(0))
//            {
//                Power += 0.1f;
//                Debug.Log(Power + "‘‚¦‚Ä‚é");
//            }
//            if (Input.GetMouseButtonUp(0))
//            {
//                Debug.Log(Power + "•ú‚µ‚½");
//                throwingPowerScript.Throw();
//                //Gauge();

//                Power = 0;
//                landing = false;
//                shot = false;
//                tugi = false;
//            }
//        }
//    }
//}
