using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PopupMode : MonoBehaviour
{
    public static PopupMode instance;
    public CanvasGroup canvasGroup;
    public Button[] btns;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        StartCoroutine(Amin());
        btns[0].onClick.AddListener(() => { GameManager.instance.ChangeModeGame(GameMode.BEGINNER); });
        btns[1].onClick.AddListener(() => { GameManager.instance.ChangeModeGame(GameMode.FIFTEEN_STEPS); });
        btns[2].onClick.AddListener(() => { GameManager.instance.ChangeModeGame(GameMode.TIME_ATTACK); });

    }
    public IEnumerator Amin()
    {
       // yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].transform.DOScale(1f, 0.5f).SetUpdate(true).SetEase(Ease.Linear);
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void Open()
    {

        canvasGroup
        .DOFade(1, 0f).SetUpdate(true);
        canvasGroup.transform.DOScale(1, 0.3f).SetUpdate(true);
        canvasGroup.blocksRaycasts = true;
    }
    public void Close()
    {
        canvasGroup.DOFade(0, 0.5f).SetUpdate(true).OnComplete(() =>
        {
            canvasGroup.blocksRaycasts = false;
            Time.timeScale = 1;
        });
    }
}
