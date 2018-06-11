using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// Class Carro
    /// </summary>
    public class Carro
    {
        [Key]
        public int ID { get; set; }
        [Key]
        public int MotoristaID { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Marca { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExclusao { get; set; }
        
        public Motorista Motorista { get; set; }

        public Carro(Motorista motorista)
        {
            this.Motorista = motorista;
        }

        public Carro()
        {

        }
    }
}
