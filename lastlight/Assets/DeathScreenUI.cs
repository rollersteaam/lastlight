using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class DeathScreenUI : MonoBehaviour
{
    CanvasGroup group;

    void Start()
    {
        group = GetComponent<CanvasGroup>();

        Player.OnPlayerDie += (o, e) =>
        {
            Display();
        };
    }

    void Display()
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    public void TryAgain()
    {
        ProgressionManager.Instance.TryAgain();
    }
}
