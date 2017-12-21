using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAttack : MonoBehaviour {
    public QuestManager QM;
    public int questNumber;
    public GameObject Sword;
    public GameObject Attack;
    private void Start()
    {
        QM = FindObjectOfType<QuestManager>();
       // Sword.SetActive(!true);
       // Attack.SetActive(!true);
    }

    private void OnEnable()
    {
        QuestObject.OnQuestStart += Attacks;
    }
    private void OnDisable()
    {
        QuestObject.OnQuestStart -= Attacks;
    }

    void Attacks()
    {
        if (QM.activeQuest == questNumber)
            Sword.SetActive(true);
            Attack.SetActive(true);
        



    }
}
