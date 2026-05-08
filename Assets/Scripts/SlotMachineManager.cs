using UnityEngine;
using System.Collections;

public class SlotMachineManager : MonoBehaviour
{
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    public void Spin()
    {
        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        yield return StartCoroutine(reel1.Spin());

        yield return StartCoroutine(reel2.Spin());

        yield return StartCoroutine(reel3.Spin());

        CheckWin();
    }

    void CheckWin()
    {
        if (reel1.resultIndex ==
            reel2.resultIndex &&
            reel2.resultIndex ==
            reel3.resultIndex)
        {
            Debug.Log("WIN!");
        }
        else
        {
            Debug.Log("LOSE");
        }
    }
}