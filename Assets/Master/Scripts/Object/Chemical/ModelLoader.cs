using System.Collections.Generic;
using UnityEngine;

public class ModelLoader : MonoBehaviour
{
    [Header("3 Model Prefabs")]
    [SerializeField] private GameObject m_AgNO3_NaCl;
    [SerializeField] private GameObject m_PbNO32_KI;
    [SerializeField] private GameObject m_AgNO3_NaOH;
    [SerializeField] private GameObject m_CuSO4_NaOH;
    [SerializeField] private GameObject m_FeSO4_NaOH;
    private GameObject m_CurrentStateModel;
    private void OnEnable()
    {
        InitializeDefault();
    }
    private void InitializeDefault()
    {
        LoadStateModel(LabState.AgNO3_NaCl, loadDefaultElement: false);
    }
    public void LoadStateModel(LabState state, bool loadDefaultElement = true)
    {
        ClearCurrentStateModel();
        GameObject prefabToLoad = null;
        switch (state)
        {
            case LabState.AgNO3_NaCl:
                prefabToLoad = m_AgNO3_NaCl;
                break;
            case LabState.PbNO32_KI:
                prefabToLoad = m_PbNO32_KI;
                break;
            case LabState.AgNO3_NaOH:
                prefabToLoad = m_AgNO3_NaOH;
                break;
            case LabState.CuSO4_NaOH:
                prefabToLoad = m_CuSO4_NaOH;
                break;
            case LabState.FeSO4_NaOH:
                prefabToLoad = m_FeSO4_NaOH;
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
