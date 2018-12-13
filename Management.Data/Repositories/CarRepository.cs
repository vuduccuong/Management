using Management.Common.ViewModel;
using Management.Data.Infrastructure;
using Management.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<CarDetailVewModel> GetAllDetail();
        IEnumerable<CarByRouteViewModel> GetCarByRoute(int id, string timestart);
        IEnumerable<RowByCarViewModel> GetRowByCar(int id);
        IEnumerable<StatusBySeatViewModel> GetStatusBySeat(int id, string dateBook);
        IEnumerable<GetCarByPointVewModel> GetCarByPoint(string startPoint, string endPoint, string dateBook, int timeStart);
    }
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
        public IEnumerable<CarDetailVewModel> GetAllDetail()
        {
            return DbContext.Database.SqlQuery<CarDetailVewModel>("Proc_CarDetal");
        }

        public IEnumerable<GetCarByPointVewModel> GetCarByPoint(string startPoint, string endPoint, string dateBook, int timeStart)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@StartPoint",startPoint),
                new SqlParameter("@EndPoint",endPoint),
                new SqlParameter("@DateBook",dateBook),
                new SqlParameter("@Time",timeStart),
            };
            return DbContext.Database.SqlQuery<GetCarByPointVewModel>("GetCarByPointTime @StartPoint,@EndPoint,@DateBook,@Time", parameters);
        }

        public IEnumerable<CarByRouteViewModel> GetCarByRoute(int id, string timestart)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@IDSeat", id),
                new SqlParameter("@TimeStart", timestart)
            };
            return DbContext.Database.SqlQuery<CarByRouteViewModel>("Proc_SearchCarByRoute @IDSeat, @TimeStart", parameters);
        }

        public IEnumerable<RowByCarViewModel> GetRowByCar(int id)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@IDCar",id)
            };
            return DbContext.Database.SqlQuery<RowByCarViewModel>("Proc_SearchSeatByCar @IDCar", parameters);
        }

        public IEnumerable<StatusBySeatViewModel> GetStatusBySeat(int id, string dateBook)
        {
            var parameters = new Object[]
            {
                new SqlParameter("@IDSeat", id),
                new SqlParameter("@DateBook", dateBook)
            };
            return DbContext.Database.SqlQuery<StatusBySeatViewModel>("Proc_CheckStatusBySeat @IDSeat, @DateBook", parameters);
        }
    }
}
