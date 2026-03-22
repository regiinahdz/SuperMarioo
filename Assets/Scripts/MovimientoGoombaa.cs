using UnityEngine;

public class MovimientoGoombaa : MonoBehaviour
{
    private SpriteRenderer sr;
    private float timer = 0.0f;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            sr.flipX = true;
        }

        if (timer >= 1.0f)
        {
            timer = 0.0f;
            sr.flipX = false;
        }
    }
}
