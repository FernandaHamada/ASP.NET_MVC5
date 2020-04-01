using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public String Nome { get; set; }

        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        
        public int? CategoriaId { get; set; }

        [Required, StringLength(30)]
        public String Descricao { get; set; }

        [Range(0, 100, ErrorMessage = "Quantidade deve ser entre {1} e {2}.")]
        public int Quantidade { get; set; }
    }
}