using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameRulesManager : MonoBehaviour {

    public static GameRulesManager _instance = null;

    public GameObject[] tableaus;
    public GameObject[] foundations;
    public GameObject[] freecells;

    public ParticleSystem successParticle;

    public GameObject card;

    //create and maintain singleton
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
    //Default initializes random deck
    //Functionality available to load deck from file
	void Start () {
        GenerateDeck();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //iterate through all stacks and ensure the top card is usable
    public void updateStacks()
    {
        foreach(GameObject tableau in tableaus)
        {
            tableau.GetComponent<CardDropArea>().updateStack();
        }

        foreach(GameObject foundation in foundations)
        {
            foundation.GetComponent<CardDropArea>().updateStack();
        }
    }

    //use JSON data to generate a specific deck
    public void LoadDeck(string filepath)
    {
        //load card data object from file
        CardContainer newCards = GameSaveManager.LoadCards(filepath);
        //convert data object into card array to populate tableaus
        GameObject[] cards = GameSaveManager.loadDeck(newCards);
        //assign shuffled deck to tableaus
        for (int i = 0; i < 52; i++)
        {

            if (i >= 0 && i < 7)
            {
                tableaus[0].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[0].transform);
            }
            else if (i >= 7 && i < 14)
            {
                tableaus[1].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[1].transform);
            }
            else if (i >= 14 && i < 21)
            {
                tableaus[2].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[2].transform);
            }
            else if (i >= 21 && i < 28)
            {
                tableaus[3].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[3].transform);
            }
            else if (i >= 28 && i < 34)
            {
                tableaus[4].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[4].transform);
            }
            else if (i >= 34 && i < 40)
            {
                tableaus[5].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[5].transform);
            }
            else if (i >= 40 && i < 46)
            {
                tableaus[6].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[6].transform);
            }
            else
            {
                tableaus[7].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[7].transform);
            }
        }

        foreach (GameObject tableau in tableaus)
        {
            tableau.GetComponent<CardDropArea>().updateStack();
        }
    }

    //create new deck from scratch. This is used by default
    public void GenerateDeck()
    {
        //create 52 cards
        GameObject[] cards = new GameObject[52];
        for(int i = 0; i < 52; i++)
        {
            cards[i] = Instantiate<GameObject>(card);

            //loop through and assign correct values

            //assign suits
            if(i >= 0 && i < 13)
            {
                cards[i].GetComponent<CardInfo>().mySuit = CardInfo.CardSuit.HEARTS;
            }
            else if(i >= 13 && i < 26)
            {
                cards[i].GetComponent<CardInfo>().mySuit = CardInfo.CardSuit.CLUBS;
            }
            else if (i >= 26 && i < 39)
            {
                cards[i].GetComponent<CardInfo>().mySuit = CardInfo.CardSuit.DIAMONDS;
            }
            else
            {
                cards[i].GetComponent<CardInfo>().mySuit = CardInfo.CardSuit.SPADES;
            }

            //calculate and assign card value based on i % 13
            int currentRemainder = i % 13;
            switch(currentRemainder)
            {
                case 0:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.ACE;
                        break;
                    }

                case 1:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.TWO;
                        break;
                    }

                case 2:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.THREE;
                        break;
                    }

                case 3:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.FOUR;
                        break;
                    }

                case 4:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.FIVE;
                        break;
                    }

                case 5:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.SIX;
                        break;
                    }

                case 6:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.SEVEN;
                        break;
                    }

                case 7:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.EIGHT;
                        break;
                    }

                case 8:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.NINE;
                        break;
                    }

                case 9:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.TEN;
                        break;
                    }

                case 10:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.JACK;
                        break;
                    }

                case 11:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.QUEEN;
                        break;
                    }

                case 12:
                    {
                        cards[i].GetComponent<CardInfo>().myValue = CardInfo.CardValue.KING;
                        break;
                    }
            }

            cards[i].GetComponent<CardInfo>().setupCard();
        }



        //shuffle deck

        System.Random RNG = new System.Random();

        for(int i = 0; i < 52; i++)
        {
            int j = RNG.Next(i, 52);
            GameObject temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }

        //assign shuffled deck to tableaus
        for(int i = 0; i < 52; i++)
        {

            if (i >= 0 && i < 7)
            {
                tableaus[0].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[0].transform);
            }
            else if (i >= 7 && i < 14)
            {
                tableaus[1].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[1].transform);
            }
            else if (i >= 14 && i < 21)
            {
                tableaus[2].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[2].transform);
            }
            else if (i >= 21 && i < 28)
            {
                tableaus[3].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[3].transform);
            }
            else if (i >= 28 && i < 34)
            {
                tableaus[4].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[4].transform);
            }
            else if (i >= 34 && i < 40)
            {
                tableaus[5].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[5].transform);
            }
            else if (i >= 40 && i < 46)
            {
                tableaus[6].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[6].transform);
            }
            else
            {
                tableaus[7].GetComponent<CardDropArea>().cardStack.Push(cards[i]);
                cards[i].transform.SetParent(tableaus[7].transform);
            }
        }

        //ensure top cards are playable
        foreach(GameObject tableau in tableaus)
        {
            tableau.GetComponent<CardDropArea>().updateStack();
        }
    }


    //checks for a game victory
    public void checkForWin()
    {
        //kings on top of foundations used to check for a win
        int numOfKings = 0;

        foreach(GameObject foundation in foundations)
        {
            //avoid null error in checking empty stack
            if(foundation.GetComponent<CardDropArea>().cardStack.Count > 0)
            {
                //check if top card is a king. the suits are handled in checking valid moves
                if (foundation.GetComponent<CardDropArea>().cardStack.Peek().GetComponent<CardInfo>().myValue == CardInfo.CardValue.KING)
                {
                    numOfKings++;
                }
            }
            
        }

        //load victory screen if all 4 foundations have kings on top
        if(numOfKings == 4)
        {
            SceneManager.LoadScene("EndScene");
        }

       
    }
    
    //checks validity of moves based on standard rules
    public bool isMoveValid(CardDropArea dropArea, CardInfo card)
    {
        bool isValid = false;

        CardDropArea.DropAreaType currentType = dropArea.myDropAreaType;

        //check rule based on drop area type
        switch(currentType)
        {
            //as long as freecell is empty, card drop is good
            case CardDropArea.DropAreaType.FREECELL:
                {
                    if (dropArea.cardStack.Count == 0)
                    {
                        isValid = true;
                    }
                    else isValid = false;
                    break;
                }

            //check the foundations
            case CardDropArea.DropAreaType.FOUNDATION:
                {
                    //check for same suit
                    if (dropArea.mySuit == card.mySuit)
                    {
                        //check for empty foundation, make sure it's the right ace
                        if (dropArea.cardStack.Count == 0)
                        {
                            if (card.myValue == CardInfo.CardValue.ACE)
                            {
                                isValid = true;
                            }
                            else isValid = false;
                        }
                        //if foundation started, check for next value card
                        else if ((int)card.myValue == (int)dropArea.cardStack.Peek().GetComponent<CardInfo>().myValue + 1)
                        {
                            isValid = true;
                        }
                        else isValid = false;
                    }
                    else isValid = false;
                    break;
                }

            //check the cascades
            case CardDropArea.DropAreaType.TABLEAU:
                {
                    //if empty cascade, any card can be placed
                    if(dropArea.cardStack.Count == 0)
                    {
                        isValid = true;
                        break;
                    }
                    //check for correct suits
                    if ((int)dropArea.cardStack.Peek().GetComponent<CardInfo>().mySuit % 2 != (int)card.mySuit % 2)
                    {

                        //check for descending card order
                        if ((int)card.myValue == (int)dropArea.cardStack.Peek().GetComponent<CardInfo>().myValue - 1)
                        {
                            isValid = true;
                        }
                        else isValid = false;
                    }
                    else isValid = false;
                    break;
                }
        }

        return isValid;
    }

    
}
