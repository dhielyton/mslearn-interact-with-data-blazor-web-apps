using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BlazingPizza.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory CreateSessionFactory(IConfiguration configuration)
        {

            if (_sessionFactory != null)
                return _sessionFactory;

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            _sessionFactory = Fluently.Configure()
                   .Database(MsSqlConfiguration.MsSql2012
                       .ConnectionString(connectionString)
                       .ShowSql()
                   )
                   .Mappings(m =>
                       {
                           m.FluentMappings.Add<PizzaSpecialMap>();
                           m.FluentMappings.Add<PizzaMap>();
                           m.FluentMappings.Add<ToppingMap>();
                           m.FluentMappings.Add<PizzaToppingMap>();


                       }

                   )
                   .ExposeConfiguration(cfg =>
                   {

                       new NHibernate.Tool.hbm2ddl.SchemaUpdate(cfg).Execute(false, true);
                   })
                   .BuildSessionFactory();

            return _sessionFactory;
        }
    }
}
