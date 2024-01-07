using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconRespawnHandler : MonoBehaviour
{
    Action OnRespawnCompleted;
    int respawnCount;

    public void RespawnProcess(List<IconSwappable> iconsToRespawn, Action respawnCompletedCallback)
    {
        respawnCount = iconsToRespawn.Count;
        OnRespawnCompleted = respawnCompletedCallback;

        foreach (IconSwappable iconToRespawn in iconsToRespawn)
        {
            SetNewIconData(iconToRespawn);
            StartCoroutine(IconScaleDown(iconToRespawn));
        }
    }

    private void SetNewIconData(IconSwappable iconToRespawn)
    {

        int index = UnityEngine.Random.Range(0, GameManager.Instance.GetIconElementsSoList().Count);
        IconSwappableSO iconSwappableSO = GameManager.Instance.GetIconElementsSoList()[index];
        iconToRespawn.SetupIconElement(iconSwappableSO.iconIndex, iconSwappableSO.unselectedImage, iconSwappableSO.selectedImage);
    }


    IEnumerator IconScaleDown(IconSwappable iconToScale)
    {
        float t = 1f;
        //Debug.LogWarning("ScaleDownStarted");
        while (iconToScale.gameObject.transform.localScale.x > 0)
        {
            t -= Time.deltaTime * 1.5f;
            iconToScale.gameObject.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }

        iconToScale.GetComponent<Image>().sprite = iconToScale.UnselectedImage;
        //Debug.LogWarning("ScaleDownCompleted");
        StartCoroutine(IconScaleUp(iconToScale));
    }
    IEnumerator IconScaleUp(IconSwappable iconToScale)
    {
        float t = 0f;
        //Debug.LogWarning("ScaleUpStarted");
        while (iconToScale.gameObject.transform.localScale.x < 1)
        {
            t += Time.deltaTime * 1.5f;
            iconToScale.gameObject.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
        //Debug.LogWarning("ScaleUpCompleted");
        RespawnCompletedCheck();
    }

    public void RespawnCompletedCheck()
    {
        respawnCount--;
        if (respawnCount == 0)
        {
            OnRespawnCompleted?.Invoke();
        }
    }

}
