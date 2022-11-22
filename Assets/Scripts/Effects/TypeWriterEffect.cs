using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{

    public Coroutine Run(string textToType, TMP_Text textLabel, int typeWriterSpeed)
    {
        return StartCoroutine(TypeText(textToType, textLabel, typeWriterSpeed));
    }

    //IEnumerator allows pauses while iterating through a collection (in this case, of letters)
    private IEnumerator TypeText(string textToType, TMP_Text textLabel, int typeWriterSpeed)
    {
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            //FloorToInt rounds down to the nearest Integer
            charIndex = Mathf.FloorToInt(t);
            //Clamp keeps charIndex between 0 and textToType.Length
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
