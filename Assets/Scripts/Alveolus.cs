using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alveolus : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Text numberText;
    [SerializeField]
    private Text countText;
    [SerializeField]
    private int count;
    [SerializeField]
    private int number;
    [SerializeField]
    private List<Node> nodes;
    [SerializeField]
    private GameObject alveolusPanel;
    [SerializeField]
    private Node misticNode;
    [SerializeField]
    private GameObject select;
    [SerializeField]
    private bool tuz = false;


    public bool IsTuz()
    {
        return tuz;
    }

    public void HasTuz(Color color)
    {
       
        tuz = true;
        image.color = color;
        Debug.Log(image.color);
    }

    private void Awake()
    {
        count = 9;
        countText.text = count.ToString();
        numberText.text = number.ToString();
    }

    public void UpdateBtn(Node tempNode, Transform canvas)
    {
        tempNode.MoveNode(misticNode.transform, alveolusPanel.transform, canvas);
        //tempNode.transform.parent = alveolusPanel.transform;
        nodes.Add(tempNode);
        count++;
        countText.text = count.ToString();
    }

    public void AllKazan(Kazan kazan, Transform canvas, Transform KazanPanel)
    {
        foreach (Node node in nodes)
        {
            node.MoveToKazan(kazan.transform, canvas, KazanPanel);
        }
        nodes.Clear();
        count = 0;
        countText.text = count.ToString();
    }

    public int GetNumber()
    {
        return number;
    }

    public int GetCount()
    {
        return count;
    }

    public Node LastElement()
    {
        Node temp = nodes[nodes.Count - 1];
        nodes.Remove(temp);
        count--;
        countText.text = count.ToString();
        return temp;
    }

    public void SelectBTN()
    {
        select.SetActive(true);
    }

    public void DeselectBTN()
    {
        select.SetActive(false);
    }


}
