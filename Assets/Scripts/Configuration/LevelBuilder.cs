using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;

    [SerializeField]
    GameObject prefabHarderBlock;

    //block dimensions
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    float blockColliderHalfWidth;
    float blockColliderHalfHeight;

    float minHarderBlockProbability = 0.1f;
    float maxHarderBlockProbability = 0.3f;
    float randomHarderBlockProbability;

    float spawnHarderBlockProbability;

    // Start is called before the first frame update
    void Start()
    {
        //create a paddle
        Instantiate(prefabPaddle);

        // create and destroy block to find out the dimensions of a standard block
        // 
        GameObject tempBlock = Instantiate<GameObject>(prefabStandardBlock);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        blockColliderHalfWidth = collider.size.x / 2;
        blockColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBlock.transform.position.x - blockColliderHalfWidth,
            tempBlock.transform.position.y - blockColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBlock.transform.position.x + blockColliderHalfWidth,
            tempBlock.transform.position.y + blockColliderHalfHeight*2);
        Destroy(tempBlock);

        //Determine the probability of HarderBlock spawn
        randomHarderBlockProbability = Random.Range(minHarderBlockProbability, maxHarderBlockProbability);

        //Add Blocks
        AddRowsofBlock(3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddRowsofBlock(int nOfRows)
    {
        // calculate how much of blocks fit in a row

        Vector2 position = spawnLocationMax;
        for (int i =0; i<nOfRows; i++)
        {
                position.y -= (blockColliderHalfHeight * 2 + 0.1f);

            for (int j =0; j<8;  j++) {
                spawnHarderBlockProbability = Random.Range(0.0f,1.0f);
                if (spawnHarderBlockProbability < randomHarderBlockProbability)
                {
                    Instantiate(prefabHarderBlock, position, Quaternion.identity);
                    position.x += 5 + 0.1f;
                }
                else
                {
                    Instantiate(prefabStandardBlock, position, Quaternion.identity);
                    position.x += 5 + 0.1f;
                }
            }
            position.x = spawnLocationMin.x;
        }
    }
}
