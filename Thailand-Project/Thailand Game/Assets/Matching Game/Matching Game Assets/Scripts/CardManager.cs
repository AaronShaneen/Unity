using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {

    public static CardManager instance;

    public List<Sprite> SpriteList = new List<Sprite>();

    [SerializeField] public bool chosen;

    [Header("How many pairs you want to play")]
    public int pairs;
    
    [Header("Card Prefab Button")]
    public GameObject cardPrefab;
    
    [Header("The Parent Spacer to sort Cards in")]
    public Transform spacer;

    //Particle FX
    [Header("Basic Score per Match")]
    public int matchScore = 100;

    public int choice1, choice2;

    [SerializeField]private List<GameObject> ButtonList = new List<GameObject>();
    [SerializeField] private List<GameObject> HiddenButtonList = new List<GameObject>();

    private List<GameObject> chosenCards = new List<GameObject>();

    private int lastMatchID;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        FillPlayField();
	}

    void FillPlayField()
    {
        for(int i = 0; i < (pairs * 2); i++)
        {
            GameObject newCard = Instantiate(cardPrefab, spacer);
            ButtonList.Add(newCard);
            HiddenButtonList.Add(newCard);
        }

        ShuffleCards();
    }

    void ShuffleCards()
    {
        int num = 0;
        int cardPairs = ButtonList.Count / 2;

        for(int i = 0; i < cardPairs; i++)
        {
            num++;

            //look for the cards id
            for(int j = 0; j < 2; j++)
            {
                int cardIndex = Random.Range(0, ButtonList.Count);
                Card tempCard = ButtonList[cardIndex].GetComponent<Card>();
                tempCard.id = num;
                tempCard.cardFront = SpriteList[num - 1];

                ButtonList.Remove(ButtonList[cardIndex]);
            }
        }
    }

    public void AddChosenCard(GameObject card)
    {
        chosenCards.Add(card);
    }
	
	public IEnumerator CompareCards()
    {
        if (choice2 == 0 || chosen)
        {
            yield break;
        }

        chosen = true;
        yield return new WaitForSeconds(1.5f);

        //No Match
        if((choice1 != 0 && choice2 != 0) && (choice1 != choice2))
        {
            //flip back the open cards
            FlipAllBack();

            //reset the combo in scoremanager
            ScoreManager.instance.ResetCombo();
        }
        else if ((choice1 != 0 && choice2 != 0) && (choice1 == choice2))
        {
            lastMatchID = choice1;
            //Add Score
            ScoreManager.instance.AddScore(matchScore);
            //remove the match

            //clear Chosen cards
            chosenCards.Clear();
        }
        //Reset all Choices
        choice1 = 0;
        choice2 = 0;
        chosen = false;

        //check if won
    }

    void FlipAllBack()
    {
        foreach(GameObject card in chosenCards)
        {
            card.GetComponent<Card>().CloseCard();
        }

        chosenCards.Clear();
    }

    void RemoveMatch()
    {
        for(int i = HiddenButtonList.Count - 1; i >= 0; i--)
        {
            Card tempCard = HiddenButtonList[i].GetComponent<Card>();

            if(tempCard.id == lastMatchID)
            {
                //Particle fx

                //Remove Visible
                HiddenButtonList[i].GetComponent<Image>().enabled = false;

                //Remove
                HiddenButtonList.RemoveAt(i);
            }
        }
    }

    void CheckWin()
    {
        if(HiddenButtonList.Count < 1)
        {
            //Stop Timer
            ScoreManager.instance.StopTime();

            //Show UI

            //Player Fireworks

            //Show Stars

        }
    }
}
