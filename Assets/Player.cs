using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject[] levels;
    public int i = 0;
    public bool tpToStart = false;
    // Start is called before the first frame update
    void Start()
    {
        levels[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!Application.isFocused)
        //{
        //    Cursor.visible = true;
        //}
        //else 
        //{
        //    Cursor.visible = false;
        //}

        if (!tpToStart)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision!");
        if (collision.gameObject.name.Contains("Teleporter"))
        {
            if (i != 2 && i != 3)
            {
                levels[i].gameObject.SetActive(false);
                levels[i + 1].gameObject.SetActive(true);
                i++;
            }
            else
            {
                levels[0].gameObject.SetActive(false);
                levels[1].gameObject.SetActive(false);
                levels[2].gameObject.SetActive(false);

                levels[3].gameObject.SetActive(true);
                GetComponent<AudioSource>().Play();
                i = 0;

                Thread.Sleep(7000);
                SceneManager.LoadScene("SampleScene");
            }
        }
        else
        {
            if (i != 2)
            {
                levels[0].gameObject.SetActive(true);
                levels[1].gameObject.SetActive(false);
                levels[2].gameObject.SetActive(false);
                levels[3].gameObject.SetActive(false);

                i = 0;

                transform.position = new Vector2(-7f, -4f);
                tpToStart = !tpToStart;
            }
            else
            {
                levels[0].gameObject.SetActive(false);
                levels[1].gameObject.SetActive(false);
                levels[2].gameObject.SetActive(false);

                levels[3].gameObject.SetActive(true);
                GetComponent<AudioSource>().Play();
                i = 0;
            }

        }
        
    }

    private void OnMouseOver()
    {
        tpToStart = false;
    }
}
