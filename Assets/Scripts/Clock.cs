using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime;
    public uint time = 5;
    public float xRotation = 0f;
    public float yRotation = 0.5f;
    public float zRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Picked()
    {
        int sign;
        if(addTime)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }
        GameManager.gameManager.AddTime((int)time * sign);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(xRotation, yRotation, zRotation);
    }
}
