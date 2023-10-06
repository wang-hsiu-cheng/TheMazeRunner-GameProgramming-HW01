using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ribbonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= 0.5)
            Invoke("deleteribbon", 5);
    }
    void deleteribbon()
    {
        Destroy(this.gameObject);
    }
}
