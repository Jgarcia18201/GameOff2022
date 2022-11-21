using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{

    [SerializeField][TextArea] private string[] dialogue;

    //Can only get here, can't set here
    public string[] Dialogue => dialogue;

}
