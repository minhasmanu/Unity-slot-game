using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    public float speed = 400f;
    public float spinTime = 3f;

    public RectTransform[] symbols;

    public float symbolHeight = 50f;
    public float resetPositionY = 250f;
    public float bottomLimitY = 70f;

    private bool isSpinning = false;

    public IEnumerator Spin()
    {
        isSpinning = true;

        float timer = 0f;

        while (timer < spinTime)
        {
            foreach (RectTransform symbol in symbols)
            {
                // Move symbol downward
                symbol.anchoredPosition += Vector2.down * speed * Time.deltaTime;

                // If symbol goes below limit
                if (symbol.anchoredPosition.y < bottomLimitY)
                {
                    // Move it back to top
                    symbol.anchoredPosition = new Vector2(
                        symbol.anchoredPosition.x,
                        resetPositionY
                    );
                }
            }

            timer += Time.deltaTime;
            yield return null;
        }

        isSpinning = false;
    }
}