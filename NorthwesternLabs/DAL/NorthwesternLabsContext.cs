//Server Name: northwest2-16.database.windows.net
//Use SQL Authentication
//Username: NorthwestLabsAdmin2019
//Password: IntExAdmin2-16

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

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.Compound> Compounds { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.Assay> Assays { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.Invoice> Invoices { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.Material> Materials { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.CompoundSample> CompoundSamples { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.Test> Tests { get; set; }

        public System.Data.Entity.DbSet<NorthwesternLabs.Models.User> Users { get; set; }
    }
}