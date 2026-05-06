using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    public float speed = 1000f;
    public float spinTime = 2f;

    private bool isSpinning = false;

    public IEnumerator Spin()
    {
        isSpinning = true;
        float timer = 0f;

        while (timer < spinTime)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        isSpinning = false;
    }
}