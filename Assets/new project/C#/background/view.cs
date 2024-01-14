using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour
{
    [SerializeField] private Vector2 slowSpeed;
    private Vector3 lastcameraPosition;
    private Transform cameraTransform;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    private void Start(){
        cameraTransform = Camera.main.transform;
        lastcameraPosition  = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate(){
        Vector3 deltaMovement = cameraTransform.position - lastcameraPosition;
        transform.position += new Vector3(deltaMovement.x * slowSpeed.x,deltaMovement.y * slowSpeed.y);
        lastcameraPosition = cameraTransform.position;

        if(Math.Abs(cameraTransform.position.x - transform.position.x )>= textureUnitSizeX){
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX,transform.position.y); 
        }

        if(Math.Abs(cameraTransform.position.y - transform.position.y )>= textureUnitSizeY){
            float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x,cameraTransform.position.y + offsetPositionY); 
        }

    }
}
