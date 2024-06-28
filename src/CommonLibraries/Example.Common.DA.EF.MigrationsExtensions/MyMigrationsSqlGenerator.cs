using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Update;

namespace Example.Common.DA.EF.MigrationsExtensions
{
    public class MyMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public MyMigrationsSqlGenerator(
            MigrationsSqlGeneratorDependencies dependencies,
            ICommandBatchPreparer commandBatchPreparer)
            : base(dependencies, commandBatchPreparer)
        {
        }

        protected override void Generate(
            MigrationOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            if (operation is CreateTenantFilterPredicateSecurityPolicyOperation creatSecurityPolicyOperation)
            {
                GenerateCreateTenantFilterPredicateSecurityPolicy(creatSecurityPolicyOperation, builder);
            }
            else if (operation is DropTenantFilterPredicateSecurityPolicyOperation dropSecurityPolicyOperation)
            {
                GenerateDropTenantFilterPredicateSecurityPolicy(dropSecurityPolicyOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }

        private void GenerateCreateTenantFilterPredicateSecurityPolicy(
            CreateTenantFilterPredicateSecurityPolicyOperation operation,
            MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            builder
                .AppendLine($"CREATE SECURITY POLICY {sqlHelper.DelimitIdentifier(operation.Schema)}.{sqlHelper.DelimitIdentifier(operation.Name)}")
                .AppendLine($"ADD FILTER PREDICATE Security.tvf_securitypredicate({operation.Column})")
                .AppendLine($"ON {sqlHelper.DelimitIdentifier(operation.Schema)}.{sqlHelper.DelimitIdentifier(operation.Table)}")
                .AppendLine($"WITH (STATE = ON){sqlHelper.StatementTerminator}")
                .EndCommand();
        }

        private void GenerateDropTenantFilterPredicateSecurityPolicy(
            DropTenantFilterPredicateSecurityPolicyOperation operation,
            MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            builder
                .AppendLine($"DROP SECURITY POLICY {sqlHelper.DelimitIdentifier(operation.Schema)}.{sqlHelper.DelimitIdentifier(operation.Name)}{sqlHelper.StatementTerminator}")
                .EndCommand();
        }
    }
}