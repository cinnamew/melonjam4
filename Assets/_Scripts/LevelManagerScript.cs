using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] int thingsToFind;
    [SerializeField] int thingsFound;

    [SerializeField] TextMeshProUGUI text;

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        text.text = (thingsToFind - thingsFound).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (thingsFound >= thingsToFind)
        {
            Debug.Log("COMPLETED LEVEL");
            switch(level)
            {
                case 1:                  
                        SceneManager.LoadScene("Two_Before");
                        break;       
                case 2:                   
                        SceneManager.LoadScene("Three_Before");
                    break;
                case 3:
                    SceneManager.LoadScene("Final");
                    break;

            }
        }
    }
    
    public void ThingFound()
    {
        thingsFound++;
        text.text = (thingsToFind - thingsFound).ToString();
    }
}
