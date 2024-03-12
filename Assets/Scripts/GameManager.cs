using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>();
    public List<Card> player_deck = new List<Card>();
    //public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    //public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();
    public List<Transform> card_positon = new List<Transform>();

    public Transform _canvas;
    
    
    //public int d;
    public int decksize;
    
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        decksize = deck.Count;
        
        //Load Deck
        /*for (int i = 0; i < 64; i++)
        {
            d = i;
            deck[d] = CardDatabase.cardList[i];
        }*/
        
        
        
        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        Shuffle();

        for (int i = 0; i < decksize; i++)
        {
            int randomDeckCard = Random.Range(0, decksize);
            deck[i] = player_hand[randomDeckCard];

            player_hand.Add(deck[randomDeckCard]);
            deck.RemoveAt(randomDeckCard);
            //May need to be Remove or RemoveAt


            Card c1 = Instantiate(player_hand[randomDeckCard], card_positon[0]);
            c1.transform.SetParent(_canvas);
            
            
            //Use "Canvas" for parent
            //for card_position try an offset instead, so a list of positions isn't needed
        }
    }

    void Shuffle()
    {
        Debug.Log("121");
        
        /*for (int i=0; i<decksize; i++)
        {
            player_deck[0] = deck[i];
            int rnd = Random.Range(i, decksize);
            deck[i] = deck[rnd];
            deck[rnd] = player_deck[0];

        }*/
    }

    void AI_Turn()
    {

    }



    
}
