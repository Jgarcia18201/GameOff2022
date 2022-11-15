using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    private RectTransform dragCard;
    public Card Card;

    public Image cardImage;
    public TextMeshProUGUI cardName, cardDescription, cardPower, cardCost, cardHealth;
    private Transform originalParent;

    Vector3 cachedScale;
    Vector3 cachedPosition;
    Vector3 dropPos;
    Vector3 translatePos;

    private void Awake()
    {
        dragCard = transform as RectTransform;
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
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        dropPos = eventData.position;
        if(dropPos.y > 400 && dropPos.y < 750 || dropPos.y > 0 && dropPos.y < 200)
        {
            Debug.Log("Valid Drop: y = " + dropPos.y + ", x = " +  dropPos.x);
            translatePos = new Vector3(dropPos.x - 960.0f, dropPos.y, dropPos.z);
            cachedPosition = translatePos;
        } else
        {
            Debug.Log("Invalid Drop: y = " + dropPos.y + ", x = " + dropPos.x);
        }
    }
}
