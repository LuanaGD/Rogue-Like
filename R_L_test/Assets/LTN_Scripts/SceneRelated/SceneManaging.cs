using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneManaging : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("LTN_GoodProcedural", LoadSceneMode.Single);
    }

    public void QuitGame()//it works 
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
