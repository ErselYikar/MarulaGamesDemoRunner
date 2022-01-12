using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected float _yScaleChange;

    private void OnTriggerEnter(Collider other)
    {
        var _temp = other.transform.localScale;
        _temp += new Vector3(0, _yScaleChange, 0);
        other.transform.localScale = _temp;
        gameObject.SetActive(false);

        if(other.transform.localScale.y == 0)
        {
            GameManager.Instance.UpdateGameState(GameState.Fail);
        }
    }
}
