using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UI : MonoBehaviour
{
    public static UI instance;

    private void Awake()
    {
        instance = this;
    }

    TMP_Text rankText;
    TMP_Text scoreText;

    private void Start()
    {
        rankText = transform.Find("TextRank").GetComponent<TMP_Text>();
        scoreText = transform.Find("TextScore").GetComponent<TMP_Text>();

        UpdateScore();
        UpdateRank();
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
}
