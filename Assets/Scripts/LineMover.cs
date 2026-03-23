using System.Threading;
using UnityEngine;

public class LineMover : MonoBehaviour
{
    public static LineMover Instance;

    public Transform line;

    private SynchronizationContext _context;

    void Awake()
    {
        Instance = this;

        _context = SynchronizationContext.Current;
    }

    public void SetLinePositionX(float x)
    {
        if (line == null) return;

        _context.Post(_ =>
        {
            line.localPosition = new Vector3(x, line.localPosition.y, line.localPosition.z);
        }, null);
    }

    public void SetLinePositionY(float y)
    {
        if (line == null) return;

        _context.Post(_ =>
        {
            line.localPosition = new Vector3(line.localPosition.x, y, line.localPosition.z);
        }, null);
    }
}
