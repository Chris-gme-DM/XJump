using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int currentStageIndex;
    [SerializeField] private int stageIndexHelper;
    [SerializeField] private GameObject JumpPadsParent;
    [SerializeField] private float[] stageHeights;

    private void Start()
    {
        int distance = 0;
        foreach(Transform jumpPad in JumpPadsParent.transform)
        {
            distance += 2;
            jumpPad.gameObject.GetComponent<JumpPad>().Reset(distance, 5f, -18f, 18f);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < stageHeights.Length; i++)
        {
            if (player.transform.position.y >= stageHeights[i] && currentStageIndex != i && currentStageIndex !< i)
            {
                currentStageIndex = i;
                Debug.Log("Stage " + (i + 1) + " reached! currentStageIndex: " + currentStageIndex);
                // You can add additional logic here for when a new stage is reached
            }
        }

        if (stageIndexHelper < currentStageIndex)
        {
            stageIndexHelper = currentStageIndex;
            foreach(Transform jumpPad in JumpPadsParent.transform)
            {
                SpriteRenderer sr = jumpPad.gameObject.GetComponent<SpriteRenderer>();
                switch (currentStageIndex)
                {
                    case 0:
                        sr.color = Color.white; // Default color for stage 1
                        break;
                    case 1:
                        sr.color = Color.green; // Color for stage 2
                        break;
                    case 2:
                        sr.color = Color.blue; // Color for stage 3
                        break;
                    case 3:
                        sr.color = Color.red; // Color for stage 4
                        break;
                    case 4:
                        sr.color = Color.yellow; // Color for stage 4
                        break;
                    default:
                        sr.color = Color.white; // Fallback color
                        break;
                }
            }
        }

    }

    public int GetCurrentStageIndex()
    {
        return currentStageIndex;
    }

}

