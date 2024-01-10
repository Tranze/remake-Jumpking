using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameObjectsController : MonoBehaviour, IDataPersistence
{
    [SerializeField] public string newArea;
    [SerializeField] private string currentArea;
    [SerializeField] private TMP_Text mPositionText;

    void Start()
    {
        mPositionText.enabled = false;
        StartCoroutine(DisplayCurrentPosition(5.0f));
    }
    private void Update()
    {
        if (newArea != currentArea)
        {
            currentArea = newArea;
            StartCoroutine(DisplayCurrentPosition(5.0f));
        }
    }

    private IEnumerator DisplayCurrentPosition(float waitTime)
    {
        mPositionText.enabled = true;
        mPositionText.text = currentArea;
        yield return new WaitForSeconds(waitTime);
        mPositionText.enabled = false;
    }
    public void LoadData(GameData data)
    {
        currentArea = data.currentPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.currentPosition = currentArea;
    }
}
