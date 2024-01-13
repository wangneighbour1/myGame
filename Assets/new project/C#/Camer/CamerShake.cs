using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CamerShake : MonoBehaviour
{
    public Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake(){
        camAnim.SetTrigger("shake");    
    }
}
