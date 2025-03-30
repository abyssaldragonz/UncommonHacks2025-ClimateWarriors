using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeHearts : MonoBehaviour
{
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject heart4;
    [SerializeField] private GameObject heart5;
    private GameObject player;
    private PlayerMovement healthScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthScript = player.GetComponent<PlayerMovement>();
        int numHearts = healthScript.health;
        switch (numHearts)
        {
            case 4:
                Destroy(heart5);
                break;
            case 3:
                Destroy(heart4);
                break;
            case 2:
                Destroy(heart3);
                break;
            case 1:
                Destroy(heart2);
                break;
            default:
                break;
        }
        
    }
}
