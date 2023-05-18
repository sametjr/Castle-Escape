using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Door
{
    private void OnEnable() {
        Unlocker.OnButtonPressed += OpenDoor;
    }

    private void OnDisable() {
        Unlocker.OnButtonPressed -= OpenDoor;
    }
    public void OpenDoor(Unlocker.UnlockerColor _color)
    {
        Open();
        ParticleHandler.Instance.PlayDoorOpenParticles(transform.position);
    }
}
