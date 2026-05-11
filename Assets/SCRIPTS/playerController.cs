using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{
    public ParticleSystem Circle;
    public GameObject mainCamera;
    public SpriteRenderer playerRenderer;
    public Slider slider;
    public Manager gm;
    public FloatingJoystick joy;
    public float speed;
    public float CollisionEnterTime;
    public float CollisionExitTime;
    public Rigidbody2D rigi;
    private Vector2 joyDirec;
    public GameObject DeathScreen;
    public TextMeshProUGUI text;
    public GameObject particle;
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
        DeathScreen.SetActive(false);
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        joyDirec = new Vector2(joy.Horizontal, joy.Vertical);
        if(joyDirec.x != 0 && Time.timeScale != 0) {
            rigi.velocity = joyDirec * (speed / Time.timeScale);
        } else {
            rigi.velocity = Vector2.zero;
        }
        
        if(gm.ifGameStarted == true && Time.deltaTime != 0) {
            if(joyDirec.x == 0 && health <= 100) {
                health = health + .1f;
            } else {
                health = health - .2f;
            }
            
            if(health > 0) {
                slider.value = health;
            } else {
                GameOcverSeq();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("LINE")) {
            GameOcverSeq();
        } else if(other.CompareTag("SAFEAREA")) {
           // Circle.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        GameOcverSeq();
    }
    void GameOcverSeq() {
        mainCamera.GetComponent<Animator>().SetTrigger("Shake");
        Debug.Log("GAMEOVER");
        //gm.ifGameStarted = false;
         
         particle.SetActive(true);
            //Game over script
        DeathScreen.SetActive(true);
            //Game over script
        gm.notFirstTime = true;
        Time.timeScale = 0;
        playerRenderer.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("SAFEAREA")) {
           // Circle.Play();
            //mainCamera.GetComponent<Animator>().SetTrigger("Soml");
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("SAFEAREA")) {
            text.gameObject.SetActive(false);
            Circle.Stop();
        }
    }
    */
}

/*
    

    private void OnTriggerExit2D(Collider2D other) {
        text.gameObject.SetActive(false);
    }
}
*/