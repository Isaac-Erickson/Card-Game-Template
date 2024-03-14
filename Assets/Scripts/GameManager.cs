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
    //public List<Transform> card_positon = new List<Transform>();
    
    public float offset;
    
    public Transform _canvas;
    
    
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
        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {

        int dealSize = 1;
        
        for (int i = 0; i < dealSize; i++)
        {
            int randomCard = Random.Range(0, deck.Count);
            
            Card randomDeckCard = Instantiate(deck[randomCard], new Vector3(transform.position.x + offset, 200, 0), Quaternion.identity);
            player_hand.Add(randomDeckCard);
            randomDeckCard.transform.SetParent(_canvas);
            deck.RemoveAt(randomCard);
            offset += 200;
            //May need to be Remove or RemoveAt
            
            //Use "Canvas" for parent
            //for card_position try an offset instead, so a list of positions isn't needed
        }
    }

    void Shuffle()
    {
        
    }

    void AI_Turn()
    {

    }



    
}
