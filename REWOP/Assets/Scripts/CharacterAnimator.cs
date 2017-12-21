using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {
    Rigidbody agent;
    Animator animator;

    const float locomotionAnimationSmoothTime = .1f;
	// Use this for initialization
	void Start () {
        agent = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame  
	void FixedUpdate () {
    
            float speedPercent = agent.velocity.magnitude;// agent.speed;
        //    Debug.Log(agent.velocity.magnitude / 500);
            animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
   
	}
}
