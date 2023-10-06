using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    static public bool passLevel_1 = false, passLevel_2 = false, gamefinish = false;
    public float jumppower = 5, speed = 5, deg = 60, blood = 49;
    [SerializeField] private Vector3[] destinationOfWay;
    private bool[] Arrived = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    private Vector3 originPosition;
    private int jumpAbility = 1;
    private Rigidbody _rb;
    public GameObject playerCamera, mainCamera;
    [SerializeField] private Image bloodImage;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = new Vector3(10, 2, 2.5f);
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
            if (!passLevel_1) {
                for (int i = 0; i < 6; i++)
                    Arrived[i] = true;
                gameObject.transform.position = destinationOfWay[7];
                passLevel_1 = true;
            } else {
                for (int i = 6; i < 15; i++)
                    Arrived[i] = true;
                gameObject.transform.position = destinationOfWay[16];
                passLevel_2 = true;
            }
        }

    }
    void UpdateBlood()
    {
        bloodImage.transform.localScale = new Vector3(blood/49, bloodImage.transform.localScale.y, bloodImage.transform.localScale.z);
    }
    void Dead()
    {
        buttonManager.game_start = false;
        passLevel_1 = false;
        passLevel_2 = false;
        gameObject.transform.position = originPosition;
        for (int i = 0; i < 15; i++)
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
            blood -= 2;
            UpdateBlood();
            if (blood <= 0)
                Dead();
        }
        if (other.gameObject.tag == "goldencup") {
            gamefinish = true;
            Dead();
            SceneManager.LoadScene(1);
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
            case "way7": {
                gameObject.transform.position = destinationOfWay[8];
                Arrived[6] = true;
                break;
            }
            case "way8": {
                if (Arrived[6]) {
                    gameObject.transform.position = destinationOfWay[9];
                    Arrived[7] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[7];
                break;
            }
            case "way9": {
                if (Arrived[6]) {
                    gameObject.transform.position = destinationOfWay[10];
                    Arrived[8] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[7];
                break;
            }
            case "way10": {
                if (Arrived[6] && Arrived[12]) {
                    gameObject.transform.position = destinationOfWay[11];
                    Arrived[9] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[9];
                break;
            }
            case "way11": {
                if (Arrived[6] && Arrived[12]) {
                    gameObject.transform.position = destinationOfWay[12];
                    Arrived[10] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[9];
                break;
            }
            case "way12": {
                if (Arrived[6] && Arrived[12]) {
                    gameObject.transform.position = destinationOfWay[13];
                    Arrived[11] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[9];
                break;
            }
            case "way13": {
                if (Arrived[6] && Arrived[8]) {
                    gameObject.transform.position = destinationOfWay[14];
                    Arrived[12] = true;
                } else {
                    gameObject.transform.position = destinationOfWay[8];
                    Arrived[12] = true;
                }
                break;
            }
            case "way14": {
                if (Arrived[9]) {
                    gameObject.transform.position = destinationOfWay[15];
                    Arrived[13] = true;
                } else 
                    gameObject.transform.position = destinationOfWay[10];
                break;
            }
            case "way15": {
                gameObject.transform.position = destinationOfWay[16];
                Arrived[14] = true;
                passLevel_2 = true;
                break;
            }
            default: {
                break;
            }
        }
    }
}
