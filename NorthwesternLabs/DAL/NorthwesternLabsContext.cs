using NorthwesternLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorthwesternLabs.DAL
{
    public class NorthwesternLabsContext : DbContext
    {
        public NorthwesternLabsContext() : base("NorthwesternLabsContext")
        {

        }
        public DbSet<WorkOrder> WorkOrder { get; set; }
    }
}