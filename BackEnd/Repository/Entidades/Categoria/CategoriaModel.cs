using System;

namespace Repository
{
    public class CategoriaModel
    {
        public CategoriaModel(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public CategoriaModel()
        {

        }

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string CriadoEm { get; set; }
    }
}
