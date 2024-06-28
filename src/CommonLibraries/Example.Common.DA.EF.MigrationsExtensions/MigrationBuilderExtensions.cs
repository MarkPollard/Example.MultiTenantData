using Microsoft.EntityFrameworkCore.Migrations;

namespace Example.Common.DA.EF.MigrationsExtensions
{
    public static class MigrationBuilderExtensions
    {
        public static MigrationBuilder CreateTenantFilterPredicateSecurityPolicy(
            this MigrationBuilder migrationBuilder, string name, string schema, string table, string column = "TenantId")
        {
            var operation = new CreateTenantFilterPredicateSecurityPolicyOperation
            {
                Name = name,
                Schema = schema,
                Table = table,
                Column = column
            };
            migrationBuilder.Operations.Add(operation);

            return migrationBuilder;
        }

        public static MigrationBuilder DropTenantFilterPredicateSecurityPolicy(
            this MigrationBuilder migrationBuilder, string name, string schema)
        {
            var operation = new DropTenantFilterPredicateSecurityPolicyOperation
            {
                Name = name,
                Schema = schema
            };
            migrationBuilder.Operations.Add(operation);

            return migrationBuilder;
        }
    }
}
