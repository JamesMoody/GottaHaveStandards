using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static GottaHaveStandards.ProcessFactory;

namespace GottaHaveStandards
{
    public class DurationCog : iCog
    {
        public const string processKey = "DurationCog";
        public string Key { get { return processKey; }  } 

        public void process(Action target, ref ExecutionResult ret)
        {
            Console.WriteLine("... starting timer");
            Stopwatch tmr = Stopwatch.StartNew();

            try {
                target.Invoke();

            } catch (Exception ex) {
                ret.addCogException(Key, ex);
            }

            tmr.Stop();
            ret.cogResults.Add(Key, tmr.Elapsed);

            Console.WriteLine("... execution took {0}", tmr.Elapsed.TotalMilliseconds);
        }

    }

    public static class DurationExtensionClass  
    {
        public static ProcessFactory Duration(this ProcessFactory pipeline)
        {
            DurationCog cog = new DurationCog();
            pipeline.addPipelineItem(cog.process);
            return pipeline;
        }

        public static TimeSpan DurationResult(this ExecutionResult result) /////////////////// todo: need guards
        {
            return (TimeSpan)result.cogResults[DurationCog.processKey];
        }

        public static Exception DurationException(this ExecutionResult result) /////////////////// todo: need guards
        {
            return (Exception)result.cogExceptions[DurationCog.processKey];
        }

    }



}
