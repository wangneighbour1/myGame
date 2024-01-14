using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health;
    public GameObject bloodEffect;
    private BoxCollider2D BoxCollider2D;
    private Renderer myRender;
    public int numLinks;
    public float seconds;
    private Animator Anim;
    public bool Death;

    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        once =true;
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
        health -= damage;
        GameObject.Find("CamerFollow").GetComponent<CamerFollow>().Shake();
        Instantiate(bloodEffect,transform.position,Quaternion.identity);
        BlinPlayer(numLinks,seconds);
    }

    void BlinPlayer(int numLinks,float seconds){
        StartCoroutine(DoBlinks(numLinks,seconds));
    }

    IEnumerator DoBlinks(int numBlinks,float seconds){
        for(int i=0;i<numBlinks * 2;i++){
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}
