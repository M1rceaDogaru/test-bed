using System;
using System.Xml;

namespace Builder.Sequencer.SequenceTypes
{
    class ShowMessage : ActionBase
    {
        private readonly string _message;
        private readonly float _displayFor = 3f;
        private readonly bool _waitForInput = false;

        private float _currentDisplayTime;

        public ShowMessage(XmlNode node) : base(node)
        {
            _message = node.Attributes["text"].Value;

            var displayForAttribute = node.Attributes["displayFor"];
            if (displayForAttribute != null)
            {
                float.TryParse(displayForAttribute.Value, out _displayFor);
            }

            var waitForInputAttribute = node.Attributes["waitForInput"];
            if (waitForInputAttribute != null)
            {
                _waitForInput = true;
                Blocking = true;
            }
        }

        public override void Start()
        {
            _currentDisplayTime = 0f;
            Console.WriteLine(_message);
        }

        public override void Update()
        {
            if (_waitForInput)
            {
                if (Console.ReadKey(true).KeyChar == 'n')
                {
                    HasFinishedExecution = true;
                }

                return;
            }

            _currentDisplayTime += Global.DeltaTime;
            if (_currentDisplayTime > _displayFor)
            {
                HasFinishedExecution = true;
            }
        }
    }
}
