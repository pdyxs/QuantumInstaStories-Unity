using System.Collections.Generic;
using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;

/// <summary>
///     Example of requester who only sends Hello. Very nice guy.
///     You can copy this class and modify Run() to suits your needs.
///     To use this class, you just instantiate, call Start() when you want to start and Stop() when you want to stop.
/// </summary>
public class QiskitRequester : RunAbleThread
{
    protected override void Run()
    {
        ForceDotNet.Force(); // this line is needed to prevent unity freeze after one use, not sure why yet
        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5555");

            while (Running)
            {
                if (waitingForRequest != null)
                {
                    string message;
                    bool gotMessage = client.TryReceiveFrameString(out message);
                    if (gotMessage)
                    {
                        waitingForRequest.image.RecieveResults(waitingForRequest.request, message);
                        waitingForRequest = null;
                    }
                }
                else if (requests.Count > 0)
                {
                    var request = requests.Dequeue();
                    client.SendFrame(request.request.HamiltonianString());
                    waitingForRequest = request;
                }
            }
        }

        NetMQConfig.Cleanup(); // this line is needed to prevent unity freeze after one use, not sure why yet
    }

    public class Request
    {
        public QiskitRequest request;
        public InstaImage image;
    }

    private Queue<Request> requests = new Queue<Request>();

    private Request waitingForRequest = null;

    public void AddRequest(QiskitRequest request, InstaImage image)
    {
        request.Normalise();
        requests.Enqueue(new Request() {request = request, image = image});
    }
}