using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace Repository
{
    public class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory dbFactory =
        new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public InMemoryDatabase()
        {
            this.Connection = this.dbFactory.OpenDbConnection();
            this.CreateDatabase();
        }

        public IDbConnection Connection { get; }

        public static readonly string CREATE_CATEGORIA_PRODUTO_DATABASE =
     @"CREATE TABLE Categorias 
        (
            Id VARCHAR(50) NULL, 
            Codigo VARCHAR(4) NULL, 
            Descricao VARCHAR(15) NULL, 
            CriadoEm Datetime NULL
        );

        CREATE TABLE Produtos 
        (
            Id char IDENTITY NOT NULL,
            Codigo VARCHAR(4) NOT NULL, 
            CategoriaId char NOT NULL,
            Descricao VARCHAR(15) NOT NULL, 
            Preco Decimal(18,2) NOT NULL, 
            UnidadeMedida VARCHAR(5) NOT NULL,
            constraint fkCategoria foreign key(CategoriaId) references Categorias(Id)
        );

        INSERT INTO Categorias Values('3eb7377f-c86e-4d1f-b5f6-c7cf9f3387fd', '1234', 'teste', '2021-05-21 15:00:00' );
        INSERT INTO Produtos Values('3eb7377f-c86e-4d1f-b5f6-c7cf9f3387f0', '1234', '3eb7377f-c86e-4d1f-b5f6-c7cf9f3387fd', 'Teste', 20, 'kg');
     ";

        private void CreateDatabase()
        {
            using (var connection = this.Connection)
            {
                connection.ExecuteSql(CREATE_CATEGORIA_PRODUTO_DATABASE);
            }
        }
    }
}