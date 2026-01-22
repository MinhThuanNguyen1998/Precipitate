using System.Collections.Generic;
using UnityEngine;

public class ModelLoader : MonoBehaviour
{
    [Header("3 Model Prefabs")]
    [SerializeField] private GameObject m_AgNO3_NaCl;
    private GameObject m_CurrentStateModel;
    private void OnEnable()
    {
        InitializeDefault();
    }
    private void InitializeDefault()
    {
        LoadStateModel(Config.AgNO3_NaCl, loadDefaultElement: false);
    }
    public void LoadStateModel(string state, bool loadDefaultElement = true)
    {
        ClearCurrentStateModel();
        GameObject prefabToLoad = null;
        switch (state)
        {
            case var _ when state == Config.AgNO3_NaCl:
                prefabToLoad = m_AgNO3_NaCl;
                break;

        }
        if (prefabToLoad != null)
        {
            m_CurrentStateModel = Instantiate(prefabToLoad, Vector3.zero, Quaternion.identity);
            m_CurrentStateModel.transform.parent = transform;
        }
    }
    private void ClearModel(ref GameObject model)
    {
        if (model != null)
        {
            Destroy(model);
            model = null;
        }
    }
    private void ClearCurrentStateModel() => ClearModel(ref m_CurrentStateModel);
}
