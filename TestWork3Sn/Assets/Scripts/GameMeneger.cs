using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMeneger : MonoBehaviour
{
    public static int Score = 0;
    public static int Bonus = 0;

    public GameObject panel; 
    public Text scoreText;
    public Text bonusText;

    [SerializeField] private GameObject mP;

    public static bool canChangeText = false;
    public static int feverCount = 0;
    public static bool Aegis = false;
    private void Awake()
    {
        
    }
    private void Start()
    {
        scoreText.text = Score.ToString();
        bonusText.text = Bonus.ToString();
    }
    private void Update()
    {
        
        if(feverCount > 3 && !Aegis)
        {
            feverCount = 0;
            Aegis = true;
            StartCoroutine(TimeToEndAegis());
        }

        if(canChangeText)
        {
            canChangeText = false;
            scoreText.text = Score.ToString();
            bonusText.text = Bonus.ToString();
        }
        if(mP == null || Player.WinGame)
        {
            panel.SetActive(true);
        }

        if (Player.deathPlayer)
        {
            Time.timeScale = 0;
        }
    }
    

    IEnumerator TimeToEndAegis()
    {
        yield return new WaitForSeconds(5.0f);
        Aegis = false;
        Bonus = 0;
        canChangeText = true;
    }

    public static void ChangeText()
    {
        canChangeText = true;
    }
    

    public void RestartLvl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        StartCoroutine(TimeToEndAegis());
        Bonus = 0;
        Score = 0;
        Aegis = false;
        Player.WinGame = false;
        Player.deathPlayer = false;
        Player.ColorPlayer = "Blue";
        feverCount = 0;
    }
}
