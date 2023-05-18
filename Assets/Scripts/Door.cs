using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Unlocker.UnlockerColor unlockerColor;
    public Vector3 openPosition;
    public Material openMaterial;
    private Vector3 closedPosition;
    private Material closedMaterial;

    private void Start()
    {
        closedPosition = transform.position;
        closedMaterial = GetComponent<MeshRenderer>().material;
    }
    internal void Open()
    {
        Debug.Log("Door: Open");
        LeanTween.move(gameObject, openPosition, 1f).setEaseOutQuad();
        // transform.position = openPosition;
        GetComponent<MeshRenderer>().material = openMaterial;
    }

    internal void Close()
    {
        Debug.Log("Door: Close");
        LeanTween.move(gameObject, closedPosition, 1f).setEaseOutQuad();
        GetComponent<MeshRenderer>().material = closedMaterial;
    }
}
