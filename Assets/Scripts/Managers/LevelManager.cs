using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int stageIndex;
    private int currentStageIndex = 0;
    [SerializeField] private GameObject JumpPadsParent;
    [SerializeField] private float[] stageHeights;

    private void Start()
    {
        int distance = 5;
        foreach(Transform jumpPad in JumpPadsParent.transform)
        {
            distance += 5;
            jumpPad.gameObject.GetComponent<JumpPad>().Reset(distance, 5f, -18f, 18f);
        }
    }

}
