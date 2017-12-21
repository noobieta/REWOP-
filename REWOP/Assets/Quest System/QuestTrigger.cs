using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {
    private QuestManager QM;
    public int questNumber;
    public bool IsStartQuest;
    
 
	// Use this for initialization
	void Start () {
        QM = FindObjectOfType<QuestManager>(); 	
      
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player")
        {
            if (!QM.questCompleted[questNumber])
            {
                if (IsStartQuest && !QM.quests[questNumber].gameObject.activeSelf)//
                {
                    StartQuest();
                }
               else if (!IsStartQuest && QM.quests[questNumber].gameObject.activeSelf) {
                    EndQuest();
                }
            }
        }
	}

    void StartQuest() {
        if (checkChronologicalQuest())
        {
            QM.activeQuest = questNumber;
            QM.quests[questNumber].gameObject.SetActive(true);
            QM.quests[questNumber].StartQuest();
        }
    }
    void EndQuest() {
        QM.activeQuest = -1;
        QM.quests[questNumber].EndQuest();
    }
    private bool checkChronologicalQuest() {
        bool check = true;
        if (questNumber == 0) return true;

        for (int i = questNumber-1; i >=0; i--)
        {
            Debug.Log("checking quest " + i);
            if (QM.questCompleted[i] == false)
                check = false;
        }
        if (check)
            Debug.Log("Quests before Quest " + questNumber + " is completed");
        else
            Debug.Log("Quests before Quest " + questNumber + " is NOT completed");
        return check;
    }
}
