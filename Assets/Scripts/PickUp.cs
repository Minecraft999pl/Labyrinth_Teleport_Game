using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Picked()
    {
        Debug.Log("Podniesione");
        Destroy(this.gameObject);
    }
    public void Rotation(float x, float y, float z)
    {
        transform.Rotate(new Vector3(x,y,z));
    }
}
