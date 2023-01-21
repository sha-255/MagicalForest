using UnityEngine;
using UnityEngine.UI;

public class BookMark : MonoBehaviour
{
    [SerializeField] private Button bookMarkButton;
    [SerializeField] private GameObject bookMarkPage;
    [SerializeField] private GameObject[] Other;
    private bool switcher = false;
    private Mask mask;

    private void Start()
    {
        mask = GetComponent<Mask>();
        bookMarkButton.onClick.AddListener(OnBookMarkClicked);
    }

    private void OnBookMarkClicked()
    {
        switcher = !switcher;
        if (switcher)
        {
            mask.enabled = false;
            bookMarkPage.SetActive(true);
            foreach (var item in Other)
                item.SetActive(false);
        }
        else
        {
            mask.enabled = true;
            bookMarkPage.SetActive(false);
            foreach (var item in Other)
                item.SetActive(false);
        }
    }
}
