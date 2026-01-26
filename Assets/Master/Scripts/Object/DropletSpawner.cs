using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    [SerializeField] private Transform m_AnchorDropletParent;
    [SerializeField] private GameObject m_DropletPrefab;

    private void OnEnable() => PipetStateController.OnDropletSpawned += SpawnDroplet;
    private void OnDisable() => PipetStateController.OnDropletSpawned -= SpawnDroplet;


    public void SpawnDroplet()
    {
        if (m_DropletPrefab != null && m_AnchorDropletParent != null)
        {
            //Debug.Log("DropletSpawner");
            GameObject drop = Instantiate(m_DropletPrefab, m_AnchorDropletParent.position, Quaternion.identity);
            drop.transform.SetParent(m_AnchorDropletParent, true);
        }
    }
}
