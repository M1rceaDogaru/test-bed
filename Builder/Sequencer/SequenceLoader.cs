using Builder.Sequencer.SequenceTypes;
using System.Collections.Generic;
using System.Xml;

namespace Builder.Sequencer
{
    class SequenceLoader
    {
        public IEnumerable<ActionBase> Load(string xmlContent, string sequenceId)
        {
            var document = new XmlDocument();
            document.LoadXml(xmlContent);
            var sequences = document.GetElementsByTagName("sequence");

            var actions = new List<ActionBase>();

            foreach (XmlNode sequence in sequences)
            {
                if (sequence.Attributes["id"].Value == sequenceId)
                {
                    foreach (XmlNode action in sequence.ChildNodes)
                    {
                        switch (action.Name)
                        {
                            case "message":
                                actions.Add(new ShowMessage(action));
                                break;
                        }
                    }
                }
            }

            return actions;
        }
    }
}
