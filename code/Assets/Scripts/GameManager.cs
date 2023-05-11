using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] MyObjects;
    private GameObject currentBlock = null;
    private Rigidbody2D currentRigidBody;
    private Vector2 blockStartPosition = new Vector2(0f, 4f);
    public bool gameOver = false;
    private float blockSpeed = 8f;
    public List<GameObject> AllBlocks = new List<GameObject>();
    public GameObject Camera;
    public int scoreCount;

    public scoremanager scoremanager;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn a new block on start
        SpawnNewBlock();
    }

    private void SpawnNewBlock()
    {
        // check if game is game over
        if (gameOver == false)
        {
            // spawn a random block from the gameObject array
            int randomIndex = Random.Range(0, MyObjects.Length);
            currentBlock = Instantiate(MyObjects[randomIndex]);
            // set position for the block
            currentBlock.transform.position = blockStartPosition;
            // use the rigidbody
            currentRigidBody = currentBlock.GetComponent<Rigidbody2D>();
            // score.scoreValue += 1;

            // add to AllBlocks list 
            AllBlocks.Add(currentBlock);
            // start measureDistance function
            MeasureDistance();
        }
    }


    private void MeasureDistance()
    {
        // for the amount of blocks in all blocks, check the difference between the newly added block and current block.
        for (int i = 0; i < AllBlocks.Count - 2; i++)
        {
            float distance = Vector2.Distance(currentBlock.transform.position, AllBlocks[i].transform.position);

            // if distance between these blocks is smaller than 4, zoom out
            if (distance < 4)
            {
                Camera.GetComponent<Camera>().orthographicSize += 1;
                // move the start position up
                blockStartPosition.y += 1;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        // scoremanager.SaveHighscore();

        if (currentBlock)
        {
            // when key A is pressed and gameover is false, move currentblock to left
            if (Input.GetKey(KeyCode.A) && (gameOver == false))
            {
                currentBlock.transform.position += transform.right * -blockSpeed * Time.deltaTime;
            }
            // when key D is pressed and gameover is false, move currentblock to right
            if (Input.GetKey(KeyCode.D) && (gameOver == false))
            {
                currentBlock.transform.position += transform.right * blockSpeed * Time.deltaTime;
            }
            // when space key is pressed and gameover is false, drop the block
            if (Input.GetKeyDown(KeyCode.Space) && (gameOver == false))
            {
                // empty the currentblock
                currentBlock = null;
                currentRigidBody.simulated = true;
                scoremanager.AddPoint();
                // start spawnNewBlock function
                SpawnNewBlock();
            }
        }

    }



}


