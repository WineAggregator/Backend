namespace Backend.Api.Dto;

public abstract class BaseDto
{

}

public abstract class BaseUpdateDto<TModel> : BaseDto
{
    public abstract TModel UpdateEntity(TModel entityToUpdate);
}

public class BaseIdDto : BaseDto
{
    public int Id { get; set; }
}