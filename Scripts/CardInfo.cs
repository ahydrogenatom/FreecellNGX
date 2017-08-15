using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour {

    //set all card values as enum
    public enum CardValue { ACE = 1, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5, SIX = 6, SEVEN = 7, EIGHT = 8, NINE = 9, TEN = 10, JACK = 11, QUEEN = 12, KING = 13 };

    public CardValue myValue;

    //set up suits as enums
    public enum CardSuit { HEARTS = 1, CLUBS = 2, DIAMONDS = 3, SPADES = 4, NULL = 0};

    public CardSuit mySuit;

    private Image cardImage;

    public CardData data = new CardData();

    public void Awake()
    {
        cardImage = gameObject.GetComponent<Image>();
    }

    public void Start()
    {
        
    }
    
    //gets the card variables for suit and value, and sets the correct sprite
    public void setupCard()
    {
        //switch on each individual card value to assign correct sprite image
        switch(myValue)
        {
            //ACES
            case CardValue.ACE:
                {
                    //switch on suits within certain card value
                    switch(mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("ace_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("ace_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("ace_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("ace_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //TWOS
            case CardValue.TWO:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("2_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("2_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("2_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("2_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //THREES
            case CardValue.THREE:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("3_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("3_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("3_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("3_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //FOURS
            case CardValue.FOUR:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("4_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("4_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("4_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("4_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //FIVES
            case CardValue.FIVE:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("5_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("5_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("5_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("5_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //SIXES
            case CardValue.SIX:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("6_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("6_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("6_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("6_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //SEVENS
            case CardValue.SEVEN:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("7_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("7_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("7_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("7_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //EIGHTS
            case CardValue.EIGHT:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("8_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("8_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("8_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("8_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //NINES
            case CardValue.NINE:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("9_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("9_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("9_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("9_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //TENS
            case CardValue.TEN:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("10_of_clubs");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("10_of_diamonds");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("10_of_hearts");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("10_of_spades");
                                break;
                            }
                    }
                    break;
                }

            //JACKS
            case CardValue.JACK:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("jack_of_clubs2");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("jack_of_diamonds2");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("jack_of_hearts2");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("jack_of_spades2");
                                break;
                            }
                    }
                    break;
                }

            //QUEENS
            case CardValue.QUEEN:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("queen_of_clubs2");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("queen_of_diamonds2");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("queen_of_hearts2");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("queen_of_spades2");
                                break;
                            }
                    }
                    break;
                }

            //KINGS
            case CardValue.KING:
                {
                    //switch on suits within certain card value
                    switch (mySuit)
                    {
                        case CardSuit.CLUBS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("king_of_clubs2");
                                break;
                            }

                        case CardSuit.DIAMONDS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("king_of_diamonds2");
                                break;
                            }

                        case CardSuit.HEARTS:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("king_of_hearts2");
                                break;
                            }

                        case CardSuit.SPADES:
                            {
                                cardImage.sprite = Resources.Load<Sprite>("king_of_spades2");
                                break;
                            }
                    }
                    break;
                }
        }

        data.mySuit = mySuit;
        data.myValue = myValue;
    }

}


//serializable data struct to hold card info
[Serializable]
public class CardData
{
    public CardInfo.CardSuit mySuit;
    public CardInfo.CardValue myValue;
}
