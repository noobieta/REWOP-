using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour {
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator dBoxAnimator;
    public Animator CtrlAnimator;
    public PlayerMotor playerMotor;
    Queue<string> sentences;
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue) {
        sentences.Clear();
        dBoxAnimator.SetBool("IsOpen", true);
        CtrlAnimator.SetBool("IsOpen", false);
        playerMotor.Freeze = true;
       // Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;
      

        foreach(string sentence in dialogue.sentences)
        {

            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {

            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        // Debug.Log("End of Conversation");
        playerMotor.Freeze = false;
        dBoxAnimator.SetBool("IsOpen",false);
        CtrlAnimator.SetBool("IsOpen", true);
    }
}
