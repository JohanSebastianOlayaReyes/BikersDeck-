namespace Entity.Dtos.Base
{
    /// <summary>
    /// Clase base para los DTOs que contiene propiedades comunes
    /// </summary>
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
