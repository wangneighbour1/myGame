using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : enemy
{
    public float moveSpeed;
    public float startWaitTime;
    private float waitTime;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRendomPos();
        if(movePos.position.x<transform.position.x){
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        else{
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position,movePos.position,moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position,movePos.position)<0.1f){
            if(waitTime <= 0){
                movePos .position = GetRendomPos();
                waitTime = startWaitTime;
                if(movePos.position.x<transform.position.x){
                    transform.localRotation = Quaternion.Euler(0,180,0);
                }
                else{
                    transform.localRotation = Quaternion.Euler(0,0,0);
                }
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRendomPos(){
        return  new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position.y,rightUpPos.position.y));
    }

}
