using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    public interface ILead
    {
        // Properties
        int hunderDeath { get; set; }
        int LiveHerbivorous { get; set; }
        int LivePredator { get; set; }
        int ReproductionHerbivorousus { get; set; }
        int ReproductionPredators { get; set; }
    }
}
