using UnityEngine;

public class Hideable : MonoBehaviour
{
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Hide()
    {
        if (characterController != null)
        {
            characterController.canMove = false;
        }
        transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
    }

    public void Reveal(Vector3 position)
    {
        transform.localScale = Vector3.one;
        transform.position = position;
        if (characterController != null)
        {
            characterController.canMove = true;
        }
    }
}
