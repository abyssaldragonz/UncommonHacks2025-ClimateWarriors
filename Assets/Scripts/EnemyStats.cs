using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health;
    private float baseHealth;
    public GameObject healthBar;
    public Transform healthTransform;

    public GameObject newHealthBar;

    void Start()
    {
        newHealthBar = Instantiate(healthBar, healthTransform.position + new Vector3(0, 10, 0), Quaternion.identity, healthTransform);
        baseHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = healthTransform.GetComponent<Transform>().position;
    }
    void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.CompareTag("BULLET"))
        {
            health--;
            Destroy(other.gameObject);
            if (health == 0)
                Destroy(gameObject);

            newHealthBar.transform.localScale -= new Vector3((1 / baseHealth), 0, 0);
        }
	}
}
