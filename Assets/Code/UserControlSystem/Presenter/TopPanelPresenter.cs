using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TopPanelPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _inputField;
    [SerializeField] private Button _menuBtn;
    [SerializeField] private GameObject _menuGO;

    [Inject] private void Init(ITimeModel timeModel)
    {
        timeModel.GameTime.Subscribe(seconds =>
        {
            var t = TimeSpan.FromSeconds(seconds);
            _inputField.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        });
        _menuBtn.OnClickAsObservable().Subscribe(_ => _menuGO.SetActive(true));
    }
}