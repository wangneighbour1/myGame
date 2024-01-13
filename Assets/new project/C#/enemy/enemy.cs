using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemy : MonoBehaviour
{
    public float flashTime;
    private SpriteRenderer sr;
    private Color originColor;
    public int health;
    public int mydamage;

    public GameObject bloodEffect;
    // Start is called before the first frame update
    protected void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
    }

    // Update is called once per frame
    protected void Update()
    {   
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log(health);
        FlashColor(flashTime);
        GameObject.Find("CamerFollow").GetComponent<CamerFollow>().Shake();
        Instantiate(bloodEffect,transform.position,Quaternion.identity);
        if(health<=0){
            Destroy(gameObject);
        }
    }

    
    void FlashColor(float time){
        sr.color = Color.red;
        Invoke("ResetColor",time);
    }

    void ResetColor(){
        sr.color = originColor;
    }


}
