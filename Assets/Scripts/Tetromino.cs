using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    private readonly float fallTime = 0.8f;

    private static readonly int width = 10;
    private static readonly int height = 20;

    [SerializeField]
    private Vector3 rotationPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90f);
            if (!IsValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90f);
            }
        }

        if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.DownArrow) ? fallTime/10f : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                this.enabled = false;
                FindObjectOfType<SpawnTetromino>().NewTetromino();
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
