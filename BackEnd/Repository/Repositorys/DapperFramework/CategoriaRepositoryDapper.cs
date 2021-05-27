using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Repository.Entidades.Categoria;

namespace Repository.Repositorys
{
    public class CategoriaRepositoryDapper : ICategoriaRepository
    {
        private readonly Func<IDbConnection> _context;

        public CategoriaRepositoryDapper(Func<IDbConnection> context)
        {
            _context = context;
        }
        public async Task<List<CategoriaModel>> GetAll()
        {

            var query = @"SELECT
                        Id Id,
                        Codigo Codigo, 
                        Descricao Descricao, 
                        CriadoEm CriadoEm 
                        FROM Categorias";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista
                    var categorias = await connection.QueryAsync<CategoriaDapperModel>(query);

                    var categoriasMapeadas = new List<CategoriaModel>(); 

                    foreach (var categoria in categorias.ToList())
                    {
                        var mapeamento = new CategoriaModel()
                        {
                            Id = Guid.Parse(categoria.Id),
                            Codigo = categoria.Codigo,
                            Descricao = categoria.Descricao,
                            CriadoEm = categoria.CriadoEm.ToString("dddd, dd MMMM yyyy") 
                        };
                        categoriasMapeadas.Add(mapeamento);
                    }
                    return categoriasMapeadas;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //Invoke chamar a funçao

        }

        public async Task<List<CategoriaModel>> GetByDescription(string description)
        {
            var query = $@"SELECT
                        Id Id,
                        Codigo Codigo, 
                        Descricao Descricao, 
                        CriadoEm CriadoEm 
                        FROM Categorias 
                        WHERE INSTR(Descricao, '{description}')";
            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista
                    var categorias = await connection.QueryAsync<CategoriaDapperModel>(query);

                    var categoriasMapeadas = new List<CategoriaModel>();

                    foreach (var categoria in categorias.ToList())
                    {
                        var mapeamento = new CategoriaModel()
                        {
                            Id = Guid.Parse(categoria.Id),
                            Codigo = categoria.Codigo,
                            Descricao = categoria.Descricao,
                            CriadoEm = categoria.CriadoEm.ToString("dddd, dd MMMM yyyy")
                        };
                        categoriasMapeadas.Add(mapeamento);
                    }
                    return categoriasMapeadas;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public async Task<CategoriaModel> GetById(Guid id)
        {
            var query = $@"SELECT
                        Id Id,
                        Codigo Codigo, 
                        Descricao Descricao, 
                        CriadoEm CriadoEm 
                        FROM Categorias
                        WHERE Id = '{id}'";
            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista
                    var categoria = await connection.QueryFirstOrDefaultAsync<CategoriaDapperModel>(query);

                        var categoriaMapeada = (categoria != null) ? new CategoriaModel()
                        {
                            Id = Guid.Parse(categoria.Id),
                            Codigo = categoria.Codigo,
                            Descricao = categoria.Descricao,
                            CriadoEm = categoria.CriadoEm.ToString("dddd, dd MMMM yyyy")
                        } : null;
                        
                        return categoriaMapeada;                
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Post(CategoriaModel categoria)
        {
            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista


                    var categoriaMapeada = new CategoriaDapperModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Codigo = categoria.Codigo,
                        Descricao = categoria.Descricao,
                        CriadoEm = DateTime.Now
                    };
                    var query = $@"INSERT INTO Categorias         
                        Values(
                        '{categoriaMapeada.Id}',
                        '{categoriaMapeada.Codigo}',
                        '{categoriaMapeada.Descricao}',
                        '{categoriaMapeada.CriadoEm.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}'
                        )";                        
                await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task Update(CategoriaModel categoria)
        {
            var query = $@"UPDATE Categorias SET
                        Codigo='{categoria.Codigo}',
                        Descricao='{categoria.Descricao}'
                        WHERE Id='{categoria.Id}'";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista        
                    await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task Delete(Guid id)
        {
            var query = $@"DELETE FROM Categorias WHERE Id='{id}'";

            try
            {
                //AutoMapper
                using (IDbConnection connection = _context.Invoke())
                {
                    //IEnuberable Tipo generico de lista        
                    await connection.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
