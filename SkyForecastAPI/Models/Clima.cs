using System.ComponentModel.DataAnnotations;

namespace SkyForecastAPI.Models
{
    public class Clima
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public decimal Temperatura { get; set; }
        public int Humedad { get; set; }
        public decimal? Viento { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal? Precipitacion { get; set; }
        public string Icono { get; set; } = string.Empty;
    }
}
