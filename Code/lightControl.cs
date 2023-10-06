using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControl : MonoBehaviour
{
    [SerializeField] float brightness = 1, deg = 50;
    Light lightComp;
    // Start is called before the first frame update
    void Start()
    {
        lightComp = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonManager.game_start == true) {
            Control();
        }
    }
    void Control()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (lightComp.intensity > 0) 
                lightComp.intensity -= brightness;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (lightComp.intensity < 10)
                lightComp.intensity += brightness;
        }
        if (Input.GetKey(KeyCode.UpArrow) && gameObject.transform.rotation.x > -30*Mathf.PI/180) {
            transform.Rotate(-deg*Time.deltaTime, 0, 0, Space.Self);   
        } else if (Input.GetKey(KeyCode.DownArrow) && gameObject.transform.rotation.x < 30*Mathf.PI/180) {
            transform.Rotate(deg*Time.deltaTime, 0, 0, Space.Self); 
        }
    }
}
