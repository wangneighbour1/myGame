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
    private playerHealth playerHealth;

    public GameObject bloodEffect;
    // Start is called before the first frame update
    protected void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
    }

    // Update is called once per frame
    protected void Update()
    {   
    }

    public void TakeDamage(int damage){
        health -= damage;
        FlashColor(flashTime);
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

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            if(playerHealth != null)
            playerHealth.damagePlayer(mydamage);
        }
    }

}
