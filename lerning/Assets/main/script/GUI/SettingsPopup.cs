using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    //[SerializeField] private InputField nameText;

    private void Start()
    {
        //nameText.text = PlayerPrefs.GetString("name");
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);    
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }
    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGE, speed);
    }
}
