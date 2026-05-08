using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    public float speed = 400f;
    public float spinTime = 3f;

    public RectTransform[] symbols;

    public float symbolHeight = 50f;

    // YOUR VALUES
    public float resetPositionY = 250f;
    public float bottomLimitY = 10f;

    // Center stopping position
    public float centerY = 160f;

    // Final result
    public int resultIndex;

    public IEnumerator Spin()
    {
        float timer = 0f;

        // RANDOM FINAL SYMBOL
        resultIndex = Random.Range(0, symbols.Length);

        // SPINNING
        while (timer < spinTime)
        {
            MoveSymbols();

            timer += Time.deltaTime;
            yield return null;
        }

        // STOP AT CENTER
        yield return StartCoroutine(
            AlignSymbolToCenter(symbols[resultIndex])
        );
    }

    void MoveSymbols()
    {
        foreach (RectTransform symbol in symbols)
        {
            symbol.anchoredPosition +=
                Vector2.down * speed * Time.deltaTime;

            // TELEPORT TO TOP
            if (symbol.anchoredPosition.y < bottomLimitY)
            {
                symbol.anchoredPosition = new Vector2(
                    symbol.anchoredPosition.x,
                    resetPositionY
                );
            }
        }
    }

    IEnumerator AlignSymbolToCenter(RectTransform target)
    {
        while (Mathf.Abs(target.anchoredPosition.y - centerY) > 5f)
        {
            MoveSymbols();

            yield return null;
        }

        // PERFECT SNAP
        float offset = centerY - target.anchoredPosition.y;

        foreach (RectTransform symbol in symbols)
        {
            symbol.anchoredPosition += Vector2.up * offset;
        }
    }
}