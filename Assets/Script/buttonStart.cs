using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonStart : MonoBehaviour
{
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        if (button != null) {
           button.onClick.AddListener(() => {
               // LoadScene from Singleton Class
               SceneManager.SingletonSceneManager.LoadScene("SampleScene");
           }); 
        } else { 
           Debug.LogError("BtnStartGame script is not attached to an object with a Button component."); 
        }
    }
}
