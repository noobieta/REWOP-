using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharStats{
    public Image HealthBar;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        float ch = currentHealth;
        float mh = maxHealth;
        HealthBar.fillAmount = ch / mh;
    }
    
    public override void Die() {
 
        base.Die();
        Transform player = PlayerManager.instance.player.transform;
        CollisionObjects ColObj = player.GetChild(1).GetComponent<CollisionObjects>();
        ColObj.items.Remove(this.gameObject);
        // Add ragdoll effect

        Destroy(gameObject);
    }
}
