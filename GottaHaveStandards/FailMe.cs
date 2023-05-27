using System;
using System.Collections.Generic;
using System.Text;

namespace GottaHaveStandards
{
    public class FailMeCog : iCog
    {
        public const string processKey = "FailMeCog";

        public string Key { get { return processKey; } }

        public void process(Action target, ref ExecutionResult result)
        {
            Console.WriteLine("... failing");
            throw new NotImplementedException();

        }

    }

    public static class FailMeExtensionClass
    {
        public static ProcessFactory FailMe(this ProcessFactory pipeline)
        {
            RetryCog cog = new RetryCog();
            pipeline.addPipelineItem(cog.process);
            return pipeline;
        }

        public static Exception FailMeException(this ExecutionResult result) /////////////////// todo: need guards
        {
            return (Exception)result.cogExceptions[RetryCog.processKey];
        }

    }

}
