using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnemyScript : MonoBehaviour
{
    public int level;
    private Animator animator;
    private TextMeshProUGUI levelText;
    [SerializeField] private PlayerScript playerScript;
    private void Start() {
        levelText = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        UpdateLevelText();

    }


    private void UpdateLevelText()
    {
        levelText.text = "LVL " + level.ToString();
    }

    public void Die()
    {
        StartCoroutine(WaitToDie());
    }

    private IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1f);
        ParticleHandler.Instance.PlayDeathParticles(transform.position);
        playerScript.GetEnemysLevel(level);
        Destroy(gameObject);
    }

    public void Attack()
    {
        animator.SetTrigger("attack");
    }

    
}
