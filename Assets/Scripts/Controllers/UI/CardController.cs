using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Card Card;

    public Image cardImage;
    public TextMeshProUGUI cardName, cardDescription, cardPower, cardCost, cardHealth;
    private Transform originalParent;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    //Assign TextMeshPro data to Card script
    public void Initialize(Card card)
    {
        this.Card = card;
        cardImage.sprite = card.cardImage;
        cardName.text = card.cardName;
        cardDescription.text = card.cardDescription;
        cardCost.text = card.cardCost.ToString();
        cardHealth.text = card.cardHealth.ToString();
        cardPower.text = card.cardPower.ToString();
        originalParent = transform.parent;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Works");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetParent(transform.root);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
