using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharStats {
 
    public override void Die()
    {
        base.Die();
        //Kill player
        PlayerManager.instance.KillPlayer();
    }
    public override bool Heal(int amount)
    {
        if (base.Heal(amount)) return true;
        else return false;
    }
    public void KillPlayer()
    {
        TakeDamage(maxHealth);
    }

    public bool IsDead()
    {
        if (currentHealth <= 0)
            return true;
        else
            return false;
    }

}
