using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>();
    public List<Card> player_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();
    
    public float offset;
    public float shiftOffset;
    public Transform _canvas;
    
    //don't use this int for actual aihealth
    public float aiHealth;

    //public bool destroyCard;

    //public GameObject cardSelected;
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
    
    void Start()
    {
        offset = -300;
        shiftOffset = 0;
        DealOpponent();
        Deal();
    }
 void Deal()
    {
        int dealSize = 4;

        for (int i = 0; i < dealSize; i++)
        {
            int randomCard = Random.Range(0, player_deck.Count);

            Card randomDeckCard = Instantiate(player_deck[randomCard],
                new Vector3(transform.position.x + offset, 200, 0), Quaternion.identity);
            player_hand.Add(randomDeckCard);
            //player_hand[randomCard].gameObject.SetActive(true);
            randomDeckCard.transform.SetParent(_canvas);
            player_deck.RemoveAt(randomCard);
            offset += 200;
            //May need to be Remove or RemoveAt

            //Use "Canvas" for parent
            //for card_position try an offset instead, so a list of positions isn't needed
        }
    }

    void DealOpponent()
    {
        int dealSize = 1;

        for (int i = 0; i < dealSize; i++)
        {
            int randomCard = Random.Range(0, deck.Count);

            Card randomDeckCard = Instantiate(deck[randomCard], new Vector3(transform.position.x, 600, 0),
                Quaternion.identity);
            ai_hand.Add(randomDeckCard);
            randomDeckCard.transform.SetParent(_canvas);
            deck.RemoveAt(randomCard);
        }

        aiHealth = 3;
        Debug.Log("Heath" + aiHealth);
    }
   public int SlotNumber()
    {
        for (int i = 0; i <= 3; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
                return i;
        }

        return -1;
    }
    
    void Update()
    {
        if (SlotNumber() >= 0)
        {
            Debug.Log("SlotNumber:" + SlotNumber());
            PlayCard();
        }
    }
    
    void PlayCard()
    {
        //int cardDamage = player_hand[SlotNumber()].GetComponent<damage>();
        //find out card damage, player_hand, use Get.Component
        //deal card damage
        aiHealth -= 1;
        Debug.Log("Health" + aiHealth);
        
        //delete card
        discard_pile.Add(player_hand[SlotNumber()]);
        player_hand[SlotNumber()].gameObject.SetActive(false);
        //Destroy(player_hand[SlotNumber()]);
        
        //shift cards in hand
        
        //At end set SlotNumber() = -1;
        
        HandShift();
    }

    void HandShift()
    {
        
        for (int i = 3; i > SlotNumber(); i--)
        {
            Debug.Log("Ran");
            
            player_hand[i].gameObject.transform.position = transform.position + new Vector3(100 - shiftOffset, 200, 0);
            shiftOffset += 200;
        }
        //shiftOffset = 0;

        //Wait for 2 seconds
        //StartCoroutine(Wait(2));

        player_hand.RemoveAt(SlotNumber());
        Draw();
        //AiTurn();

    }

    void Draw()
    {
        int drawSize = 1;

        for (int i = 0; i < drawSize; i++)
        {
            int randomCard = Random.Range(0, player_deck.Count);

            Card randomDeckCard = Instantiate(player_deck[randomCard],
                new Vector3(transform.position.x + offset - 200, 200, 0), Quaternion.identity);
            player_hand.Add(randomDeckCard);
            //player_hand[randomCard].gameObject.SetActive(true);
            randomDeckCard.transform.SetParent(_canvas);
            player_deck.RemoveAt(randomCard);
            //May need to be Remove or RemoveAt

            //Use "Canvas" for parent
            //for card_position try an offset instead, so a list of positions isn't needed
        }
    }
    
    //Wait function for HandShift, use when needed
    /*IEnumerator Wait(float duration)
    {
        //This is a coroutine
        Debug.Log("Start Wait() function. The time is: "+Time.time);
        Debug.Log( "Float duration = "+duration);
        yield return new WaitForSeconds(duration);   //Wait
        Debug.Log("End Wait() function and the time is: "+Time.time);
    }*/
    
   
    void AiTurn()
        {
            if (aiHealth < 1)
            {
                //destroy current opponent
                discard_pile.Add(ai_hand[0]);
                ai_hand.RemoveAt(0);
                //deal new opponent
                DealOpponent();
            }
            else
            {
                Debug.Log("Enemy Attacks");
                AiAttack();
            }
            //check if health = 0
            //if health = 0, delete opponent
            //if health != 0, deal damage
        }

    void AiAttack()
    {
        int hitChance = Random.Range(0, 2);
        if (hitChance < 1)
        {
            Debug.Log("Enemy Hit");
        }
        else
        {
            Debug.Log("Enemy Missed");
        }
    }
}