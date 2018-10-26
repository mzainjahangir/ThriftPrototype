using System;

namespace ThriftPrototype
{
    class GameUiHandler : GameUi.Iface
    {
        public void SendMessageFromUI()
        {
            Console.WriteLine("Called from Unity: SendMessageFromUI");
        }
    }
}
