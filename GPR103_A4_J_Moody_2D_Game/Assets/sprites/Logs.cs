using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : MonoBehaviour
{// the public variables are copied from the vehicle script as they are the same and applicable

    public int moveDirection = 0; 
    public float speed; 
    public Vector2 startingPosition; 
    public Vector2 endPosition; 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed * moveDirection);

        if ((transform.position.x * moveDirection) < (endPosition.x * moveDirection))
        {
            transform.position = startingPosition;
        }
        // this code block is also carried over from the vehicle script as it is very similar and function almost the same in regards to movement. 
    }
}
