using System;
using System.Collections.Generic;
using System.Text;

namespace GottaHaveStandards
{
    public class RetryCog : iCog
    {
        public const string processKey = "RetryCog";

        public string Key { get { return processKey; } }

        public void process(Action target, ref ExecutionResult result)
        {
            int maxRetries = 3;
            int retryCounter;
            Console.WriteLine("... attempting execution");

            for (retryCounter = 1; retryCounter < maxRetries; retryCounter++) {
                if (guardedExecution(target, ref result)) break;
            }
            result.cogResults.Add(Key, new RetryResult() { numberOfRetries=retryCounter, successful=(retryCounter<=maxRetries) });

        }

        private bool guardedExecution(Action target, ref ExecutionResult result)
        {
            try {
                target.Invoke();
                Console.WriteLine("... success");
                return true;

            } catch (Exception ex) {
                result.addCogException(Key, ex);
                Console.WriteLine("... failure");
                return false;
            }
        }
    }

    public class RetryResult
    {
        public int numberOfRetries { get; set; }
        public bool successful { get; set; }
    }

    public static class RetryExtensionClass
    {
        public static ProcessFactory Retry(this ProcessFactory pipeline)
        {
            RetryCog cog = new RetryCog();
            pipeline.addPipelineItem(cog.process);
            return pipeline;
        }

        public static RetryResult RetryResult(this ExecutionResult result) /////////////////// todo: need guards
        {
            return (RetryResult)result.cogResults[RetryCog.processKey];
        }

        public static Exception RetryException(this ExecutionResult result) /////////////////// todo: need guards
        {
            return (Exception)result.cogExceptions[RetryCog.processKey];
        }

    }

}
