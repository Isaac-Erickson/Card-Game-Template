using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>();
    public List<Card> player_deck = new List<Card>();
    //public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    //public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();

    public Transform cardPos1;
    public Transform cardPos2;
    
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
    Shuffle();

    Card c1 = Instantiate(deck[0], cardPos1);
    Card c2 = Instantiate(deck[1], cardPos2);
    }

    void Shuffle()
    {
        Debug.Log("121");
    }

    void AI_Turn()
    {

    }



    
}
