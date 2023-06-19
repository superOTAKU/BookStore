namespace API.Commons.DataAccesses;

public interface IRepository
{
    /// <summary>
    /// 为了便利性，设置此方法
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
}
