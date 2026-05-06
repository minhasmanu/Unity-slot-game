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
        int r1 = Random.Range(0, 5);
        int r2 = Random.Range(0, 5);
        int r3 = Random.Range(0, 5);

        if (r1 == r2 && r2 == r3)
        {
            Debug.Log("WIN!");
        }
        else
        {
            Debug.Log("LOSE");
        }
    }
}