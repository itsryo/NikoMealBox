using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NikoMealBox.DataAccess.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 新增一筆資料
        /// </summary>
        /// <param name="entities">要新增的的實體</param>
        void Insert(TEntity entities);

        /// <summary>
        /// 新增多筆資料
        /// </summary>
        /// <param name="entities">要新增的的實體集合</param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="entities">要更新的實體</param>
        void Update(TEntity entities);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="entities">要刪除的實體</param>
        void Delete(TEntity entities);

        /// <summary>
        /// 取得一筆資料，如無則回傳null
        /// </summary>
        /// <param name="predicate">查詢條件式</param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        void SaveChanges();
    }
}
