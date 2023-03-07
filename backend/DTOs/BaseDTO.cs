using Luxelane.Models;

namespace Luxelane.DTOs
{
    public abstract class BaseDTO<TModel> where TModel : BaseModel
    {
        public abstract void UpdateModel(TModel model);
    }
}