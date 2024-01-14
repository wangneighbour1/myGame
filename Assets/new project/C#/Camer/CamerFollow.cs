using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Animator Anim;
    public Vector2 minPosition;
    public Vector2 maxPosition;

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
                targetPos.x  = Math.Clamp(targetPos.x,minPosition.x,maxPosition.x);
                targetPos.y = Math.Clamp(targetPos.y,minPosition.y,maxPosition.y);
                transform.position = Vector3.Lerp(transform.position,targetPos,smoothing);
            }
        }
    }
    public void SetCamPosLimit(Vector2 minPos,Vector2 maxPos){
        minPosition = minPos;
        maxPosition = maxPos;
    }

    public void Shake(){
        Anim.SetTrigger("Shake");    
    }
}
