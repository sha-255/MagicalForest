using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    [SerializeField] private Button mark;
    [SerializeField] private Button exit;
    [SerializeField] private GameObject anim1;
    [SerializeField] private GameObject anim2;
    private bool isNotStart;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("F") == 0)
        {
            anim1.SetActive(true);
            mark.onClick.AddListener(ActivateAnim);
        }
        PlayerPrefs.SetInt("F",1);
    }

    private void ActivateAnim()
    {
        if (!isNotStart)
        {
            anim1.SetActive(false);
            anim2.SetActive(true);
            isNotStart = true;
        }
    }
}