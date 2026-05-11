using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reSize : MonoBehaviour
{
    private Manager gameManager;
    public float shrinkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > 3) {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        } else {
            gameManager.points ++;
            if(Time.timeScale < 4) {
                Time.timeScale = Time.timeScale + .075f;
            }
            Destroy(GameObject.Find("Square(Clone)"));
            Destroy(gameObject);
        }
    }
}
