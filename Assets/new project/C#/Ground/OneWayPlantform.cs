using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OneWayPlantform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            if(Input.GetKey("s")&&Input.GetKeyDown("space")){//如果按下S
                other.gameObject.GetComponent<CapsuleCollider2D>().isTrigger =true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="Player" && other.GetType().ToString()=="UnityEngine.CapsuleCollider2D"){
            other.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }
}
