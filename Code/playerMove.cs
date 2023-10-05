using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    static public bool passLevel_1 = false;
    public float jumppower = 5, speed = 5, deg = 60, blood = 49;
    [SerializeField] private Vector3[] destinationOfWay;
    [SerializeField] private bool[] Arrived = {false, false, false, false, false, false};
    private Vector3 originPosition;
    private int jumpAbility = 1;
    private Rigidbody _rb;
    public GameObject playerCamera, mainCamera;
    [SerializeField] private Image bloodImage;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = new Vector3(10, 2, 1);
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonManager.game_start == true) {
            Control();
            QuickPass();
        }
    }
    void Control()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0, 0, speed*Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0, 0, -speed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -deg*Time.deltaTime, 0, Space.Self);   
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, deg*Time.deltaTime, 0, Space.Self); 
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            if(jumpAbility > 0){
                _rb.velocity = new Vector3(_rb.velocity.x, jumppower, _rb.velocity.z);
                jumpAbility -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            if (playerCamera.GetComponent<Camera>() .depth == -1)
                playerCamera.GetComponent<Camera>() .depth = 2;
            else 
                playerCamera.GetComponent<Camera>() .depth = -1;
        }
        if (Input.GetKeyDown(KeyCode.Escape) || gameObject.transform.position.y < -2) {
            Dead();
        }
    }
    void QuickPass()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            for (int i = 0; i < 6; i++)
                Arrived[i] = true;
            gameObject.transform.position = destinationOfWay[7];
            passLevel_1 = true;
        }
    }
    void UpdateBlood()
    {
        bloodImage.transform.localScale = new Vector3(blood/49, bloodImage.transform.localScale.y, bloodImage.transform.localScale.z);
    }
    void Dead()
    {
        buttonManager.game_start = false;
        gameObject.transform.position = originPosition;
        for (int i = 0; i < 6; i++)
            Arrived[i] = false;
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        blood = 49;
        UpdateBlood();
        buttonManager.GUIchange = true;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground") {
            jumpAbility = 1;
        }
        if (other.gameObject.tag == "gate") {
            blood -= 5;
            UpdateBlood();
            if (blood <= 0)
                Dead();
        }
    }
    void OnTriggerEnter(Collider other) {
        switch (other.gameObject.tag) {
            case "way1": {
                gameObject.transform.position = destinationOfWay[1];
                Arrived[0] = true;
                break;
            }
            case "way2": {
                if (Arrived[0]) {
                    gameObject.transform.position = destinationOfWay[2];
                    Arrived[1] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[0];
                break;
            }
            case "way3": {
                if (Arrived[0]) {
                    gameObject.transform.position = destinationOfWay[3];
                    Arrived[2] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[0];
                break;
            }
            case "way4": {
                if (Arrived[0]) {
                    gameObject.transform.position = destinationOfWay[4];
                    Arrived[3] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[6];
                break;
            }
            case "way5": {
                if (Arrived[0]) {
                    gameObject.transform.position = destinationOfWay[5];
                    Arrived[4] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[6];
                break;
            }
            case "way6": {
                gameObject.transform.position = destinationOfWay[7];
                Arrived[5] = true;
                passLevel_1 = true;
                break;
            }
            default: {
                break;
            }
        }
    }
}
