using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideBarrel : MonoBehaviour
{
    [SerializeField] private Hideable player;
    [SerializeField] private GameObject exitsHereButton;

    private void Start()
    {
        exitsHereButton.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player.gameObject)
        {
            PlayerEnteredBarrel();
        }
    }

    private void PlayerEnteredBarrel()
    {
        player.Hide();
        exitsHereButton.SetActive(true);
    }

    public void PlayerExitedBarrel()
    {
        player.Reveal(exitsHereButton.transform.position);
        exitsHereButton.SetActive(false);
    }
}
