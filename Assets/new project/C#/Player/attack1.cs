using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1 : MonoBehaviour
{
    public int mydamage;
     private Animator anim;
     private PolygonCollider2D coll2D;
     private float attack1cd;
    // Start is called before the first frame update
    void Start()
    {
        attack1cd = 0.0f;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.isGameover){
            Attack1();
        }
    }

    void Attack1(){
        attack1cd -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && attack1cd<=0){
            anim.SetTrigger("attack1");
            attack1cd = 0.4f;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("enemy")) 
        {
            other.GetComponent<enemy>().TakeDamage(mydamage);
        }
    }

}
