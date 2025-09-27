using UnityEngine;

public class GlobalWordInput : MonoBehaviour
{
    private string currentWord = "";

    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (char.IsLetter(c))
            {
                currentWord += char.ToLower(c);
                Debug.Log("Typed so far: " + currentWord);
            }
            else if (c == '\b' && currentWord.Length > 0)
            {
                currentWord = currentWord.Substring(0, currentWord.Length - 1);
                Debug.Log("Backspace → " + currentWord);
            }
            else if (c == ' ' || c == '\n')
            {
                Debug.Log("Submitted: " + currentWord);
                currentWord = "";
            }
        }
    }
}
