using System.Collections;
using UnityEngine;

public class JumpPadResetter : MonoBehaviour
{
    [SerializeField] private float resetDistance; // Distance to reset the JumpPad
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float offset;
    [SerializeField] private GameObject jumpPadParents;

    private Coroutine MRDB_Coroutine;
    private float initialResetDistance;

    [Header("IncrementingResetDistenace")]
    [SerializeField] private int howMuchMore;
    [SerializeField] private float increment; // Increment value for reset distance
    [SerializeField] private float delay; // Delay between increments

    private void Start()
    {
        resetDistance *= jumpPadParents.transform.childCount / 3; // Adjust reset distance based on the number of JumpPads
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name + " entered trigger!");
        if (collision.gameObject.CompareTag("JumpPad"))
        {
            //Debug.Log("JumpPad detected: " + collision.gameObject.name);
            collision.gameObject.GetComponent<JumpPad>().Reset(resetDistance, offset, minX, maxX);
        }
    }

}
