using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                
        Button button = gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => {
                
                Application.Quit();
            });
        }
        else
        {
            Debug.LogError("BtnStartGame script is not attached to an object with a Button component.");
        }
    }

}
