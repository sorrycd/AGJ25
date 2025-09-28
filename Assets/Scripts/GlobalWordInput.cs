using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
public class GlobalWordInput : MonoBehaviour
{
    private string currentWord = "";
    private Dictionary<string,Action> wordActions;
    public TextMeshPro Input3DText; 
    void Start()
    {
        wordActions = new Dictionary<string, Action>()
        {
            {"pow", Punch},
            {"clank", Punch},
            {"thud", Punch},
            {"wack", Punch},
            {"slam", Punch},
            {"clang", Punch},
            {"kapow", Punch},
            {"wham", Punch},
            {"achoo", Sneeze},
            {"bang", Shoot},
            {"boom", Shoot},
            {"bam", Shoot},
            {"blam", Shoot},
            {"ratatat",RapidFire},
            {"woosh", Dash},
            {"swoosh", Dash},
            {"zap", Laser},
            {"stab", Knife},
            {"swing",Knife},
            {"schwing",Knife},
            {"slash",Knife},
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
