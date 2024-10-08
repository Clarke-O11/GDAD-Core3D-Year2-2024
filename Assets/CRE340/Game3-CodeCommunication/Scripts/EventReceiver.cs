using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EventReceiver : MonoBehaviour
{
    private Vector3 originalScale;

    private void OnEnable()
    {
        EventSender.OnFire += HandlerFireEvent;
    }

    private void OnDisable() 
    {
        EventSender.OnFire -= HandlerFireEvent;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    private void HandlerFireEvent(float scale, float speed) 
    {
        StartCoroutine(ScaleObject(scale, speed));
    }

    private IEnumerator ScaleObject(float targetScale, float speed) 
    { 
        Vector3 targetSize = originalScale * targetScale;
        float elapsedTime = 0f;
        float duration = 2f / speed;

        while (elapsedTime < duration) 
        {
            transform.localScale = Vector3.Lerp(originalScale, targetSize, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetSize;

        elapsedTime = 0f;

        while (elapsedTime < duration) 
        {
            transform.localScale = Vector3.Lerp(targetSize, originalScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
    }


}
