using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropArea : MonoBehaviour, IDropHandler{

    public enum DropAreaType { TABLEAU, FREECELL, FOUNDATION};

    public DropAreaType myDropAreaType;

    public CardInfo.CardSuit mySuit;

    public Stack<GameObject> cardStack;

    private GameRulesManager rules; 

    public void Awake()
    {
        cardStack = new Stack<GameObject>();
    }

    public void Start()
    {
        rules = GameRulesManager._instance;
        
    }

    //handles what happens when cards are attempted to be put onto each type of card holding location
	public void OnDrop(PointerEventData pointerData)
    {
        DraggableObject droppedCard = pointerData.pointerDrag.GetComponent<DraggableObject>();
        CardInfo droppedCardInfo = pointerData.pointerDrag.GetComponent<CardInfo>();

        //make sure card being dropped here can be moved
        if(droppedCard != null && droppedCard.GetComponent<DraggableObject>().canBeDragged == true && droppedCard.oldParent.GetComponent<CardDropArea>().myDropAreaType != CardDropArea.DropAreaType.FOUNDATION)
        {
            
            //check to make sure the move is valid
            if(rules.isMoveValid(this, pointerData.pointerDrag.GetComponent<CardInfo>()))
            {
                droppedCard.oldParent.GetComponent<CardDropArea>().cardStack.Pop();
                droppedCard.oldParent = this.transform;

                //check for empty stacks
                if (cardStack.Count != 0)
                {
                    cardStack.Peek().GetComponent<DraggableObject>().setCanBeDragged(false);
                }
                cardStack.Push(pointerData.pointerDrag);

                //handle each type of area
                switch(myDropAreaType)
                {
                    case DropAreaType.TABLEAU:
                        {
                            droppedCard.GetComponent<DraggableObject>().setCanBeDragged(false);
                            rules.updateStacks();
                            break;
                        }

                    case DropAreaType.FREECELL:
                        {
                            rules.updateStacks();
                            break;
                        }

                    case DropAreaType.FOUNDATION:
                        {
                            droppedCard.GetComponent<DraggableObject>().setCanBeDragged(false);
                            Instantiate<ParticleSystem>(rules.successParticle, droppedCard.transform);
                            rules.updateStacks();
                            break;
                        }
                }

                
            }
            
        }
        //rules.updateStacks();
        rules.checkForWin();
    }

    //grabs the top card on the stack and sets it to draggable. Used after cards have been moved
    public void updateStack()
    {

        switch(myDropAreaType)
        {
            //set the top card in a cascade to be draggable
            case DropAreaType.TABLEAU:
                {
                    if (cardStack.Count != 0)
                    {
                        GameObject topCard = cardStack.Peek();
                        topCard.gameObject.GetComponent<DraggableObject>().setCanBeDragged(true);
                    }
                    break;
                }

            //don't need to do anything here, only 1 card allowed here
            case DropAreaType.FREECELL:
                {

                    break;
                }

            //set as such so that the card snapping still works. 
            case DropAreaType.FOUNDATION:
                {
                    if (cardStack.Count != 0)
                    {
                        GameObject topCard = cardStack.Peek();
                        topCard.gameObject.GetComponent<DraggableObject>().setCanBeDragged(true);
                    }

                    break;
                }
        }
        
    }



}
