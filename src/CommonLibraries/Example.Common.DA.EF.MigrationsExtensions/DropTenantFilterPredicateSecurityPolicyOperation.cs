using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Example.Common.DA.EF.MigrationsExtensions
{
    internal sealed class DropTenantFilterPredicateSecurityPolicyOperation : MigrationOperation
    {
        public string Name { get; set; } = null!;

        public string Schema { get; set; } = null!;
    }
}
