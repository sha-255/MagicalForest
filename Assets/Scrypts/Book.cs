using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [SerializeField] private Page[] Pages;
    [Header("Software")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Image illustrationImadge;
    [SerializeField] private TMP_Text answerText;
    [SerializeField] private TMP_Text tryItemText;
    [SerializeField] private TMP_Text item2Text;
    [SerializeField] private TMP_Text item3Text;
    [SerializeField] private TMP_Text firstPageNumberText;
    [SerializeField] private TMP_Text twoPageNumberText;
    [SerializeField] private GameObject Finish;
    [SerializeField] private Button reGame;
    [SerializeField] private AudioSource mainAudioSource;
    [SerializeField] private AudioSource finishAudioSource;
    [SerializeField] private Button markButton;
    private int currentPage = 0;

    private void Awake()
    {
        finishAudioSource.Stop();
        OpenPage(currentPage);
        nextButton.onClick.AddListener(OpenNextPage);
        backButton.onClick.AddListener(OpenBackPage);
        reGame.onClick.AddListener(ReGame);
    }

    private void ReGame()
    {
        currentPage = 0;
        OpenPage(currentPage);
        markButton.interactable = true;
        mainAudioSource.Play();
        finishAudioSource.Stop();
    }

    private void OpenBackPage()
    {
        OpenPage(currentPage-=1);
    }

    private void OpenNextPage()
    {
        OpenPage(currentPage+=1);
    }

    void OpenPage(int number)
    {
        backButton.gameObject.SetActive(number != 0? true : false);
        try
        {
            illustrationImadge.sprite = Pages[number].illustrathion;
            answerText.text = Pages[number].questhion;
            tryItemText.text = Pages[number].tryAnswer;
            item2Text.text = Pages[number].item1falseQuesthions;
            item3Text.text = Pages[number].item2falseQuesthions;
            firstPageNumberText.text = (((number + 1) * 2) - 1).ToString();
            twoPageNumberText.text = ((number + 1) * 2).ToString();
        }
        catch
        {
            Finish.SetActive(true);
            markButton.interactable = false;
            mainAudioSource.Stop();
            finishAudioSource.Play();
        }
    }
}

[System.Serializable]
public class Page
{
    public Sprite illustrathion;
    public string questhion;
    public string tryAnswer;
    public string item1falseQuesthions;
    public string item2falseQuesthions;
}