using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Example.Common.DA.EF.MigrationsExtensions
{
    internal sealed class CreateTenantFilterPredicateSecurityPolicyOperation : MigrationOperation
    {
        public string Name { get; set; } = null!;

        public string Schema { get; set; } = null!;

        public string Table { get; set; } = null!;

        public string Column { get; set; } = "TenantId";
    }
}
