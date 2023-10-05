using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGateControl : MonoBehaviour
{
    private bool active = true;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.passLevel_1 && active)
            transform.Translate(0, speed*Time.deltaTime, 0);
        if (gameObject.transform.position.y > 5.5)
            active = false;
    }
}
