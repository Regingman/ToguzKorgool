using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kazan : MonoBehaviour
{
    [SerializeField]
    private Text countText;

    [SerializeField]
    private GameObject win;

    [SerializeField]
    private Text winText;

    [SerializeField]
    private int count;

    [SerializeField]
    private int number;

    [SerializeField]
    private Transform Panel;

    public void UpdateCount(int _count)
    {
        count += _count;
        countText.text = count.ToString();
        if (count >= 81)
        {

            Invoke("Win", 3f);

        }
    }

    public Transform GetPanel()
    {
        return Panel;
    }

    private void Win()
    {
        win.SetActive(true);
        winText.text = "Игрок № " + number.ToString() + "Победил";
    }


}
