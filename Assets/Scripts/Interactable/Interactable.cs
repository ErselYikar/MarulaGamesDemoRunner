using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected float _yScaleChange;
    [SerializeField] protected GameObject _interactable;
    [SerializeField] protected ParticleSystem _particle;

    private void OnTriggerEnter(Collider other)
    {
        var _temp = other.transform.localScale;
        _temp += new Vector3(0, _yScaleChange, 0);
        other.transform.localScale = _temp;

        var tempPos = new Vector3(other.transform.position.x,0,other.transform.position.z);
        other.transform.position = tempPos;

        StartCoroutine(ParticleCoroutine());
        if (other.transform.localScale.y <= 0)
        {
            GameManager.Instance.UpdateGameState(GameState.Fail);
        }

    }

    private IEnumerator ParticleCoroutine()
    {
        _interactable.SetActive(false);
        _particle.Play();
        yield return new WaitForSeconds(0.5f);
        _interactable.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
