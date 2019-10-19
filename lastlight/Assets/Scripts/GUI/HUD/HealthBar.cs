using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Player player;
    Image healthMask;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        healthMask = GetComponent<Image>();
    }

    void Update()
    {
        healthMask.fillAmount = (float)player.Health / player.MaximumHealth;
    }
}
