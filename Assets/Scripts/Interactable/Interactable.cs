using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected float _yScaleChange;
    [SerializeField] protected ParticleSystem _particle;

    private void OnTriggerEnter(Collider other)
    {
        var _temp = other.transform.localScale;
        _temp += new Vector3(0, _yScaleChange, 0);
        other.transform.localScale = _temp;

        var tempPos = new Vector3(other.transform.position.x,0,other.transform.position.z);
        other.transform.position = tempPos;
        
        gameObject.SetActive(false);

        if(other.transform.localScale.y == 0)
        {
            GameManager.Instance.UpdateGameState(GameState.Fail);
        }
    }

    private void ParticleCoroutine()
    {

    }
}
