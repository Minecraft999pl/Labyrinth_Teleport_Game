using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    public int points = 5;
    public float xRotation = 0f;
    public float yRotation = 0f;
    public float zRotation = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(GameManager.gameManager.pickClip);
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(xRotation, yRotation, zRotation);
    }
}
