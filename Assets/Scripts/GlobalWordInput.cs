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
    public AudioSource audioSource;
    public AudioClip typeClip;
    public AudioClip submitClip;

    public void playType(){
        audioSource.PlayOneShot(typeClip);
    }
    public void playSubmit(){
        audioSource.PlayOneShot(submitClip);
    }
    void Start()
    {
        wordActions = new Dictionary<string, Action>()
        {
            {"pow", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"clank", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"thud", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"wack", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"slam", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"clang", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"kapow", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"wham", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"thwack", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"bash", ()=>playeranimator.SetTrigger("bash_trigger")},
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
            {"slice",()=>playeranimator.SetTrigger("stab_trigger")},
            {"snip", BoltCutters},
            {"POW", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"CLANK", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"THUD", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"WACK", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"SLAM", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"CLANG", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"KAPOW", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"WHAM", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"THWACK", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"BASH", ()=>playeranimator.SetTrigger("bash_trigger")},
            {"ACHOO", Sneeze},
            {"BANG", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"BOOM", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"BAM", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"BLAM", ()=>playeranimator.SetTrigger("shoot_trigger")},
            {"RATATAT",RapidFire},
            {"WOOSH", Dash},
            {"SWOOSH", Dash},
            {"ZAP", Laser},
            {"STAB", ()=>playeranimator.SetTrigger("stab_trigger")},
            {"SWING",()=>playeranimator.SetTrigger("stab_trigger")},
            {"SCHWING",()=>playeranimator.SetTrigger("stab_trigger")},
            {"SLASH",()=>playeranimator.SetTrigger("stab_trigger")},
            {"SLICE",()=>playeranimator.SetTrigger("stab_trigger")},
            {"SNIP", BoltCutters}
        };
    }
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (char.IsLetter(c))
            {
                currentWord += (c);
                playType();
            }
            else if (c == '\b' && currentWord.Length > 0)
            {
                currentWord = currentWord.Substring(0, currentWord.Length - 1);
                playType();
            }
            else if (c == ' ')
            {
                SubmitWord();
                currentWord = ""; // reset after submit
                playSubmit();
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