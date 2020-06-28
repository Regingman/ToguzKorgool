using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KorgoolManager : MonoBehaviour
{
    [SerializeField]
    private Kazan firstPlayerKazan;
    [SerializeField]
    private Kazan secondPlayerKazan;
    [SerializeField]
    private List<Alveolus> firstPlayerAlveolus;
    [SerializeField]
    private List<Alveolus> secondPlayerAlveolus;

    [SerializeField]
    private Alveolus tempAlveolus;

    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private bool firstOrSecondPlayer = true;

    private int number;
    private int count;
    private bool move = false;
    private Alveolus lastAleolus;

    public static KorgoolManager self;

    private Color whiteColor = new Color(0, 255, 0, 255);
    private Color blackColor = new Color(0, 255, 0, 255);
    private bool firstPlayerTuz = false;
    private bool secondPlayerTuz = false;
    public Alveolus firstPlayerTuzNumber;
    public Alveolus secondPlayerTuzNumber;
    [SerializeField]
    public string whiteName;
    [SerializeField]
    public string blackName;
    [SerializeField]
    private GameObject tuzPanel;
    [SerializeField]
    private GameObject hodPanel;
    [SerializeField]
    private GameObject namePanel;
    [SerializeField]
    private Text hodText;
    [SerializeField]
    private Text tuzText;
    [SerializeField]
    private InputField white;
    [SerializeField]
    private InputField black;


    private void Awake()
    {
        namePanel.SetActive(true);
        if (self == null)
        {
            self = this;
        }
        else
        {
            Destroy(self);
        }
    }




    public void selectAlBtn(Alveolus alveolus)
    {
        if (alveolus.GetCount() == 0) return;

        if (firstOrSecondPlayer)
        {
            if (firstPlayerTuzNumber != alveolus)
            {
                if (firstPlayerAlveolus.Contains(alveolus))
                {
                    if (tempAlveolus != null)
                    {
                        tempAlveolus.DeselectBTN();
                        tempAlveolus = alveolus;
                        tempAlveolus.SelectBTN();
                    }
                    else
                    {
                        tempAlveolus = alveolus;
                        tempAlveolus.SelectBTN();
                    }
                }
            }
        }
        else
        {
            if (secondPlayerTuzNumber != alveolus)
            {
                if (secondPlayerAlveolus.Contains(alveolus))
                {
                    if (tempAlveolus != null)
                    {
                        tempAlveolus.DeselectBTN();
                        tempAlveolus = alveolus;
                        tempAlveolus.SelectBTN();
                    }
                    else
                    {
                        tempAlveolus = alveolus;
                        tempAlveolus.SelectBTN();
                    }
                }
            }
        }
    }

    public void SelectNameBtn()
    {
        if (white.text == "" && black.text == "") return;
        namePanel.SetActive(false);
        whiteName = white.text;
        blackName = black.text;
    }

    public void SelectBtn()
    {
        if (tempAlveolus != null && !move)
        {
            tempAlveolus.DeselectBTN();
            move = true;
            count = tempAlveolus.GetCount();
            number = tempAlveolus.GetNumber();
            if (firstOrSecondPlayer)
            {
                if (count == 1)
                {
                    if (number != 9)
                    {
                        foreach (Alveolus alveolus in firstPlayerAlveolus)
                        {
                            if (alveolus.GetNumber() == number + 1)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                            }
                        }
                    }
                    else
                    {
                        foreach (Alveolus alveolus in secondPlayerAlveolus)
                        {
                            if (alveolus.GetNumber() == 1)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                            }
                        }
                    }
                }
                else if (count > 1)
                {
                    foreach (Alveolus alveolus in firstPlayerAlveolus)
                    {
                        if (count > 0)
                        {
                            if (alveolus.GetNumber() >= number)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                                count--;
                            }
                        }


                    }

                    foreach (Alveolus alveolus in secondPlayerAlveolus)
                    {
                        if (count > 0)
                        {
                            alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                            lastAleolus = alveolus;
                            count--;
                        }
                        Debug.Log(count + ", " + alveolus.GetNumber());
                    }

                    if (count > 0)
                    {
                        foreach (Alveolus alveolus in firstPlayerAlveolus)
                        {
                            if (count > 0)
                            {
                                if (alveolus.GetNumber() >= number)
                                {
                                    alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                    lastAleolus = alveolus;
                                    count--;
                                }
                            }


                        }
                    }
                    if (count > 0)
                    {
                        foreach (Alveolus alveolus in secondPlayerAlveolus)
                        {
                            if (count > 0)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                                count--;
                            }
                            Debug.Log(count + ", " + alveolus.GetNumber());
                        }
                    }
                }
                Invoke("MoveOn", 3.0f);
            }
            else
            {
                if (count == 1)
                {
                    if (number != 9)
                    {
                        foreach (Alveolus alveolus in secondPlayerAlveolus)
                        {

                            if (alveolus.GetNumber() == number + 1)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                            }
                        }
                    }
                    else
                    {
                        foreach (Alveolus alveolus in firstPlayerAlveolus)
                        {
                            if (alveolus.GetNumber() == 1)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Alveolus alveolus in secondPlayerAlveolus)
                    {
                        if (count > 0)
                        {
                            if (alveolus.GetNumber() >= number)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                                count--;
                            }
                        }

                    }
                    foreach (Alveolus alveolus in firstPlayerAlveolus)
                    {
                        if (count > 0)
                        {
                            alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                            lastAleolus = alveolus;
                            count--;
                        }
                    }
                    if (count > 0)
                    {
                        foreach (Alveolus alveolus in secondPlayerAlveolus)
                        {
                            if (count > 0)
                            {
                                if (alveolus.GetNumber() >= number)
                                {
                                    alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                    lastAleolus = alveolus;
                                    count--;
                                }
                            }


                        }
                    }
                    if (count > 0)
                    {
                        foreach (Alveolus alveolus in firstPlayerAlveolus)
                        {
                            if (count > 0)
                            {
                                alveolus.UpdateBtn(tempAlveolus.LastElement(), canvas);
                                lastAleolus = alveolus;
                                count--;
                            }
                            Debug.Log(count + ", " + alveolus.GetNumber());
                        }
                    }
                }
                Invoke("MoveOn", 3.0f);
            }
        }
    }

    void MoveOn()
    {
        if (secondPlayerTuzNumber != null)
        {
            secondPlayerKazan.UpdateCount(secondPlayerTuzNumber.GetCount());
            secondPlayerTuzNumber.AllKazan(secondPlayerKazan, canvas, secondPlayerKazan.GetPanel());
        }
        if (firstPlayerTuzNumber != null)
        {
            firstPlayerKazan.UpdateCount(firstPlayerTuzNumber.GetCount());
            firstPlayerTuzNumber.AllKazan(firstPlayerKazan, canvas, firstPlayerKazan.GetPanel());
        }

        if (lastAleolus.GetCount() % 2 == 0)
        {
            if (firstOrSecondPlayer)
            {
                if (!firstPlayerAlveolus.Contains(lastAleolus))
                {
                    firstPlayerKazan.UpdateCount(lastAleolus.GetCount());
                    lastAleolus.AllKazan(firstPlayerKazan, canvas, firstPlayerKazan.GetPanel());
                }

            }
            else
            {
                if (!secondPlayerAlveolus.Contains(lastAleolus))
                {
                    secondPlayerKazan.UpdateCount(lastAleolus.GetCount());
                    lastAleolus.AllKazan(secondPlayerKazan, canvas, secondPlayerKazan.GetPanel());
                }

            }

        }
        else if (lastAleolus.GetCount() == 3 && lastAleolus.GetNumber() != 9)
        {
            if (firstOrSecondPlayer && !firstPlayerTuz && !firstPlayerAlveolus.Contains(lastAleolus))
            {
                if (secondPlayerTuzNumber == null)
                {
                    lastAleolus.HasTuz(whiteColor);
                    firstPlayerTuz = true;
                    firstPlayerTuzNumber = lastAleolus;
                    secondPlayerKazan.UpdateCount(firstPlayerTuzNumber.GetCount());
                    firstPlayerTuzNumber.AllKazan(secondPlayerKazan, canvas, secondPlayerKazan.GetPanel());
                    tuzPanel.SetActive(true);
                    tuzText.text = "Белые объявляют лунку№" + firstPlayerTuzNumber.GetNumber() + " тузом!";
                }
                else if (secondPlayerTuzNumber.GetNumber() != lastAleolus.GetNumber())
                {
                    lastAleolus.HasTuz(whiteColor);
                    firstPlayerTuz = true;
                    firstPlayerTuzNumber = lastAleolus;
                    secondPlayerKazan.UpdateCount(firstPlayerTuzNumber.GetCount());
                    firstPlayerTuzNumber.AllKazan(secondPlayerKazan, canvas, secondPlayerKazan.GetPanel());
                    tuzPanel.SetActive(true);
                    tuzText.text = "Белые объявляют лунку№" + firstPlayerTuzNumber.GetNumber() + " тузом!";

                }
            }
            else if (!firstOrSecondPlayer && !secondPlayerTuz && !secondPlayerAlveolus.Contains(lastAleolus))
            {
                if (firstPlayerTuzNumber == null)
                {
                    lastAleolus.HasTuz(blackColor);
                    secondPlayerTuz = true;

                    secondPlayerTuzNumber = lastAleolus;
                    secondPlayerKazan.UpdateCount(secondPlayerTuzNumber.GetCount());
                    secondPlayerTuzNumber.AllKazan(secondPlayerKazan, canvas, secondPlayerKazan.GetPanel());
                    tuzPanel.SetActive(true);
                    tuzText.text = "Черные объявляют лунку№" + secondPlayerTuzNumber.GetNumber() + " тузом!";
                }
                else if (firstPlayerTuzNumber.GetNumber() != lastAleolus.GetNumber())
                {
                    lastAleolus.HasTuz(blackColor);
                    secondPlayerTuz = true;

                    secondPlayerTuzNumber = lastAleolus;
                    secondPlayerKazan.UpdateCount(secondPlayerTuzNumber.GetCount());
                    secondPlayerTuzNumber.AllKazan(secondPlayerKazan, canvas, secondPlayerKazan.GetPanel());
                    tuzPanel.SetActive(true);
                    tuzText.text = "Черные объявляют лунку№" + secondPlayerTuzNumber.GetNumber() + " тузом!";
                }
            }
        }
        if (firstOrSecondPlayer)
        {
            firstOrSecondPlayer = false;
        }
        else
        {
            firstOrSecondPlayer = true;
        }
        move = false;

        tempAlveolus = null;
        if (firstOrSecondPlayer)
        {
            hodPanel.SetActive(true);
            hodText.text = "Ходит игрок за белых, " + whiteName;
        }
        else
        {
            hodPanel.SetActive(true);
            hodText.text = "Ходит игрок за черных, " + blackName;
        }

        Invoke("off", 2.0f);

    }

    void off()
    {
        hodPanel.SetActive(false);
        tuzPanel.SetActive(false);
    }
}
