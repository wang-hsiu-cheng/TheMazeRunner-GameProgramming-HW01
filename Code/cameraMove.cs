using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    private char stage = '0';
    private Vector3 originPosition;
    [SerializeField] private float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position == originPosition)
            stage = '1';
        if (stage == '1') {
            transform.Translate(speed*Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x > 35) {
                gameObject.transform.eulerAngles = new Vector3(30, -90, 0);
                stage = '2';
            }    
        } else if (stage == '2') {
            transform.Translate(speed*Time.deltaTime, 0, 0);
            if (gameObject.transform.position.z > 35) {
                gameObject.transform.eulerAngles = new Vector3(30, 0, 0);
                gameObject.transform.position = originPosition;
                stage = '1';
            }
        }
    }
}
