using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideBarrel : MonoBehaviour
{
    private GameObject exitsHereButton;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        exitsHereButton = GetComponentInChildren<Button>().gameObject;

        exitsHereButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            PlayerExitedBarrel();
        });


        exitsHereButton.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEnteredBarrel();
        }
    }

    private void PlayerEnteredBarrel()
    {
        player.GetComponent<CharacterController>().canMove = false;
        player.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        exitsHereButton.SetActive(true);
        // joystick.SetActive(false);
        // joystick.GetComponent<FloatingJoystick>().SnapX = false;
        // joystick.GetComponent<FloatingJoystick>().SnapY = false;
    }

    private void PlayerExitedBarrel()
    {
        player.transform.localScale = new Vector3(1f, 1f, 1f);
        player.transform.position = exitsHereButton.transform.position;
        exitsHereButton.SetActive(false);
        // joystick.SetActive(true);
        // joystick.GetComponent<FloatingJoystick>().SnapX = true;
        // joystick.GetComponent<FloatingJoystick>().SnapY = true;
        player.GetComponent<CharacterController>().canMove = true;  
    }
}
