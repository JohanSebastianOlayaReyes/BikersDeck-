using AutoMapper;
using Data.Interfaces;
using Entity.Dtos.Base;
using Entity.Model.Base;
using Microsoft.Extensions.Logging;

namespace Business.Implements
{
    public class BaseBusiness<T, D> : ABaseBusiness<T, D>
        where T : BaseModel
        where D : BaseDto
    {
        protected readonly IMapper _mapper;

        protected readonly IBaseModelData<T> _data;

        protected readonly ILogger _logger;

        public BaseBusiness(
            IBaseModelData<T> data,
            IMapper mapper,
            ILogger logger
         )
            : base()
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // metodo para obtener un registro por ID
        public override async Task<D> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Obteniendo {typeof(T).Name} con ID: {id}");
                var entity = await _data.GetByIdAsync(id);
                return _mapper.Map<D>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener {typeof(T).Name} con ID {id}");
                throw;
            }
        }
        // metodo para actualizar un registro
        public override async Task<D> UpdateAsync(D dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                entity = await _data.UpdateAsync(entity);
                _logger.LogInformation($"Actualizando {typeof(T).Name} desde DTO");
                return _mapper.Map<D>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar {typeof(T).Name} desde DTO");
                throw;
            }
        }

        //metodo para eleminar un registro
        public override async Task<bool> ActiveAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando {typeof(T).Name} con ID: {id}");
                return await _data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar {typeof(T).Name} con ID {id}");
                throw;
            }
        }
    }
}
