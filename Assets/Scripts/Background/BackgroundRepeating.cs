using UnityEngine;

public class BackgroundRepeating : MonoBehaviour
{
    [SerializeField] float height;
    void Update()
    {
        if(transform.position.y < -height)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 pos = new Vector2(0, height * 2);
        transform.position = (Vector2)transform.position + pos;
    }
}
