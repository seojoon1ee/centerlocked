using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shirnk : MonoBehaviour
{
    private float shrinkSpeed;
    private Manager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.points > 0) {
            shrinkSpeed = 2;
            if(transform.localScale.x > 1) {
                transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            } else {
                Destroy(gameObject);
            }
        }
    }
}
