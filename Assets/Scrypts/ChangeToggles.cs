using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToggles : MonoBehaviour
{
    [SerializeField] private GameObject onTrue;
    [SerializeField] private Image blinkImage;
    [SerializeField] private Toggle trueToggle;
    [SerializeField] private Toggle[] otherToggles;
    [SerializeField] private Button NextButton;
    [SerializeField] private Color tryColor;
    [SerializeField] private Color falseColor;
    private Color blinkImadgeColor;
    System.Random rand;

    private void Awake()
    {
        SetRandomToggles();

        NextButton.onClick.AddListener(OnNextButtonClick);

        blinkImadgeColor = blinkImage.color;
        trueToggle.onValueChanged.AddListener(OnTryToggleChanged);
        foreach (Toggle toggle in otherToggles)
            toggle.onValueChanged.AddListener(OnFalseToggleChanged);
    }

    private void OnNextButtonClick()
    {
        SetRandomToggles();
    }

    private void SetRandomToggles()
    {
        var mixInt = new int[3] { 1, 2, 3 };
        mixInt = Mix(mixInt);
        trueToggle.gameObject.transform.SetSiblingIndex(mixInt[0]);
        otherToggles[0].gameObject.transform.SetSiblingIndex(mixInt[1]);
        otherToggles[1].gameObject.transform.SetSiblingIndex(mixInt[2]);
    }

    private int[] Mix(int[] data)
    {
        rand = new System.Random();
        for (int i = data.Length - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);
            var temp = data[j];
            data[j] = data[i];
            data[i] = temp;
        }
        return data;
    }

    private void OnTryToggleChanged(bool active)
    {
        onTrue.SetActive(active);
        StartCoroutine(Blink(true));
    }

    private void OnFalseToggleChanged(bool active)
    {
        StartCoroutine(Blink(false));
    }

    private IEnumerator Blink(bool answer, float waitTime = 1)
    {
        if (answer)
        {
            blinkImage.color = tryColor;
        }
        else
        {
            blinkImage.color = falseColor;
        }
        yield return new WaitForSeconds(waitTime);
        blinkImage.color = blinkImadgeColor;
    }
}
