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
    
    int randomDeckRange = Random.Range(0, decksize);
    
    player_hand.Add(deck[randomDeckRange]);
    deck.Remove(deck[randomDeckRange]);

    //Card c1 = Instantiate(deck[0], card_positon[0]); 
    //Use "Canvas" for parent
    //card_positon[0]
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
