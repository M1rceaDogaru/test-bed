using Builder.Sequencer;
using System;
using System.IO;
using System.Threading;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequenceContent = File.ReadAllText("C:\\Users\\mircea_dogaru\\Documents\\Visual Studio 2015\\Projects\\Builder\\Builder\\Sequencer\\Sequences.xml");

            var sequenceLoader = new SequenceLoader();
            var actions = sequenceLoader.Load(sequenceContent, "1");

            var runner = new SequenceRunner();
            runner.Load(actions);
            runner.Run();

            while(true)
            {
                runner.Update();
                if (runner.HasFinishedRunning)
                {
                    Console.WriteLine("Runner finished execution");
                    Console.ReadLine();
                    return;
                }

                Thread.Sleep(Convert.ToInt32(Global.DeltaTime * 1000));
            }
        }
    }

    public static class Global
    {
        public const float DeltaTime = 0.1f;
    }
}
