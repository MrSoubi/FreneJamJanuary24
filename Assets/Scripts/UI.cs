using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UI : MonoBehaviour
{
    public static UI instance;

    private void Awake()
    {
        instance = this;
    }

    TMP_Text rankText;
    TMP_Text scoreText;
    TMP_Text timerText;
    GameObject endGame;
    GameObject tuto;

    [SerializeField] GameObject dragon;

    float timer;

    private void Start()
    {
        rankText = transform.Find("TextRank").GetComponent<TMP_Text>();
        scoreText = transform.Find("TextScore").GetComponent<TMP_Text>();
        timerText = transform.Find("TextTimer").GetComponent <TMP_Text>();

        endGame = transform.Find("EndGame").gameObject;
        endGame.SetActive(false);

        tuto = transform.Find("Tuto").gameObject;
        tuto.SetActive(true);

        timer = 60;

        UpdateScore();
        UpdateRank();
        UpdateTimer();
    }

    public void Restart()
    {
        scoreText.text = "0";
        rankText.text = "1";
        GameManager.Initialize();
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (timer > 0 && !tuto.activeSelf)
        {
            UpdateTimer();
        }
        
        if (timer < 0)
        {
            endGame.transform.Find("Score").GetComponent<TMP_Text>().text = scoreText.text;
            endGame.SetActive(true);
            dragon.GetComponent<DragonController>().enabled = false;
        }
    }

    public void UpdateScore()
    {
        scoreText.text = GameManager.GetScore().ToString();
        scoreText.rectTransform.DOScale(Vector3.one * 1.5f, 0.5f).SetEase(Ease.OutBack);
        scoreText.rectTransform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }
    
    public void UpdateRank()
    {
        rankText.text = GameManager.GetRank().ToString();
        rankText.rectTransform.DOScale(Vector3.one * 3f, 0.5f).SetEase(Ease.OutBack);
        rankText.rectTransform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    public void UpdateTimer()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.Floor(timer).ToString() + "'";
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        tuto.SetActive(false);
    }
}