using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] int score = 0;
    
    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        ScoreSignal.OnEnemyKilled += AddToScore; // Đăng ký sự kiện
    }

    void OnDisable()
    {
        ScoreSignal.OnEnemyKilled -= AddToScore; // Hủy đăng ký sự kiện
    }


    void Start() 
    {
        
        int levelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
        Debug.Log("Màng chơi đang load " + levelIndex);
        ScoreSignal.RaiseScoreUpdated(score);  
    }


    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        ScoreSignal.RaiseScoreUpdated(score);
    }

}
