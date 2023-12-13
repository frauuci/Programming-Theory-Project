using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static Model;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI spawnTwxt;
    public GameObject pausedPanel;
    public bool isGameActive;
    int score = 0;
    float spawnRate = 2.0f;
    private int timeScale = 1;
   

    List<Enum> popupText = new List<Enum>();
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        var allColors = new List<Enum>();

        popupText.AddRange(Enum.GetValues(typeof(EBird)).Cast<Enum>());
        popupText.AddRange(Enum.GetValues(typeof(ERabbit)).Cast<Enum>());
        popupText.AddRange(Enum.GetValues(typeof(EFrog)).Cast<Enum>());

        //popupText =frogList.Concat(birdList).Concat(rabbitList).ToList();
        StartCoroutine(SpawnText());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GamePause();
        }
    }
    IEnumerator SpawnText()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            //var x= (EAnimal)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EAnimal)).Cast<EAnimal>().Max());
            int idx = UnityEngine.Random.Range(0, popupText.Count);
            spawnTwxt.text = popupText[idx].ToString();
        }
    }
   
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }
    private void GamePause()
    {
        if (timeScale == 1)
        {
            Time.timeScale = 0;
            pausedPanel.gameObject.SetActive(true);
            timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
            pausedPanel.gameObject.SetActive(false);

            timeScale = 1;
        }

    }
}
