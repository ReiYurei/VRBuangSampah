using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuidePage : MonoBehaviour
{
    public List<GameObject> guide;
    public GameObject guideParent;
    public GameObject startBtn;
    public TMPro.TextMeshProUGUI pageText;
    int page;
    int maxPage;
    public delegate void GuideEvent();
    public static event GuideEvent OnGuideRead;

    private void Start()
    {
        guideParent.SetActive(true);
        foreach (GameObject obj in guide)
        {
            obj.SetActive(false);
        }
        page = 1;
        maxPage = guide.Count;
        ShowPage();
        pageText.text = $"{page}/{maxPage}";
    }
    void ShowPage()
    {
        guide[page-1].SetActive(true);
    }
    void HidePage()
    {
        guide[page-1].SetActive(false);
    }

    public void NextPage()
    {
        HidePage();
        if (page >= maxPage)
        {
            page = 1;
            pageText.text = $"{page}/{maxPage}";
            ShowPage();
            return;
        }
        page += 1;
        pageText.text = $"{page}/{maxPage}";
        ShowPage();

    }

    public void PreviousPage()
    {
        HidePage();
        if (page <= 1)
        {
            page = maxPage;
            pageText.text = $"{page}/{maxPage}";
            ShowPage();

            return;
        }
        page -= 1;
        pageText.text = $"{page}/{maxPage}";
        ShowPage();


    }
    void Update()
    {
        if (page == maxPage)
        {
            startBtn.SetActive(true);
        }
        else
        {
            startBtn.SetActive(false);
        }
    }

    public void Understood()
    {
        if (OnGuideRead == null)
        {
            return;
        }
        OnGuideRead();
        guideParent.SetActive(false);
    }


}
