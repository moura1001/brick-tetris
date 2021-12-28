using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    private float fallTime = 0.8f;

    private static int width = 10;
    private static int height = 20;
    
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
            if (!IsValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }

        }
        else if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            transform.position += new Vector3(1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        if(Time.time - previousTime > (Input.GetAxisRaw("Vertical") < 0f ? fallTime/10f : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
            }
            previousTime = Time.time;
        }
    }

    private bool IsValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
        }

        return true;
    }
}
