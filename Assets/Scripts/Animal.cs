using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static Model;
using static UnityEngine.GraphicsBuffer;

public class Animal:MonoBehaviour
{
    private float _speed;
    private float _jumpSpeed;
    private GameManager gameMgr;
    private GameObject gameManagerScript;
    private TextMeshProUGUI spawnTwxt;

    void Awake()
    {   
        gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnTwxt = GameObject.Find("SpawnText").GetComponent<TextMeshProUGUI>();
    }
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public float JumpSpeed
    {
        private get { return _jumpSpeed; }
        set { _jumpSpeed = value; }
    }
 
    public virtual void  Walk()
    {
    }
   
    protected Vector3 WalkingForce()
    {
        return Vector3.right * Speed;
    }
    private void OnMouseDown()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        if (gameMgr.isGameActive)
        {
            bool isMatched = IsTextMatched();
            int score = isMatched?5:-2;
            gameMgr.AddScore(score);
        }
    }
    bool IsTextMatched() {
        switch (gameObject.tag) {
            case "Rabbit":
                return Enum.IsDefined(typeof(ERabbit), spawnTwxt.text);
                break;
            case "Frog":
                return Enum.IsDefined(typeof(EFrog), spawnTwxt.text);
                break;
            case "Bird":
                return Enum.IsDefined(typeof(EBird), spawnTwxt.text);
                break;
            default: 
                return false;
                break;
        }
        
    }
}
