using System;
using System.Collections.Generic;
using System.Text;

namespace GottaHaveStandards
{

    public class ProcessFactory
    {
        public delegate void processCog(Action target, ref ExecutionResult result);

        private List<processCog> pipeline = new List<processCog>();

        public void addPipelineItem(processCog cog)
        {
            pipeline.Add(cog);
        }

        public ExecutionResult execute(Action task)
        {
            ExecutionResult ret = new ExecutionResult();

            try {
                Action workspace = new Action(task);

                pipeline.Reverse(); // reverse the order before executing

                foreach (processCog cog in pipeline) {
                    Action tmp = workspace;
                    workspace = new Action(() => cog(tmp, ref ret));
                }
                
                workspace.Invoke();

            } catch (Exception ex) {
                ret.addCogException("execute", ex);
            }

            return ret;
        }

    }

    // public class ProcessFactory<T> : ProcessFactory
    // {
    // 
    //     internal new delegate T target(); // override the existing target delegate
    // 
    //     public ExecutionResult<T> execute(Func<T> task)
    //     {
    //         ExecutionResult<T> ret = new ExecutionResult<T>();
    // 
    //         try {
    //             ret.results = task.Invoke();
    // 
    //         } catch (Exception ex) {
    //             ret.ex = ex;
    //         }
    // 
    //         return ret;
    //     }
    // }
}
