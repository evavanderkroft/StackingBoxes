using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // when trigger gets triggered, set bool gameover on true
        if (other.gameObject.tag == "FallingPrefabs")
        {
            gamemanager.gameOver = true;
            SceneManager.LoadScene("gameOver");
        }

    }
}
