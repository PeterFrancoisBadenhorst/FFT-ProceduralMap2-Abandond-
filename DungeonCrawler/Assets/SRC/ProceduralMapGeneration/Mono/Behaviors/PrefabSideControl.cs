using UnityEngine;

public class PrefabSideControl : MonoBehaviour
{
    public GameObject n_object;
    public GameObject e_object;
    public GameObject s_object;
    public GameObject w_object;
    public GameObject t_object;
    public GameObject b_object;

    public GameObject n_side;
    public GameObject e_side;
    public GameObject s_side;
    public GameObject w_side;
    public GameObject t_side;
    public GameObject b_side;

    // Start is called before the first frame update
    private void Start()
    {
        n_side.SetActive(!n_object.activeSelf);
        e_side.SetActive(!e_object.activeSelf);
        s_side.SetActive(!s_object.activeSelf);
        w_side.SetActive(!w_object.activeSelf);
        t_side.SetActive(!t_object.activeSelf);
        b_side.SetActive(!b_object.activeSelf);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}