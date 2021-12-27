using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
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
    }
}
