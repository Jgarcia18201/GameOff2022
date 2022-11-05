using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

//Not MonoBehaviour because this class only holds data and has no behavior
public class Card
{
    public string cardName;
    public string cardDescription;
    public int cardCost, cardHealth, cardPower;
    public Sprite cardImage;
}
