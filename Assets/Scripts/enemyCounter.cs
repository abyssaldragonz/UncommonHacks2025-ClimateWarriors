using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class enemyCounter : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text mText;
    void Start()
    {
        mText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCounter = GameObject.FindGameObjectsWithTag("ENEMY").Length;

        mText.SetText("Enemies Left : " + enemyCounter);

        if (enemyCounter == 0)
        {
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("WelcomeScene");
    }
}
