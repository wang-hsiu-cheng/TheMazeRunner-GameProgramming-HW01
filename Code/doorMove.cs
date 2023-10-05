using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMove : MonoBehaviour
{
    public char moveDirection = 'x';
    public float speed = 0.05f, moveDistance = 0.7f;
    private Vector3 doorPosition, doorScale, moveVector;
    // Start is called before the first frame update
    void Start()
    {
        doorPosition = gameObject.transform.position;
        doorScale = gameObject.transform.localScale;
        switch (moveDirection) {
            case 'x':
                moveVector = new Vector3(speed, 0, 0);
                break;
            case 'y':
                moveVector = new Vector3(0, speed, 0);
                break;
            case 'z':
                moveVector = new Vector3(0, 0, speed);
                break;
            default:
                moveVector = new Vector3(0, 0, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(moveVector);
        if (Vector3.Distance(gameObject.transform.position, doorPosition) >= moveDistance)
            moveVector *= -1;
    }
}
