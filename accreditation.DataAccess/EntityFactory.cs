using Mooho.Base.Common;
using Mooho.Base.DataAccess;
using Mooho.Base.IDataAccess;

namespace accreditation.DataAccess
{
    /// <summary>
    /// 实体工厂
    /// </summary>
    public class EntityFactory : IEntityFactory
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <returns></returns>
        public IEntities CreateEntities()
        {
            return DynamicProxy.CreateContext() as Entities ?? new Entities();
        }
    }
}
