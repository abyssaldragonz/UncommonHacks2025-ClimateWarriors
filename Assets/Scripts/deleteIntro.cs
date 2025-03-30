using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteIntro : MonoBehaviour
{
    [SerializeField] private GameObject objectToRemove1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseOver()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color color = renderer.color;
        float alpha = color.a;
        if (!Input.GetMouseButtonDown(0)) return;
        if (alpha > .9) Destroy(objectToRemove1);
    }
}
