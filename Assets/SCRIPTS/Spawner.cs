using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public Manager gameManagaer;
    public GameObject line;
    public GameObject Lazers;
    public Transform Safezone;
    private float nextTimeToSpawn = 0f;
    private Vector3 RandomVO;
    private Vector3 RandomVF;
    private Vector3 RandomgF;
    private Vector3 RandomVT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagaer.ifGameStarted) {
            if(Time.time > nextTimeToSpawn) {
                RandomVO = new Vector3(Random.Range(-7.0f, 7.0f), 0,0);
                RandomVF = new Vector3(Random.Range(-8.0f, 8.0f), 0,0);
                RandomgF = new Vector3(Random.Range(-8.0f, 8.0f), 0,0);
                RandomVT = new Vector3(Random.Range(-7.0f, 7.0f), 0,0);
                Safezone.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
                Instantiate(line, Safezone.position, Quaternion.identity);
                //Instantiate(Lazers, RandomVO, Quaternion.Euler(0, 0,Random.Range(0.0f, 360.0f)));
                nextTimeToSpawn = Time.time + 6f;
            }
        }
    }
}
