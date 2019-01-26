using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            Vector3 pos = transform.position;
            pos.x -= 0.1f;
            transform.position = pos;
        }
        else if (Input.GetKey("right"))
        {
            Vector3 pos = transform.position;
            pos.x += 0.1f;
            transform.position = pos;
        }
        if (Input.GetKeyDown("space"))
        {

        }
    }
}
