namespace API.Commons.DataAccesses;

/// <summary>
/// 一个工作单元，简单理解就是一个事务
/// </summary>
public interface IUnitOfWork
{
    void Commit();
}
