using System;
using System.Collections;
using UnityEngine;
public class Row : MonoBehaviour
{
    
    public void StartRotation(Action matchmakingFinish)
    {
        StartCoroutine(RotatingRow(matchmakingFinish));
    }

    private IEnumerator RotatingRow(Action matchmakingFinish)
    {
        float speed = 70;

        while (speed >= 10)
        {
            speed = speed / 1.01f;
            transform.Translate(Vector2.up * Time.deltaTime * -speed);
            if (transform.localPosition.y <= -80)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 80f);
            }
            
            yield return new WaitForSeconds(0.05f);
        }

        if (transform.localPosition.y <= -40)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, -80);
        }
        else if (transform.localPosition.y >= 40)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, 80);
        }
        else if (transform.localPosition.y <= 40)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, 0);
        }
        yield return new WaitForSeconds(1f);
        matchmakingFinish.Invoke();
    }
}
