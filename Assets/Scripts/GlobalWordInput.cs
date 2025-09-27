using UnityEngine;
using TMPro;

public class GlobalWordInput : MonoBehaviour
{
    private string currentWord = "";
    public TextMeshPro Input3DText; 

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
                currentWord = ""; // reset after submit
            }
        }

        // Show typed word above the object
        Input3DText.text = currentWord;
    }
}
