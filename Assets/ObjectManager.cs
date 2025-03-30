using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] List<GameObject> dirtPrefabs;
    [SerializeField] List<GameObject> goodStuffPrefabs;
    [SerializeField] TMP_Text moneyCounter;
    [SerializeField] TMP_Text costCounter;
    
    
    private int cost = 1;
    private int money = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        costCounter.text = "Cost: " + cost.ToString();
        moneyCounter.text = "Money: " + money.ToString();
    }

    public void HideDirt()
    {

        

        if (cost <= money)
        {
            
            print("Hiding half of the objects");
            
            int activeCount = dirtPrefabs.FindAll(obj => obj.activeSelf).Count;
            int hideCount = Mathf.Max(1, activeCount / 2);
        
            int hidden = 0;
            foreach (var obj in dirtPrefabs)
            {
                if (hidden >= hideCount) break;
                if (obj.activeSelf)
                {
                    obj.SetActive(false);
                    hidden++;
                }
            }

            cost++;
            cost -= money;
        }
        
    }


    public void ShowDirt()
    {
        print("Showing objects based on cost");

        int showCount = Mathf.Min(cost, dirtPrefabs.Count);

        for (int i = 0; i < showCount; i++)
        {
            if (!dirtPrefabs[i].activeSelf)
            {
                dirtPrefabs[i].SetActive(true);
            }
        }

        cost++;
    }
    public void ShowGoodObjects()
    {
        foreach (var goodStuff in goodStuffPrefabs)
        {
            goodStuff.SetActive(true);
        }
    }
}
