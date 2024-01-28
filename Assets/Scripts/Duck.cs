using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Duck : MonoBehaviour
{
    Rigidbody2D rgb2D;
    public SpriteRenderer[] bodyParts;
    private bool canMove = false;
    public Vector2 velocity;
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        life = Random.Range(3, (GamaManager.gamaManager.nrLv % 8) + 4);
        rgb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(switchSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GamaManager.gamaManager.isGameStarted) return;

        canMove = true;
        if (velocity.x <= 0)
            foreach (SpriteRenderer x in bodyParts)
            {
                x.flipX = true;
            }
        else
            foreach (SpriteRenderer x in bodyParts)
            {
                x.flipX = false;
            }

        rgb2D.velocity = velocity * 1.25f * ((GamaManager.gamaManager.nrLv % 10) + 1);

        if (transform.position.y < -5) Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "terrain":
                {
                    canMove = true;
                    rgb2D.gravityScale = 0;
                }
                break;
            case "br":
                velocity = new Vector2(Random.Range(0f, GamaManager.gamaManager.nrLv + 1), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1));

                break;
            case "bl":
                velocity = new Vector2(Random.Range(-1f * (GamaManager.gamaManager.nrLv + 1), 0f), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1));

                break;
            case "bu":
                velocity = new Vector2(Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), 0f));
                break;
            case "bd":
                velocity = new Vector2(Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1), Random.Range(0f, GamaManager.gamaManager.nrLv + 1));
                break;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "terrain")
        {
            canMove = false;
            rgb2D.gravityScale = 5;


        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "terrain":
                {
                    canMove = true;
                    rgb2D.gravityScale = 0;
                }
                break;
            case "br":
                velocity = new Vector2(-1f * Random.Range(0.1f * (GamaManager.gamaManager.nrLv + 1), 0), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1));

                break;
            case "bl":
                velocity = new Vector2(Random.Range(0f, 1f * (GamaManager.gamaManager.nrLv + 1)), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1));

                break;
            case "bu":
                velocity = new Vector2(Random.Range(-1f * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), 0f));
                break;
            case "bd":
                velocity = new Vector2(Random.Range(-1f * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1), Random.Range(0f, GamaManager.gamaManager.nrLv + 1));
                break;
            case "ceb":
                {
                    Destroy(other.gameObject);
                    life--;
                    if (life <= 0)
                    {
                        GamaManager.gamaManager.happyducks++;
                        Destroy(gameObject);
                    }
                }
                break;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.collider.gameObject.tag)
        {
            case "terrain":
                {
                    canMove = true;
                    rgb2D.gravityScale = 0;
                }
                break;
            case "br":
                velocity = new Vector2(-1f * Random.Range(0.1f * (GamaManager.gamaManager.nrLv + 1), 0), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1));

                break;
            case "bl":
                velocity = new Vector2(Random.Range(0f, 1f * (GamaManager.gamaManager.nrLv + 1)), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1));

                break;
            case "bu":
                velocity = new Vector2(Random.Range(-1f * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), 0f));
                break;
            case "bd":
                velocity = new Vector2(Random.Range(-1f * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1), Random.Range(0f, GamaManager.gamaManager.nrLv + 1));
                break;
            case "ceb":
                {
                    Destroy(other.gameObject);
                    life--;
                    GamaManager.gamaManager.happyducks++;
                    if (life <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
                break;

        }
    }

    private IEnumerator switchSpeed()
    {
        while (true)
        {
            velocity = new Vector2(Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1), Random.Range(-1 * (GamaManager.gamaManager.nrLv + 1), GamaManager.gamaManager.nrLv + 1));
            yield return new WaitForSecondsRealtime(2f);
        }
    }
}

