using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public float time;

    public PlayerController playerController;

    public TMP_Text timeLeft;
    public TMP_Text score;
    public TMP_Text hp;

    private void Update()
    {
        time -= 1 * Time.deltaTime;
        timeLeft.text = time.ToString();
        score.text = playerController.score.ToString();
        hp.text = playerController.hp.ToString();
    }
    public void OnRestartButton_Pressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnShootButton_Pressed()
    {
        playerController.Shoot();
    }

}
