using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject retryPanel;
    public int health;
    public int numOfHearts;
    public int coinQuantity;
    public Text textCoin;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float hitBoxCdTime;

    private ScreenFlash sf;
    private PolygonCollider2D pl2d;

    // Start is called before the first frame update
    void Start()
    {
        sf = GetComponent<ScreenFlash>();
        pl2d = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            retryPanel.SetActive(true);
        }
        
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i=0; i< hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        textCoin.text = coinQuantity.ToString();
    }

    public void DamagePlayer(int damage)
    {
        sf.FlashScreen();
        pl2d.enabled = false;
        StartCoroutine(ShowPlayerHitBox());

        if (health > 0)
        {
            health -= damage;
        }
    }

    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        pl2d.enabled = true;
    }
}
