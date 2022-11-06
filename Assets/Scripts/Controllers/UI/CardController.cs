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

    Vector3 cachedScale;
    Vector3 cachedPosition;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    private void Start()
    {
        cachedScale = transform.localScale;
        cachedPosition = transform.localPosition;
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
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        transform.localPosition = new Vector3(0, 100, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = cachedScale;
        transform.localPosition = cachedPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        transform.SetParent(transform.root);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        transform.position = eventData.position;
    }
}
