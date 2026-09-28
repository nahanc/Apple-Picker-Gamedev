using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    // Speed at which the AppleTree moves
        // Prefab for instantiating branches
    public GameObject branchPrefab;
    // Chance that a drop will be a branch instead of an apple
    [Range(0f, 1f)]
    public float branchChance = 0.1f;
    public float speed = 1f;
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.02f;
    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke( "DropApple", 2f);
    }


    void DropApple() { // b
        GameObject droppedObject;
        if(Random.value < branchChance)
        {
            droppedObject = Instantiate<GameObject>(branchPrefab);
        }
        else
        {
            droppedObject = Instantiate<GameObject>( applePrefab );
        }
        droppedObject.transform.position = transform.position;
        Invoke( "DropApple", secondsBetweenAppleDrops );
    }


    void Update()
    {
        Vector3 pos = transform.position; 
        pos.x += speed * Time.deltaTime; 
        transform.position = pos;

        if ( pos.x < -leftAndRightEdge ) { 
        speed = Mathf.Abs(speed); 
        } else if ( pos.x > leftAndRightEdge ) {
        speed = -Mathf.Abs(speed);
        } 

    }

    void FixedUpdate() {
        if ( Random.value < chanceToChangeDirections ) { 
            speed *= -1;
        }
    }

}
