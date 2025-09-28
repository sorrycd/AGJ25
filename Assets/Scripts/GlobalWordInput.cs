using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
public class GlobalWordInput : MonoBehaviour
{
    private string currentWord = "";
    private Dictionary<string,Action> wordActions;
    public TextMeshPro Input3DText; 
    public Animator playeranimator;
    void Start()
    {
        wordActions = new Dictionary<string, Action>()
        {
            {"pow", ()=>playeranimator.SetTrigger("punch_trigger")},
            {"clank", ()=>playeranimator.SetTrigger("punch_trigger")},
            {"thud", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"wack", ()=>playeranimator.SetTrigger("punch_trigger")},
            {"slam", ()=>playeranimator.SetTrigger("punch_trigger")},
            {"clang", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"kapow", ()=>playeranimator.SetTrigger("punch_trigger")},
            {"wham", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"thwack", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"achoo", Sneeze},
            {"bang", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"boom", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"bam", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"blam", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"ratatat",RapidFire},
            {"woosh", Dash},
            {"swoosh", Dash},
            {"zap", Laser},
            {"stab", ()=>playeranimator.SetTrigger("stab_trigger")},
            {"swing",()=>playeranimator.SetTrigger("stab_trigger")},
            {"schwing",()=>playeranimator.SetTrigger("stab_trigger")},
            {"slash",()=>playeranimator.SetTrigger("stab_trigger")},
            {"snip", BoltCutters}
        };
    }
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (char.IsLetter(c))
            {
                currentWord += (c);
            }
            else if (c == '\b' && currentWord.Length > 0)
            {
                currentWord = currentWord.Substring(0, currentWord.Length - 1);
            }
            else if (c == ' ')
            {
                SubmitWord();
                currentWord = ""; // reset after submit
            }
        }

        // Show typed word above the object
        Input3DText.text = currentWord;
    }
    void SubmitWord()
    {
        if(wordActions.ContainsKey(currentWord))
        {
            Debug.Log("Matched Word: "+currentWord);
            wordActions[currentWord].Invoke();
        }
        else
        {
            Debug.Log("No Action for: "+currentWord);
        }
        currentWord = "";
    }
    void Punch() { Debug.Log("Player Punches!"); }
    void Shoot() { Debug.Log("Player Shoots!"); }
    void RapidFire() { Debug.Log("Player RapidFires!"); }
    void Knife() { Debug.Log("Player Stabs!"); }
    void Sneeze() { Debug.Log("Player Sneezes!"); }

    void Dash() { Debug.Log("Player Dashes"); }
    void Laser() { Debug.Log("Player Shoots a Laser"); }
    void BoltCutters() { Debug.Log("Player tries to use bolt cutters"); }
}