using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fixture.Persistence.Entity.Conventions
{
    /// <summary>
    /// Provides a convention that doesn't use the underscore as delimiter in foreign key column names.
    /// </summary>
    public class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
    {

        public void Apply(AssociationType association, DbModel model)
        {
            // Identify a ForeignKey property (including IAs)
            if (association.IsForeignKey)
            {
                // rename FK columns
                var constraint = association.Constraint;

                NormalizePropertiesForeignKeys(constraint.FromProperties);
                NormalizePropertiesForeignKeys(constraint.ToProperties);
            }
        }

        /// <summary>
        /// Removes the underscore delimiter from the constraints
        /// </summary>
        /// <param name="properties"></param>
        private void NormalizePropertiesForeignKeys(ReadOnlyMetadataCollection<EdmProperty> properties)
        {
            const string UnderscoreDelimiter = "_";

            foreach (var prop in properties)
            {
                if (prop.Name.Contains(UnderscoreDelimiter))
                    prop.Name = prop.Name.Replace(UnderscoreDelimiter, "");
            }
        }
    }
}
