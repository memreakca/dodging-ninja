using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class yonetm : MonoBehaviour
{
    public int time = 60;
    public GameObject kure;
    public GameObject kure2;
    TextMeshProUGUI time_text;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        time_text = GameObject.Find("Canvas/time_text").GetComponent<TextMeshProUGUI>();

        Debug.Log(time.ToString());
        InvokeRepeating("kure_olustur", 0f, 3.5f);
        InvokeRepeating("saniye_azalt", 0f, 1f);
        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
    void kure_olustur()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            GameObject yeni_kure = Instantiate(kure, new Vector3(-10, 0.2f, 0), Quaternion.identity);
            Destroy(yeni_kure, 8f);
        }
        else if (rand == 1)
            {
            GameObject yeni_kure = Instantiate(kure2, new Vector3(10f, 0.2f, 0f), Quaternion.identity);
            Destroy(yeni_kure, 8f);
        }
        else
        {
            GameObject yeni_kure = Instantiate(kure2, new Vector3(10f, 0.2f, 0f), Quaternion.identity);
            GameObject yeni_kure1 = Instantiate(kure, new Vector3(-10, 0.2f, 0), Quaternion.identity);
            Destroy(yeni_kure, 8f);
            Destroy(yeni_kure1, 8f);
        }
    }
    void saniye_azalt()
    {
        time--;
        if (time <= 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        time_text.text ="Time = " + time.ToString();
    }
}
