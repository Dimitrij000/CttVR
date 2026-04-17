using System.Threading;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public static LineController Instance;

    private SynchronizationContext _context;
    private MeshRenderer _meshRenderer;

    void Awake()
    {
        Instance = this;

        _context = SynchronizationContext.Current;
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnApplicationQuit()
    {
        Instance = null;
    }

    public void SetLinePositionX(float x)
    {
        _context.Post(_ =>
        {
            if (Instance != null)
                transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        }, null);
    }

    public void SetLinePositionY(float y)
    {
        _context.Post(_ =>
        {
            if (Instance != null)
                transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }, null);
    }

    public void UpdateLine(Color color, float width)
    {
        _context.Post(_ =>
        {
            if (Instance != null)
            {
                _meshRenderer.sharedMaterial.color = color;
                transform.localScale = new Vector3(
                    transform.localScale.x,
                    width,
                    transform.localScale.z
                );
            }
        }, null);
    }
}
