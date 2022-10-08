using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    public int freezeTime = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}
