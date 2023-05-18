using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Unlocker : MonoBehaviour
{
    public GameObject doorToUnlock;
    public UnlockerType unlockerType;
    public UnlockerColor unlockerColor;
    public Material openMaterial;
    public delegate void Unlock(UnlockerColor _color);
    public static event Unlock OnButtonPressed;
    public static event Unlock OnKeyCollected;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (unlockerType)
            {
                case UnlockerType.Key:
                    OnKeyCollected?.Invoke(unlockerColor);
                    Destroy(gameObject);
                    break;
                case UnlockerType.Button:
                    OnButtonPressed?.Invoke(unlockerColor);
                    GetComponent<BoxCollider>().isTrigger = true;
                    GetComponent<MeshRenderer>().materials[1].color = openMaterial.color;
                    break;
                default:
                    break;
            }
        }
    }

    public enum UnlockerType
    {
        Key,
        Button
    }

    public enum UnlockerColor
    {
        Purple,
        Blue,
        Green
    }

}
