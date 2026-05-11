using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI countdown;
    float timeLeft = 3f;
    public ParticleSystem cp;
    private float saveTimeScale;
    public GameObject startScreen;
    public bool notFirstTime = false;
    public TextMeshProUGUI text;
    public int points;
    public float gamespeed;
    public GameObject joy;
    public bool ifGameStarted = false;
    public GameObject Start1;
    public TextMeshProUGUI PT;
    public Animator ani;
    public Animator Circle;
    // Start is called before the first frame update
    void Start()
    {
        countdown.text = "";
        Application.targetFrameRate = 120;
        joy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if(notFirstTime) {
                StartCoroutine(gameResetTimer());
            }
        }
        text.text = points.ToString();
        PT.text = points.ToString();
    }
    public void gameStarts() {
        if(!ifGameStarted) {
            cp.Play();
            joy.SetActive(true);
            Start1.GetComponent<Animator>().Play("Start");
            Circle.Play("Start");
            //ani.Play("GROW");
            ifGameStarted = true;
            Time.timeScale = 2f;
        }
    }
    public void gamePause() {
        if(ifGameStarted){
        saveTimeScale = Time.timeScale;
        startScreen.GetComponent<Animator>().Play("Pauseer");
        Time.timeScale = 0;
        }
    }
    public void gameResume() {
        startScreen.GetComponent<Animator>().Play("Resumee");
        StartCoroutine(resumeTimer());
    }
    IEnumerator resumeTimer() {
        countdown.text = "3";
        yield return new WaitForSecondsRealtime(1);
        countdown.text = "2";
        yield return new WaitForSecondsRealtime(1);
        countdown.text = "1";
        yield return new WaitForSecondsRealtime(1);
        countdown.text = "";
        Time.timeScale = saveTimeScale;
    
    }

     IEnumerator gameResetTimer() {
        Time.timeScale = 0f;
        //yield return new WaitForSecondsRealtime(.5f);
        ani.Play("gameOverAni");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }
}
