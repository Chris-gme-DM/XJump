using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public void Reset(float distance, float offset, float minX, float maxX)
    {
        //Debug.Log("JumpPad Reset Called");
        float newX = transform.position.x + Random.Range(-offset, offset);
        newX = Mathf.Clamp(newX, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y + distance, transform.position.z); 

    }
}
