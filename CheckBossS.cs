using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBossS : MonoBehaviour
{
    public GameObject BossH;
    public GameObject Boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();
        if (Player != null)
        {
            BossH.SetActive(true);
            Boss.SetActive(true);
        }
    }
}
