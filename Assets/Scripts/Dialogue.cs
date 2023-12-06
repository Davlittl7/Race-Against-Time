using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject fadeIn;

    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;


    private int index; 

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    
    public void OnClick()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        } else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }

    }
    

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator ToNextScene()
    {
        fadeIn.SetActive(true);
        fadeIn.GetComponent<Animator>().Play("FadeIn");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            StartCoroutine(ToNextScene());
            //gameObject.SetActive(false);
            //StartCoroutine(ToNextScene());
        }
    }
}