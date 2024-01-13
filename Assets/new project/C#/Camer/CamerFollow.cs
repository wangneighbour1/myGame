using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null){
            if(transform.position!= target.position){
                Vector3 targetPos = target.position;
                transform.position = Vector3.Lerp(transform.position,targetPos,smoothing);
            }
        }
    }

    public void Shake(){
        Anim.SetTrigger("Shake");    
    }
}
