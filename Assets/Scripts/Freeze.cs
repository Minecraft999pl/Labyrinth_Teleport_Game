using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    public int freezeTime = 10;
    public float xRotation = 0f;
    public float yRotation = 0.5f;
    public float zRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(GameManager.gameManager.pickClip);
        GameManager.gameManager.FreezeTime(freezeTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(xRotation, yRotation, zRotation);
    }
}
