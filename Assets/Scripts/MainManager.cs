using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager Instance;

    public bool waterLevel = true;
    public bool fireLevel = true;
    public bool airLevel = true;
    public bool earthLevel = true;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (!waterLevel && GameObject.FindGameObjectWithTag("WATER") != null)
            GameObject.FindGameObjectWithTag("WATER").SetActive(false);
        if (!fireLevel && GameObject.FindGameObjectWithTag("FIRE") != null)
            GameObject.FindGameObjectWithTag("FIRE").SetActive(false);
        if (!airLevel && GameObject.FindGameObjectWithTag("AIR") != null)
            GameObject.FindGameObjectWithTag("AIR").SetActive(false);
        if (!earthLevel && GameObject.FindGameObjectWithTag("EARTH") != null)
            GameObject.FindGameObjectWithTag("EARTH").SetActive(false);
        
    }
}
