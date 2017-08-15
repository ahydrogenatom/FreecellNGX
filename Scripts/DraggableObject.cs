using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * class to handle dragging objects with the mouse pointer
 * */

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameRulesManager rules;

    public Transform oldParent = null;

    public bool canBeDragged;

    public void Start()
    {
        rules = GameRulesManager._instance;
        print("can be dragged starting value: " + canBeDragged);
        oldParent = this.transform.parent;
    }

    public void setCanBeDragged(bool newCanBeDragged)
    {
        canBeDragged = newCanBeDragged;
        print("can be dragged: " + canBeDragged);
    }

    //when player grabs a card with mouse
	public void OnBeginDrag(PointerEventData pointerData)
    {
        if(oldParent.GetComponent<CardDropArea>()!= null)
        {
            if(oldParent.GetComponent<CardDropArea>().myDropAreaType != CardDropArea.DropAreaType.FOUNDATION)
            {
                if (canBeDragged == true)
                {
                    oldParent = this.transform.parent;


                    this.transform.SetParent(this.transform.parent.parent);

                    //set in order to enable dropping cards onto other UI panels
                    GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }
        }

        
        
    }

    //while card is being dragged by player
    public void OnDrag(PointerEventData pointerData)
    {
        if (oldParent.GetComponent<CardDropArea>() != null)
        {
            if (oldParent.GetComponent<CardDropArea>().myDropAreaType != CardDropArea.DropAreaType.FOUNDATION)
            {
                if (canBeDragged == true)
                {
                    this.transform.position = pointerData.position;
                }
            }
        }
    }

    //when player releases card
    public void OnEndDrag(PointerEventData pointerData)
    {
        if (canBeDragged == true)
        {
            this.transform.SetParent(oldParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            
        }
    }
}
