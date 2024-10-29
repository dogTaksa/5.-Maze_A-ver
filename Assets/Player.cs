using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject[] levels;
    public int i = 0;
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

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision!");
        if (collision.gameObject.name == "Teleporter")
        {
            if (i != 2)
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
            }
        }
        else
        {
            levels[0].gameObject.SetActive(false);
            levels[1].gameObject.SetActive(false);
            levels[2].gameObject.SetActive(false);

            levels[3].gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
            i = 0;
            SceneManager.LoadScene("SampleScene");
        }
        
    }
}
