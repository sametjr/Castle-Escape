using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{
    private void Start() {
        //rotate around
        LeanTween.rotateAround(gameObject, Vector3.up, 360f, 2f).setLoopClamp();
        //move up and down
        LeanTween.moveY(gameObject, 1f, 2f).setLoopPingPong();
    }
}
