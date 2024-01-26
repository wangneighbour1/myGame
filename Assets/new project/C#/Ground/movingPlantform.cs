using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class movingPlantform : MonoBehaviour
{
    public float Speed;
    private float waitTime;
    public Transform[] movePos;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i=1;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,movePos[i].position,Speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,movePos[i].position)< 0.1 && waitTime<=0){
            if(i==1) i=0;
            else i=1;
            waitTime = 0.5f;
        }
    }


    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            if(Input.GetKey("s")&&Input.GetKeyDown("space")){//如果按下S
                other.gameObject.GetComponent<CapsuleCollider2D>().isTrigger =true;
            }
            if(other.GetType().ToString()=="UnityEngine.BoxCollider2D")
            other.transform.position = Vector2.MoveTowards(other.transform.position,movePos[i].position,Speed * Time.deltaTime);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag=="Player" && other.GetType().ToString()=="UnityEngine.CapsuleCollider2D"){
            other.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }
}
