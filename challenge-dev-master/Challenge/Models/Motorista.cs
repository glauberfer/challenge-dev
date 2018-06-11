using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Motorista Class
    /// </summary>
    public class Motorista
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string PrimeiroNome { get; set; }
        [Required]
        public string UltimoNome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string EnderecoMaps { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataExclusao { get; set; }

        public List<Carro> Carros { get; set; }
        
        public Motorista(List<Carro> carros)
        {
            this.Carros = carros;
        }

        public Motorista()
        {

        }
    }
}
