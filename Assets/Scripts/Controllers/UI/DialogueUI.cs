using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private int typeWriterSpeed;

    private double timeElapsedSinceClick = 0;

    private TypeWriterEffect typeWriterEffect;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        ShowDialogue(testDialogue);
    }

    private void Update()
    {
        timeElapsedSinceClick++;
        Debug.Log(timeElapsedSinceClick);
    }

    public void ShowDialogue (DialogueObject dialogueObject)
    {
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            timeElapsedSinceClick = 0;
            yield return typeWriterEffect.Run(dialogue, textLabel, typeWriterSpeed);
            yield return new WaitUntil(() => timeElapsedSinceClick >= 800);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
    }
}
