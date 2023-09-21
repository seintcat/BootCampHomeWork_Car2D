using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    private Transform carTransform;
    [SerializeField]
    private float destroyTime = 0.5f;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color hasPakageColor = new Color(1, 0, 0, 1);
    [SerializeField]
    private Color noPakageColor = new Color(1, 1, 1, 1);
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private Pizza pizza;

    private void Start()
    {
        scoreText.text = 0 + "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionEnter2D");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pizza" && pizza == null)
        {
            collision.transform.SetParent(carTransform);
            pizza = collision.gameObject.GetComponent<Pizza>();
            spriteRenderer.color = hasPakageColor;
        }
        else if (collision.tag == "Customer" && pizza != null)
        {
            pizza.Spawn();
            pizza.transform.SetParent(null);
            pizza = null;
            spriteRenderer.color = noPakageColor;

            GameManager.instance.CheckNextStage();
            GameManager.instance.score++;
            scoreText.text = GameManager.instance.score + "";
        }
    }
}
