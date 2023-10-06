using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ribbonsManager : MonoBehaviour
{
    [SerializeField] private GameObject []ribbon;
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 30; j++) {
            for (int i = 0; i < 30; i++) {
                GameObject spawnRibbon = Instantiate(ribbon[Random.Range(0,3)], transform);
                spawnRibbon.transform.position = new Vector3((Random.Range(-50, 50) / 10f), j/3.0f, (Random.Range(-50, 50) / 10f));
                spawnRibbon.transform.eulerAngles = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % 1 <= 0.1) {
            Debug.Log(Time.time);
            for (int i = 0; i < 10; i++) {
                GameObject spawnRibbon = Instantiate(ribbon[Random.Range(0,3)], transform);
                spawnRibbon.transform.position = new Vector3((Random.Range(-50, 50) / 10f), 10, (Random.Range(-50, 50) / 10f));
                spawnRibbon.transform.eulerAngles = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            }
        }
    }
    public void OnReturnClick()
    {
        SceneManager.LoadScene(0);
    }
}
