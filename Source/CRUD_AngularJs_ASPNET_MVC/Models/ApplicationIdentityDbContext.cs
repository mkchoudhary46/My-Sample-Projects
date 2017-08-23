using OwinAuth.Identity;

namespace CRUD_AngularJs_ASPNET_MVC.Models
{
    /// <summary>
    /// This class represents our extension of the EntityFramework context provided by the AspNet package
    /// </summary>
    /// <remarks>
    /// There are two important pieces of information communicated here. First, the name of the database 
    /// configured to house the identity tables. Second, the custom ApplicationUser type is being communicated
    /// via the type parameter on the IdentityDbContext base class definition.
    /// <para>EF code-first will take care of creating the schema. If you are using
    /// localdb, the database will be autogenerated on first use also.
    /// </para>
    /// </remarks>
    public class ApplicationIdentityDbContext
        : Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// The string used in the call to base is the name of the database and should match the 'initial catalog' value in your connection string.
        /// </summary>
        public ApplicationIdentityDbContext() : base("IdentityConnection") { }

        static ApplicationIdentityDbContext() {
            System.Data.Entity.Database.SetInitializer<ApplicationIdentityDbContext>(new IdentityDbInitializer());
        }

        /// <summary>
        /// Provides a factory method for OWIN middleware configuration
        /// </summary>
        /// <returns>An instance of the application specific EF context</returns>
        public static ApplicationIdentityDbContext Create() {
            return new ApplicationIdentityDbContext();
        }
    }
}