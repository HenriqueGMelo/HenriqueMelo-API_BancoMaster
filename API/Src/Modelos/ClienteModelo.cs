using LiteDB;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Src.Modelos
{
    public class ClienteModelo
    {
        [Key]
        [JsonIgnore]
        public ObjectId Id { get; set; }
        [Required]
        public long Documento { get; set; }
        public string Nome { get; set; }
        public string ChavePix { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Saldo { get; set; }

        [BsonCtor]
        public ClienteModelo (long documento, string nome, string chavePix)
        {
            Documento = documento;
            Nome = nome;
            ChavePix = chavePix;
        }
    }
}
