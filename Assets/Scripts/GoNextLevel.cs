using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNextLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player"))
            GameManager.Instance.GoToNextLevel();
    }
}
