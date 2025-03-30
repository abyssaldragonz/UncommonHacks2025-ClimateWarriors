using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToLevel : MonoBehaviour
{

    MainManager mainScript;
    [SerializeField] private bool teleportToWater = false;
    [SerializeField] private bool teleportToEarth = false;
    [SerializeField] private bool teleportToFire = false;
    [SerializeField] private bool teleportToAir = false;

    // Start is called before the first frame update
    void Start()
    {
        mainScript =  GameObject.FindGameObjectWithTag("MAINMANAGER").GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (teleportToAir)
        {
            SceneManager.LoadScene("AirLevel");
            mainScript.airLevel = false;
        }
        else if (teleportToWater)
        {
            SceneManager.LoadScene("WaterLevel");
            mainScript.waterLevel = false;
        }
        else if (teleportToFire)
        {
            SceneManager.LoadScene("FireLevel");
            mainScript.fireLevel = false;
        }
        else if (teleportToEarth)
        {
            SceneManager.LoadScene("EarthLevel");
            mainScript.earthLevel = false;
        }
    }
}
