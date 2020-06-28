using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    float speed = 40f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private bool flag = false;
    [SerializeField]
    private Transform alveolusPanel;

    private bool secondFlag = false;

    private bool moveToKazan = false;

    void Update()
    {
        if (secondFlag)
        {
            target.gameObject.SetActive(false);
            secondFlag = false;
        }
        if (flag)
        {
            if ((transform.position.x < target.position.x + 0.5f) && (transform.position.x > target.position.x - 0.5f) && (transform.position.y < target.position.y + 0.5f) && (transform.position.y > target.position.y - 0.5f))
            {
                flag = false;
                target.parent = gameObject.transform;
                gameObject.transform.parent = alveolusPanel;
                target.parent = alveolusPanel;
                target.gameObject.SetActive(true);
                secondFlag = true;
                //target.gameObject.SetActive(false);
            }

            float step = speed * Time.deltaTime;
            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), step * 12);
        }
        if (moveToKazan)
        {
            if ((transform.position.x < target.position.x + 1f) && (transform.position.x > target.position.x - 1f) && (transform.position.y < target.position.y + 1f) && (transform.position.y > target.position.y - 1f))
            {
                moveToKazan = false;
                gameObject.transform.parent = alveolusPanel;

            }
            float step = speed * Time.deltaTime;
            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), step * 12);
        }
    }

    public void MoveNode(Transform transform, Transform alveolus, Transform canvas)
    {
        gameObject.transform.parent = canvas.transform;
        target = transform;
        alveolusPanel = alveolus;
        flag = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, 30);
    }

    public void MoveToKazan(Transform transform, Transform canvas, Transform NewParent)
    {
        gameObject.transform.parent = canvas.transform;
        alveolusPanel = NewParent;
        target = transform;
        moveToKazan = true;

        transform.position = new Vector3(transform.position.x, transform.position.y, 30);
    }

    public void MoveOff()
    {
        flag = false;
    }
}
