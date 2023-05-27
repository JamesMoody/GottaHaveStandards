using System;
using System.Collections.Generic;
using System.Text;


namespace GottaHaveStandards
{
    public interface iCog
    {
        string Key { get; }

        void process(Action target, ref ExecutionResult result); // note: Must match ProcessFactory.processCog
    }
}