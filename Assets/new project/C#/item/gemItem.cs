using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gemItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            gem.currentCoin++;
            Destroy(gameObject);
        }
    }
}
