using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class PlayerScript : MonoBehaviour
{
    public int level = 3;
    private Animator animator;
    private TextMeshProUGUI levelText;
    public UnityEvent<Vector3, int> onPlayerCollectBook;
    private List<Unlocker.UnlockerColor> collectedKeys = new List<Unlocker.UnlockerColor>();
    private void Start() {
        animator = GetComponent<Animator>();
        levelText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateLevelText();
    }

    private void OnEnable() {
        Unlocker.OnKeyCollected += CollectKey;
    }

    private void OnDisable() {
        Unlocker.OnKeyCollected -= CollectKey;
    }

    public void CollectKey(Unlocker.UnlockerColor keyColor)
    {
        collectedKeys.Add(keyColor);
        Debug.Log("Player collected key: " + keyColor);
    }

    private void UpdateLevelText()
    {
        levelText.text = "LVL " + level.ToString();
        LeanTween.scale(levelText.gameObject, Vector3.one * 1.5f, 0.5f).setEasePunch().setOnComplete(() => {
            LeanTween.scale(levelText.gameObject, Vector3.one, 0.5f).setEasePunch();
        });
    }

    public void Attack()
    {
        Debug.Log("Player Attack Triggered");
        animator.SetTrigger("attack");
    }

    public void GetEnemysLevel(int level)
    {
        this.level += level;
        UpdateLevelText();
        ParticleHandler.Instance.PlayLevelUpParticles(transform.position);
    }

    public void Die()
    {
        StartCoroutine(WaitToDie());
    }

    private IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1f);
        ParticleHandler.Instance.PlayDeathParticles(transform.position);
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
        Debug.Log("Player Died...");
        yield return new WaitForSeconds(1f);
        GameManager.Instance.RestartLevel();
        Debug.Log("Player Died");
    }

    
    public bool HasKey(Unlocker.UnlockerColor _color)
    {
        return collectedKeys.Contains(_color);
    }

    public void RemoveKey(Unlocker.UnlockerColor _color)
    {
        collectedKeys.Remove(_color);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy"))
        {
            
        }
        else if(other.CompareTag("Book"))
        {
            onPlayerCollectBook.Invoke(other.transform.position, other.GetComponent<Book>().levelToGive);
            Destroy(other.gameObject);
        }
    }

    public void BookCollected(Vector3 position, int level)
    {
        ParticleHandler.Instance.PlayCollectableParticles(position);
        this.level += level;
        UpdateLevelText();

    }
}
