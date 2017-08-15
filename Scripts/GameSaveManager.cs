using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour {

    public static CardContainer cardSaveData = new CardContainer();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //save all current card info from the game manager
    public static void saveDeck()
    {
        GameObject[] cascades = GameRulesManager._instance.tableaus;

        foreach(GameObject cascade in cascades)
        {
            Stack<GameObject> currentCascade = cascade.GetComponent<CardDropArea>().cardStack;

            //make a clone of current stack to deconstruct and get data from
            Stack<GameObject> stackCopy = new Stack<GameObject>(currentCascade);

            while(stackCopy.Count > 0)
            {
                GameObject currentCard = stackCopy.Pop();
                addCardData(currentCard.GetComponent<CardInfo>().data);
            }
        }

    }

    //create new deck based on JSON data
    public static GameObject[] loadDeck(CardContainer cardObject)
    {
        GameObject[] newDeck = new GameObject[52];
        GameObject cardPrefab = GameRulesManager._instance.card;

        int counter = 0;

        foreach(CardData card in cardObject.cards)
        {
            //create new card
            GameObject newCard = Instantiate<GameObject>(cardPrefab);
            //fill new card info with loaded data
            newCard.GetComponent<CardInfo>().mySuit = card.mySuit;
            newCard.GetComponent<CardInfo>().myValue = card.myValue;
            //put new card into deck
            newDeck[counter] = newCard;
            counter++;
        }

        return newDeck;
    }

    //adds single card data to the List
    public static void addCardData(CardData data)
    {
        cardSaveData.cards.Add(data);
    }


    //load in card save data from JSON file
    public static CardContainer LoadCards(string filepath)
    {
        string jsonData = File.ReadAllText(filepath);
        return JsonUtility.FromJson<CardContainer>(jsonData);
    }

    //save card data out to a JSON file
    public static void SaveCards(string filepath)
    {
        string jsonData = JsonUtility.ToJson(cardSaveData);

        StreamWriter writer = File.CreateText(filepath);
        writer.Close();

        File.WriteAllText(filepath, jsonData);
    }


}
