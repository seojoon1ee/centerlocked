using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Manager gm;
    private Vector3 RandomVO;
    private Transform RandomV;
    private Vector3 NewVEc;
    public float speed;
    public float previouspoints;
    // Start is called before the first frame update
    void Start()
    {
        RandomV = GameObject.FindGameObjectWithTag("SAFEAREA").transform;
        NewVEc = new Vector3(RandomV.transform.position.x - Random.Range(-2f, 2f),RandomV.transform.position.y - Random.Range(-2f, 2f), 0);
        RandomVO = (NewVEc - transform.position).normalized;
        //rigi.velocity = transform.position - RandomVO * speed;
        gm = GameObject.Find("GameManager").GetComponent<Manager>();
        previouspoints = gm.points;
        gameObject.GetComponent<LineRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(RESIZEMASTER());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RESIZEMASTER() {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<LineRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if(gm.points > 0) {
            while(true) {
                transform.position += RandomVO * Time.deltaTime * 5;
                yield return new WaitForSeconds(0.05f);
                if(gm.points - previouspoints == 1) {
                    Destroy(gameObject);
                }
            }
        }
    }
}
