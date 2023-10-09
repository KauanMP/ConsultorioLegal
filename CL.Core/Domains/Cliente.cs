using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CL.Core.Domains
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [DefaultValue("M")]
        [Required]
        public string Sexo { get; set; }
        public string Telefone { get; set; }

        [Column("DocumentoIdentificador")]
        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        public Endereco Endereco { get; set; }
    }
}