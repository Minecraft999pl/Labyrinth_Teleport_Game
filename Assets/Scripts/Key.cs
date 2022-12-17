using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Gold
}

public class Key : PickUp
{
    public float xRotation = 0f;
    public float yRotation = 0.5f;
    public float zRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public KeyColor color;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(GameManager.gameManager.pickClip);
        GameManager.gameManager.AddKey(color);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(xRotation, yRotation, zRotation);
    }
}
