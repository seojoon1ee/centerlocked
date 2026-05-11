using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Manager gm;
    public float WitTime;
    public float FirstTime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(flashing());
    }

    // Update is called once per frame
    void Update()
    {
        gm = GameObject.Find("GameManager").GetComponent<Manager>();
        WitTime = .5f;
        FirstTime = 1;
    }

    IEnumerator flashing() {
        yield return new WaitForSeconds(FirstTime);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(WitTime);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(WitTime);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(WitTime);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(FirstTime);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(FirstTime);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
