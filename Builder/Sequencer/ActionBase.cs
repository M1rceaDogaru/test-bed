using System.Xml;

namespace Builder.Sequencer
{
    public abstract class ActionBase
    {
        public long Id { get; set; }

        public bool HasFinishedExecution { get; protected set; }

        public bool Blocking { get; protected set; }

        public abstract void Start();

        public abstract void Update();

        public ActionBase(XmlNode node)
        {
            Blocking = node.Attributes["nonBlocking"] == null;
        }
    }
}
