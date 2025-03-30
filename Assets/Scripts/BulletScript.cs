using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite[] spriteArray;
    Scene currentScene;

    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Collider2D>(), true); // prevent collision with player
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); // change sprites for differente scenes
        currentScene = SceneManager.GetActiveScene();

        if (string.Equals(currentScene.name, "FireLevel"))
            newSprite = spriteArray[0];

        if (string.Equals(currentScene.name, "AirLevel"))
            newSprite = spriteArray[1];

        if (string.Equals(currentScene.name, "WaterLevel"))
            newSprite = spriteArray[2];

        if (string.Equals(currentScene.name, "EarthLevel"))
            newSprite = spriteArray[3];

        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}
