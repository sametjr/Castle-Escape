using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : Door
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            if(other.gameObject.GetComponent<PlayerScript>().HasKey(unlockerColor))
            {
                other.gameObject.GetComponent<PlayerScript>().RemoveKey(unlockerColor);
                Open();
                ParticleHandler.Instance.PlayDoorOpenParticles(transform.position);
            }
        }
    }
}
