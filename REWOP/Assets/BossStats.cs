using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStats :CharStats {
    public Image HealthBar;
    public Animator enemyAnimator;

    public void Start()
    {
        enemyAnimator = transform.GetComponentInChildren<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        
        base.TakeDamage(damage);
        float ch = currentHealth;
        float mh = maxHealth;
        HealthBar.fillAmount = ch / mh;
    }

    public override void Die()
    {
        base.Die();
        StartCoroutine(BossDie());
     
    }
    IEnumerator BossDie() { 
        enemyAnimator.SetTrigger("IsDie");
        yield return new WaitForSeconds(5f);
        Destroy(this);
        yield return null;
    }

    public bool IsDead()
    {
        if (currentHealth <= 0)
            return true;
        else
            return false;
    }
}
