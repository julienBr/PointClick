using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private PanelType type;
    private bool state;
    private Canvas canvas;
    private CanvasGroup group;
    private float animationTime = 0.5f;
    [SerializeField] private AnimationCurve animCurve = new ();

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        group = GetComponent<CanvasGroup>();
    }

    private void UpdateState(bool _animate)
    {
        StopAllCoroutines();
        if (_animate) StartCoroutine(Animate(state));
        else canvas.enabled = state;
    }

    private IEnumerator Animate(bool _state)
    {
        canvas.enabled = true;
        group.interactable = !_state;
        group.blocksRaycasts = !_state;
        float _t = _state ? 0 : 1;
        float _target = _state ? 1 : 0;
        int _factor = _state ? 1 : -1;
        while (true)
        {
            yield return null;
            _t += Time.deltaTime * _factor / animationTime;
            group.alpha = animCurve.Evaluate(_t);
            if ((state && _t >= _target) || (!state && _t <= _target))
            {
                group.alpha = _target;
                group.interactable = _state;
                group.blocksRaycasts = _state;
                break;
            }
        }
        canvas.enabled = _state;
    }
    
    public void ChangeState(bool _animate)
    {
        state = !state;
        UpdateState(_animate);
    }
    
    public void ChangeState(bool _animate, bool _state)
    {
        state = _state;
        UpdateState(_animate);
    }
    
    #region Getter
    public PanelType GetPanelType() { return type; }
    #endregion
}