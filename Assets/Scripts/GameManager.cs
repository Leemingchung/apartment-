using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameMode curentMode;
    int step = 50;
    public GameObject timer;
    public Text txtStep;
    public Board _board;
    public bool isPlay;

    public void ChangeModeGame(GameMode gameMode)
    {
        curentMode = gameMode;
        switch (curentMode)
        {
            case GameMode.BEGINNER:
                timer.SetActive(false);
                txtStep.gameObject.SetActive(false);
                break;
            case GameMode.FIFTEEN_STEPS:
                timer.SetActive(false);
                txtStep.gameObject.SetActive(true);
                txtStep.text = "Steps :" + step.ToString();
                break;
            case GameMode.TIME_ATTACK:
                timer.SetActive(true);
                txtStep.gameObject.SetActive(false);

                break;
        }
        _board.RenderMap() ;
        PopupMode.instance.Close();
        isPlay = true;
    }
    private void Awake()
    {
        instance = this;
    }

    public void Lose()
    {
        PopupLose.instance.Enable();
    }
    public IEnumerator CheckLose()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < _board.posItem.GetLength(0); i++)
        {
            for (int j = 0; j < _board.posItem.GetLength(1); j++)
            {
                if (_board.posItem[i, j] == null)
                {
                    yield break;
                }
            }
        }
        Lose();
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void NexLevel()
    {
        UiMain.instance.NexScene();
    }
    public void CountStep()
    {
        if (curentMode == GameMode.FIFTEEN_STEPS)
        {
            txtStep.transform.DOScale(1.2f, 0.25f).OnComplete(() =>
            {
                step--;
                txtStep.transform.DOScale(1, 0.25f);
                txtStep.text = "Steps :" + step.ToString();
            });
            if (step <= 0)
            {
                Lose();
            }
        }
    }
}
public enum GameMode
{
    BEGINNER,
    FIFTEEN_STEPS,
    TIME_ATTACK,
}