using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthCenterCollision : MonoBehaviour {
   
   // Collider collider = new Collider();
    public Transform healCandidate;
    public float healDelay = 1f;
    public int healAmount = 5;  
    Collider healthSphere;
    PlayerStats playerStats;
    bool candidateInSphere = false;
    // Use this for initialization
    void Start () {
       // collider = GetComponent<SphereCollider>();
        playerStats =  healCandidate.GetComponent<PlayerStats>();
        healthSphere = GetComponent<SphereCollider>();
	}

    IEnumerator HealwithDelay(int amount, float delay) {
        Debug.Log("Healing");
        bool HealisReal = true;
        while (HealisReal) { 
            HealisReal = playerStats.Heal(amount);
            yield return new WaitForSeconds(delay);
        }

      

           
    
    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform==healCandidate)
        {
            Debug.Log("player in sphere");
          
            StartCoroutine(HealwithDelay(healAmount, healDelay));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    //private void OnTriggerExit(Collider collider)
    //{
    //  if (collider.transform == healCandidate) { 
    //  Debug.Log(healCandidate.name + "Is Out of the sphere");

    //        candidateInSphere = false;}
    //}

}
