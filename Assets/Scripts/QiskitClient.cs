using UnityEngine;

public class QiskitClient : MonoSingleton<QiskitClient>
{
    protected override bool DestroyOnLoad => true;

    private QiskitRequester qiskitRequester
    {
        get
        {
            if (_qiskitRequester == null)
            {
                _qiskitRequester = new QiskitRequester();
                _qiskitRequester.Start();
            }

            return _qiskitRequester;
        }
    }

    private QiskitRequester _qiskitRequester;

    public void SendRequest(QiskitRequest request, InstaImage image)
    {
        qiskitRequester.AddRequest(request, image);
    }

    private void OnDestroy()
    {
        qiskitRequester.Stop();
    }
}