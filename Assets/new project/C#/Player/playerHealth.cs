using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class playerHealth : MonoBehaviour
{
    public int health;
    public Image red;
    public GameObject bloodEffect;
    private BoxCollider2D BoxCollider2D;
    private Renderer myRender;
    public int numLinks;
    public float seconds;
    private Animator Anim;
    public bool Death;
    private bool once;
    private bool damageEnable;
    // Start is called before the first frame update
    void Start()
    {
        once =true;
        damageEnable = true;
        HealthBar.healthMax = health;
        HealthBar.healthCourrent = health;
        myRender = GetComponent<Renderer>();
        Anim = GetComponent<Animator>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && once && BoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            once = false;
            Time.timeScale = 0.5f;
            Anim.SetTrigger("Death");
        }
        if(Death){
            Destroy(gameObject);
        }
    }



    public void damagePlayer(int damage){
        if(damageEnable){
            damageEnable = false;
            StartCoroutine(canDamage());
            health -= damage;
            Anim.SetTrigger("hurt");
            HealthBar.healthCourrent = health;//血量显示
            GameObject.Find("CamerFollow").GetComponent<CamerFollow>().Shake();//画面抖动
            Instantiate(bloodEffect,transform.position,Quaternion.identity);//血液特效
            BlinPlayer(numLinks,seconds);//闪烁,红闪，无敌
            if(health <= 0 ){
                health =0;
                GameController.isGameover = true;
            }
        }
    }

    IEnumerator canDamage(){
        yield return new WaitForSeconds(2.0f);
        damageEnable = true;
    }
    void BlinPlayer(int numLinks,float seconds){
        StartCoroutine(DoBlinks(numLinks,seconds));
    }

    IEnumerator DoBlinks(int numBlinks,float seconds){
        for(int i=0;i<numBlinks * 2;i++){
            myRender.enabled = !myRender.enabled;
            if(i<2)
            {
                red.enabled = !red.enabled;
            }
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
        red.enabled =false;
    }
}
