using UnityEngine;
using System.Collections;

public class Coroutine_Bullet : MonoBehaviour
{
    public float smoothing = 1f;
    public float speed = 30f;
    public Vector3 bulletTarget
    {
        get { return btarget; }
        set
        {
            btarget = value;

            StopCoroutine("BulletMove");
            StartCoroutine("BulletMove", btarget);
        }
    }

    private Vector3 btarget;
    IEnumerator BulletMove(Vector3 btarget)
    {
        Vector3 direction = Vector3.Normalize(btarget - transform.position);
        while (gameObject != null)
        {
            transform.LookAt(btarget);
            transform.position += direction * speed * Time.deltaTime;

            yield return null;
        }
    }
}
