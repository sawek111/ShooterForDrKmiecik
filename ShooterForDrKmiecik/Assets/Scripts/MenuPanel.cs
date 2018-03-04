using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuPanel : MonoBehaviour
{
    private Canvas _canvas = null;

    #region Constructors
    [Inject]
    public void Construct(Canvas canvas)
    {
        _canvas = canvas;
        return;
    }

    void Awake()
    {
        transform.SetParent(_canvas.transform, false);
        return;
    }

    #endregion

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
        return;
    }
}
