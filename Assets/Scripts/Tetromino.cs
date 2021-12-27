using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    private float fallTime = 0.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            transform.position += new Vector3(-1, 0, 0);

        }
        else if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            transform.position += new Vector3(1, 0, 0);
        }

        if(Time.time - previousTime > (Input.GetAxisRaw("Vertical") < 0f ? fallTime/10f : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;
        }
    }
}
